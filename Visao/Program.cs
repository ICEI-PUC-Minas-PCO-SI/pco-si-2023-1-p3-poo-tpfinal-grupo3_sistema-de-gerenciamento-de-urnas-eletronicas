
using Microsoft.EntityFrameworkCore;
using Visao;

namespace Urna
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("C:\\UrnaEletronica"))
                Directory.CreateDirectory("C:\\UrnaEletronica");

            using(var db = new UrnaEletronicaContext())
            {
                db.Database.Migrate();
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Home());
        }
    }
}