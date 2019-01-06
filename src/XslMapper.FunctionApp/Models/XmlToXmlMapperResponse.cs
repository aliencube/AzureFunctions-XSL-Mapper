using Newtonsoft.Json;

namespace Aliencube.XslMapper.FunctionApp.Models
{
    /// <summary>
    /// This represents the response entity for XML-to-XML mapper.
    /// </summary>
    public class XmlToXmlMapperResponse
    {
        private const string ApplicationXml = "application/xml";

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlToXmlMapperResponse"/> class.
        /// </summary>
        public XmlToXmlMapperResponse()
        {
            this.ContentType = ApplicationXml;
        }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        [JsonProperty("$content-type", Order = 1)]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [JsonProperty("$content", Order = 2)]
        public string Content { get; set; }
    }
}