using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;
using Aliencube.XslMapper.FunctionApp.Configurations;
using Aliencube.XslMapper.FunctionApp.Functions;
using Aliencube.XslMapper.FunctionApp.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace Aliencube.XslMapper.FunctionApp.Modules
{
    /// <summary>
    /// This represents the module entity for DI.
    /// </summary>
    public class AppModule : Module
    {
        /// <inheritdoc />
        public override void Load(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();

            services.AddTransient<IBlobStorageHelper, BlobStorageHelper>();
            services.AddTransient<IXmlTransformHelper, XmlTransformHelper>();

            services.AddTransient<IXmlToXmlMapperFunction, XmlToXmlMapperFunction>();
        }
    }
}