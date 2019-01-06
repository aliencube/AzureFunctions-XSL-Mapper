namespace Aliencube.XslMapper.FunctionApp.Models
{
    /// <summary>
    /// This represents the extension object entity.
    /// </summary>
    public class ExtensionObject
    {
        /// <summary>
        /// Gets or sets the directory name where the extension object is located.
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Gets or sets the extension object filename.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the XSL namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the assembly name.
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// Gets or sets the class name.
        /// </summary>
        public string ClassName { get; set; }
    }
}