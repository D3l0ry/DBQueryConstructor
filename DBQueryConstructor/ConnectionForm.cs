using System.Data.Common;

using DBQueryConstructor.Properties;

namespace DBQueryConstructor;
public partial class ConnectionForm : Form
{
    public ConnectionForm()
    {
        InitializeComponent();

        serverTextBox.Text = Settings.Default.Server;
        databaseTextBox.Text = Settings.Default.Database;
        userTextBox.Text = Settings.Default.Login;
        passwordTextBox.Text = Settings.Default.Password;
    }

    private void OpenConnectionButton_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(serverTextBox.Text))
        {
            MessageBox.Show("Введите имя сервера!", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if(string.IsNullOrWhiteSpace(databaseTextBox.Text))
        {
            MessageBox.Show("Введите имя базы данных!", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DbConnectionStringBuilder connectionStringBuilder = new DbConnectionStringBuilder();

        connectionStringBuilder.Add("Data Source", serverTextBox.Text);
        connectionStringBuilder.Add("Initial Catalog", databaseTextBox.Text);
        connectionStringBuilder.Add("Encrypt", false);
        connectionStringBuilder.Add("Integrated Security", false);
        connectionStringBuilder.Add("Trusted_Connection", false);

        if(!string.IsNullOrWhiteSpace(userTextBox.Text))
        {
            connectionStringBuilder.Add("User ID", userTextBox.Text);
        }

        if(!string.IsNullOrWhiteSpace(passwordTextBox.Text))
        {
            connectionStringBuilder.Add("Password", passwordTextBox.Text);
        }

        try
        {
            Program.UsedDatabase?.Dispose();
            Program.UsedDatabase = new Database.UsedDatabase(connectionStringBuilder.ToString());

            Settings.Default.Server = serverTextBox.Text;
            Settings.Default.Database = databaseTextBox.Text;
            Settings.Default.Login = userTextBox.Text;
            Settings.Default.Password = passwordTextBox.Text;

            Settings.Default.Save();

            DialogResult = DialogResult.Yes;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}