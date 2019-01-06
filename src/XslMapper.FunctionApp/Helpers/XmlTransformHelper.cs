using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

using Aliencube.XslMapper.FunctionApp.Configurations;
using Aliencube.XslMapper.FunctionApp.Extensions;
using Aliencube.XslMapper.FunctionApp.Models;

namespace Aliencube.XslMapper.FunctionApp.Helpers
{
    /// <summary>
    /// This represents the helper entity for XML transformation.
    /// </summary>
    public class XmlTransformHelper : IXmlTransformHelper
    {
        private readonly AppSettings _settings;
        private readonly IBlobStorageHelper _helper;
        private readonly XslCompiledTransform _xslt;
        private readonly XsltArgumentList _arguments;

        private bool _disposed;

        private Stream _stylesheetStream;
        private XmlReader _stylesheetReader;

        private Stream _transformStream;
        private XmlWriter _transformWriter;

        private Stream _transformByteStream;
        private XmlReader _transformByteReader;

        private TextReader _transformStringReader;
        private XmlReader _transformTextReader;

        public XmlTransformHelper(AppSettings settings, IBlobStorageHelper helper)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._helper = helper ?? throw new ArgumentNullException(nameof(helper));

            this._xslt = new XslCompiledTransform(enableDebug: true);
            this._arguments = new XsltArgumentList();
        }

        /// <inheritdoc />
        public async Task<IXmlTransformHelper> LoadXslAsync(string container, string application, string mapper)
        {
            var blob = await this._helper
                                 .LoadBlobAsync(container, application, mapper)
                                 .ConfigureAwait(false);

            var bytes = new byte[blob.Properties.Length];
            await blob.DownloadToByteArrayAsync(bytes, 0).ConfigureAwait(false);

            return await this.LoadXslAsync(bytes)
                             .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IXmlTransformHelper> LoadXslAsync(byte[] bytes)
        {
            this._stylesheetStream = new MemoryStream(bytes);
            this._stylesheetReader = XmlReader.Create(this._stylesheetStream);

            await Task.Factory.StartNew(() => this._xslt.Load(this._stylesheetReader, new XsltSettings(enableDocumentFunction: true, enableScript: true), stylesheetResolver: null))
                      .ConfigureAwait(false);

            return this;
        }

        /// <inheritdoc />
        public async Task<IXmlTransformHelper> AddArgumentsAsync(List<ExtensionObject> eos)
        {
            foreach (var eo in eos)
            {
                var blob = await this._helper
                                     .LoadBlobAsync(this._settings.Containers.ExtensionObjects, eo.Directory, eo.Name)
                                     .ConfigureAwait(false);

                var bytes = new byte[blob.Properties.Length];
                await blob.DownloadToByteArrayAsync(bytes, 0).ConfigureAwait(false);

                var assembly = Assembly.Load(bytes);
                var instance = assembly.CreateInstance(eo.ClassName);

                this._arguments.AddExtensionObject(eo.Namespace, instance);
            }

            return this;
        }

        /// <inheritdoc />
        public async Task<byte[]> TransformAsync(XmlReader inputXml)
        {
            await Task.Factory.StartNew(() =>
                       {
                           this._transformStream = new MemoryStream();
                           this._transformWriter = XmlWriter.Create(this._transformStream, this._xslt.OutputSettings);
                           this._xslt.Transform(inputXml, this._arguments, this._transformWriter);
                       })
                      .ConfigureAwait(false);

            var transformed = (this._transformStream as MemoryStream).ToArray().RemoveBom();

            return transformed;
        }

        /// <inheritdoc />
        public async Task<byte[]> TransformAsync(byte[] inputXml)
        {
            this._transformByteStream = new MemoryStream(inputXml);
            this._transformByteReader = XmlReader.Create(this._transformByteStream);

            return await this.TransformAsync(this._transformByteReader)
                             .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<byte[]> TransformAsync(string inputXml)
        {
            this._transformStringReader = new StringReader(inputXml);
            this._transformTextReader = XmlReader.Create(this._transformStringReader);

            return await this.TransformAsync(this._transformTextReader)
                             .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Value indicating whther to be disposing resources or not.</param>
        protected void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this._disposed)
            {
                return;
            }

            if (this._stylesheetStream == null)
            {
                this._stylesheetStream.Dispose();
            }

            if (this._stylesheetReader == null)
            {
                this._stylesheetReader.Dispose();
            }

            if (this._transformStream == null)
            {
                this._transformStream.Dispose();
            }

            if (this._transformWriter == null)
            {
                this._transformWriter.Dispose();
            }

            if (this._transformByteStream == null)
            {
                this._transformByteStream.Dispose();
            }

            if (this._transformByteReader == null)
            {
                this._transformByteReader.Dispose();
            }

            if (this._transformStringReader == null)
            {
                this._transformStringReader.Dispose();
            }

            if (this._transformTextReader == null)
            {
                this._transformTextReader.Dispose();
            }

            this._disposed = true;
        }
    }
}