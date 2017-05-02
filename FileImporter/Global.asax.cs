using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using FileImporter.Data;
using FileImporter.Factory;
using FileImporter.Factory.Format1;
using FileImporter.Factory.Format2;
using FileImporter.Reader;
using FileImporter.Service;

namespace FileImporter
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<FileRepository>().As<IFileRepository>();
            builder.RegisterType<StringExtentionMethods>().As<IStringExtensionMethods>();
            builder.RegisterType<Format1Settings>().Named<ISettings>("Format1Settings").SingleInstance();
            builder.RegisterType<Format1>()
                .As<IFileFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ISettings>("Format1Settings"));

            builder.RegisterType<Format2Settings>().Named<ISettings>("Format2Settings").SingleInstance();
            builder.RegisterType<Format2>()
                .As<IFileFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ISettings>("Format2Settings"));

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
