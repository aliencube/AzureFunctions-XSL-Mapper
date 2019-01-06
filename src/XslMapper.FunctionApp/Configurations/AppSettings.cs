using System.Net.Http.Formatting;

using Aliencube.AzureFunctions.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Aliencube.XslMapper.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the settings entity from the configurations.
    /// </summary>
    public class AppSettings
    {
        private const string AzureWebJobsStorageKey = "AzureWebJobsStorage";
        private const string ContainersKey = "Containers";
        private const string EncodeBase64OutputKey = "EncodeBase64Output";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
        {
            var jsonSerialiserSettings = new JsonSerializerSettings()
                                             {
                                                 Formatting = Formatting.Indented,
                                                 ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                                 NullValueHandling = NullValueHandling.Ignore,
                                                 MissingMemberHandling = MissingMemberHandling.Ignore,
                                             };

            var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            this.JsonFormatter = new JsonMediaTypeFormatter() { SerializerSettings = jsonSerialiserSettings };
            this.StorageConnectionString = config.GetValue<string>(AzureWebJobsStorageKey);
            this.Containers = config.Get<ContainerSettings>(ContainersKey);
            this.EncodeBase64Output = config.GetValue<bool>(EncodeBase64OutputKey);
        }

        /// <summary>
        /// Gets the JSON formatter.
        /// </summary>
        public virtual JsonMediaTypeFormatter JsonFormatter { get; }

        /// <summary>
        /// Gets the storage account connection string.
        /// </summary>
        public virtual string StorageConnectionString { get; }

        /// <summary>
        /// Gets the <see cref="ContainerSettings"/> instance.
        /// </summary>
        public virtual ContainerSettings Containers { get; }

        /// <summary>
        /// Gets the value indicating whether to encode output in base64 or not.
        /// </summary>
        public virtual bool EncodeBase64Output { get; }
    }
}