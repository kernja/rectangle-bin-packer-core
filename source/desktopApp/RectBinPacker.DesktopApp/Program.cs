using Microsoft.Extensions.DependencyInjection;
using RectBinPacker.DesktopApp.Adapters;
using RectBinPacker.DesktopApp.Services;
using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectBinPacker.DesktopApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // configure our dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IImageAdapter, ImageAdapter>()
                .AddScoped<IFilePickerService, FilePickerService>()
                .AddScoped<IDefaultValidators, DefaultValidators>()
                .AddScoped<ISolverService, SolverService>()
                .AddScoped<IFrmMain, frmMain>()
                .BuildServiceProvider();

            using (serviceProvider)
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run((Form)serviceProvider.GetService<IFrmMain>());
            }
        }
    }
}
