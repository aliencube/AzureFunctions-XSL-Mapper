using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

using Aliencube.XslMapper.FunctionApp.Models;

namespace Aliencube.XslMapper.FunctionApp.Helpers
{
    /// <summary>
    /// This provides interfaces to the <see cref="XmlTransformHelper"/> class.
    /// </summary>
    public interface IXmlTransformHelper : IDisposable
    {
        /// <summary>
        /// Loads XSL from byte array.
        /// </summary>
        /// <param name="container">Blob container name.</param>
        /// <param name="application">Application name.</param>
        /// <param name="mapper">Mapper name.</param>
        /// <returns><see cref="IXmlTransformHelper"/> instance.</returns>
        Task<IXmlTransformHelper> LoadXslAsync(string container, string application, string mapper);

        /// <summary>
        /// Loads XSL from byte array.
        /// </summary>
        /// <param name="bytes">Byte array containing XSL.</param>
        /// <returns><see cref="IXmlTransformHelper"/> instance.</returns>
        Task<IXmlTransformHelper> LoadXslAsync(byte[] bytes);

        /// <summary>
        /// Adds list of <see cref="ExtensionObject"/> into arguments.
        /// </summary>
        /// <param name="eos">List of <see cref="ExtensionObject"/> instances.</param>
        /// <returns><see cref="IXmlTransformHelper"/> instance.</returns>
        Task<IXmlTransformHelper> AddArgumentsAsync(List<ExtensionObject> eos);

        /// <summary>
        /// Transforms XML.
        /// </summary>
        /// <param name="inputXml">Input XML as the <see cref="XmlReader"/> instance.</param>
        /// <returns>Transformed XML in byte array.</returns>
        Task<byte[]> TransformAsync(XmlReader inputXml);

        /// <summary>
        /// Transforms XML.
        /// </summary>
        /// <param name="inputXml">Input XML in byte array.</param>
        /// <returns>Transformed XML in byte array.</returns>
        Task<byte[]> TransformAsync(byte[] inputXml);

        /// <summary>
        /// Transforms XML.
        /// </summary>
        /// <param name="inputXml">Input XML in text format.</param>
        /// <returns>Transformed XML in byte array.</returns>
        Task<byte[]> TransformAsync(string inputXml);
    }
}