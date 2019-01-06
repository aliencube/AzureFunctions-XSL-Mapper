using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

using Aliencube.XslMapper.FunctionApp.Helpers;
using Aliencube.XslMapper.FunctionApp.Models;

namespace Aliencube.XslMapper.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="XmlTransformHelper"/> class.
    /// </summary>
    public static class XmlTransformHelperExtensions
    {
        /// <summary>
        /// Adds arguments into the <see cref="IXmlTransformHelper"/> instance.
        /// </summary>
        /// <param name="helper"><see cref="IXmlTransformHelper"/> instance.</param>
        /// <param name="eos">Lsit of <see cref="ExtensionObject"/> instances.</param>
        /// <returns><see cref="IXmlTransformHelper"/> instance.</returns>
        public static async Task<IXmlTransformHelper> AddArgumentsAsync(this Task<IXmlTransformHelper> helper, List<ExtensionObject> eos)
        {
            var instance = await helper.ConfigureAwait(false);

            return await instance.AddArgumentsAsync(eos).ConfigureAwait(false);
        }

        /// <summary>
        /// Transforms the input XML into the byte array.
        /// </summary>
        /// <param name="helper"><see cref="IXmlTransformHelper"/> instance.</param>
        /// <param name="inputXml"><see cref="XmlReader"/> as input XML.</param>
        /// <returns>Byte array transformed.</returns>
        public static async Task<byte[]> TransformAsync(this Task<IXmlTransformHelper> helper, XmlReader inputXml)
        {
            var instance = await helper.ConfigureAwait(false);

            return await instance.TransformAsync(inputXml).ConfigureAwait(false);
        }

        /// <summary>
        /// Transforms the input XML into the byte array.
        /// </summary>
        /// <param name="helper"><see cref="IXmlTransformHelper"/> instance.</param>
        /// <param name="inputXml">Byte array as input XML.</param>
        /// <returns>Byte array transformed.</returns>
        public static async Task<byte[]> TransformAsync(this Task<IXmlTransformHelper> helper, byte[] inputXml)
        {
            var instance = await helper.ConfigureAwait(false);

            return await instance.TransformAsync(inputXml).ConfigureAwait(false);
        }

        /// <summary>
        /// Transforms the input XML into the byte array.
        /// </summary>
        /// <param name="helper"><see cref="IXmlTransformHelper"/> instance.</param>
        /// <param name="inputXml">String value as input XML.</param>
        /// <returns>Byte array transformed.</returns>
        public static async Task<byte[]> TransformAsync(this Task<IXmlTransformHelper> helper, string inputXml)
        {
            var instance = await helper.ConfigureAwait(false);

            return await instance.TransformAsync(inputXml).ConfigureAwait(false);
        }
    }
}