using AppNET.App;

namespace AppNET.Presentation.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ApplicationServiceSettings.RegisterAllService(); //proje ba�lamadan ne kadar back end servisimiz varsa kay�t etmi� oluruz
            Application.Run(new Form1());
        }
    }
}