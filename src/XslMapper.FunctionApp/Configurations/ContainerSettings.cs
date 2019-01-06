namespace Aliencube.XslMapper.FunctionApp.Configurations
{
    /// <summary>
    /// This represents the container settings entity from the app settings.
    /// </summary>
    public class ContainerSettings
    {
        /// <summary>
        /// Gets or sets the mappers container name.
        /// </summary>
        public virtual string Mappers { get; set; }

        /// <summary>
        /// Gets or sets the extension objects container name.
        /// </summary>
        public virtual string ExtensionObjects { get; set; }
    }
}