using FileIoExamples.Business;
using FileIOExamples.Business;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<JsonHelper>();
            services.AddTransient<XmlHelper>();
            services.AddTransient<BinaryHelper>();
            services.AddTransient<IOptionService, OptionService>();
            services.AddSingleton<ITools, Tools>();
            services.AddSingleton<IToolsOption, ToolsOption>();
            services.AddTransient<Form1>();
            services.AddTransient<FileForm>();
            services.AddTransient<OptionGetter>();


            var provider = services.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Form1 form1 = provider.GetService<Form1>()!;
            Application.Run(form1);
        }
    }
}