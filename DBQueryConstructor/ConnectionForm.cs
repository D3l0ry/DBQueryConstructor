using System.Data.Common;

using DBQueryConstructor.DatabaseInteractions;

using Microsoft.Win32.Serialization;

namespace DBQueryConstructor;
public partial class ConnectionForm : Form
{
    private readonly RegistrySerializer<ConnectionSetting> _Serializer;
    private ConnectionSetting _Setting;

    public ConnectionForm()
    {
        InitializeComponent();

        _Serializer = new RegistrySerializer<ConnectionSetting>();
        _Setting = _Serializer.Deserialize();

        serverTextBox.Text = _Setting?.Server;
        databaseTextBox.Text = _Setting?.Database;
        userTextBox.Text = _Setting?.Login;
        passwordTextBox.Text = _Setting?.Password;
    }

    private void OpenConnectionButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(serverTextBox.Text))
        {
            MessageBox.Show("Введите имя сервера!", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(databaseTextBox.Text))
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

        if (!string.IsNullOrWhiteSpace(userTextBox.Text))
        {
            connectionStringBuilder.Add("User ID", userTextBox.Text);
        }

        if (!string.IsNullOrWhiteSpace(passwordTextBox.Text))
        {
            connectionStringBuilder.Add("Password", passwordTextBox.Text);
        }

        try
        {
            _Setting ??= new ConnectionSetting();
            _Setting.Server = serverTextBox.Text;
            _Setting.Database = databaseTextBox.Text;
            _Setting.Login = userTextBox.Text;
            _Setting.Password = passwordTextBox.Text;

            _Serializer.Serialize(_Setting);

            Program.UsedDatabase?.Dispose();
            Program.UsedDatabase = new UsedDatabase(connectionStringBuilder.ToString());

            DialogResult = DialogResult.Yes;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}