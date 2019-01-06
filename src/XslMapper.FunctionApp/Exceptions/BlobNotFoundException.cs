using System;
using System.Runtime.Serialization;

using Microsoft.WindowsAzure.Storage.Blob;

namespace Aliencube.XslMapper.FunctionApp.Exceptions
{
    /// <summary>
    /// This represents the exception entity thrown when <see cref="CloudBlockBlob"/> doesn't exist.
    /// </summary>
    public class BlobNotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobNotFoundException"/> class.
        /// </summary>
        public BlobNotFoundException()
            : this("Blob not found")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public BlobNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner <see cref="Exception"/> instance.</param>
        public BlobNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobNotFoundException"/> class.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> instance.</param>
        /// <param name="context"><see cref="StreamingContext"/> instance.</param>
        protected BlobNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}