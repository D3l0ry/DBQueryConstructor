using DBQueryConstructor.Database;

namespace DBQueryConstructor
{
    internal static class Program
    {
        public static UsedDatabase UsedDatabase { get; set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}