using DBQueryConstructor.DatabaseInteractions;

namespace DBQueryConstructor;

internal static class Program
{
    public static UsedDatabase UsedDatabase { get; set; }

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}