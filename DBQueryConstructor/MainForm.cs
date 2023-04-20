using System.Data.Common;
using System.Text.Json;

using DBQueryConstructor.Controls.ConstructorPanels;
using DBQueryConstructor.DatabaseInteractions;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor;

public partial class MainForm : Form
{
    public MainForm() => InitializeComponent();

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams parameters = base.CreateParams;
            parameters.ExStyle = 0x2000000;

            return parameters;
        }
    }

    private void DatabasePanel_OpenConnection(object sender, EventArgs e) => queryConstructorQueryExecuteButton.Enabled = true;

    private void DatabasePanel_CloseConnection(object sender, EventArgs e) => queryConstructorQueryExecuteButton.Enabled = false;

    private void ClearConstructorToolStripButton_Click(object sender, EventArgs e)
    {
        const string message = "Вы уверены, что хотите очистить конструктор?";
        const string title = "Очистка конструктора";

        ConstructorTabPage selectedTab = (ConstructorTabPage)queryConstructorTabControl.SelectedTab;

        if (selectedTab == null)
        {
            return;
        }

        DialogResult result = MessageBox
            .Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            return;
        }

        selectedTab.ClearConstructor();
    }

    private void AddNewConstructorToolStripButton_Click(object sender, EventArgs e)
    {
        string tabPageName = $"query{queryConstructorTabControl.TabPages.Count}";
        ConstructorTabPage newTabPage = new(tabPageName);

        queryConstructorTabControl.TabPages.Add(newTabPage);
        queryConstructorTabControl.SelectedTab = newTabPage;
    }

    private void QueryConstructorOpenToolStripButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        using Stream storedFile = openFileDialog.OpenFile();
        QueryStored stored = JsonSerializer.Deserialize<QueryStored>(storedFile);

        ConstructorTabPage newTabPage = queryConstructorTabControl.TabPages
            .OfType<ConstructorTabPage>()
            .FirstOrDefault(currentTabPage => currentTabPage.Text == openFileDialog.FileName);

        if (newTabPage == null)
        {
            UsedDatabase usedDatabase = Program.UsedDatabase;

            if (usedDatabase != null)
            {
                DbConnection activeConnection = usedDatabase.Connection;

                if (activeConnection.DataSource != stored.Server && activeConnection.Database == stored.Database)
                {
                    const string title = "Несовместимость серверов базы данных";
                    const string message = "Сервер и база данных отличается от сохраеннных в файле. " +
                        "Вы уверены, что хотите загрузить файл?";

                    DialogResult result = MessageBox
                        .Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            newTabPage = new(openFileDialog.FileName);
            queryConstructorTabControl.TabPages.Add(newTabPage);
        }

        queryConstructorTabControl.SelectedTab = newTabPage;
        newTabPage.LoadQueryStored(stored);
    }

    private void QueryConstructorSaveToolStripButton_Click(object sender, EventArgs e)
    {
        ConstructorTabPage selectedTab = (ConstructorTabPage)queryConstructorTabControl.SelectedTab;

        if (selectedTab == null)
        {
            return;
        }

        saveFileDialog.FileName = selectedTab.Text;

        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        using FileStream storedFile = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        JsonSerializerOptions options = new JsonSerializerOptions();
        QueryStored stored = selectedTab.GetQueryStored();

        options.WriteIndented = true;

        JsonSerializer.Serialize(storedFile, stored, options);
    }

    private void QueryConstructorExecuteButton_Click(object sender, EventArgs e)
    {
        ConstructorTabPage selectedTab = (ConstructorTabPage)queryConstructorTabControl.SelectedTab;

        if (selectedTab == null)
        {
            return;
        }

        selectedTab.ExecuteQuery();
    }
}