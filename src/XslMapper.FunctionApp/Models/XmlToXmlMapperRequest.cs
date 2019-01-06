using System.Collections.Generic;

namespace Aliencube.XslMapper.FunctionApp.Models
{
    /// <summary>
    /// This represent the request entity for XML-to-XML mapper.
    /// </summary>
    public class XmlToXmlMapperRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlToXmlMapperRequest"/> class.
        /// </summary>
        public XmlToXmlMapperRequest()
        {
            this.ExtensionObjects = new List<ExtensionObject>();
        }

        /// <summary>
        /// Gets or sets the input XML.
        /// </summary>
        public string InputXml { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="XslMapper"/> instance.
        /// </summary>
        public XslMapper Mapper { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ExtensionObject"/> instances.
        /// </summary>
        public List<ExtensionObject> ExtensionObjects { get; set; }
    }
}