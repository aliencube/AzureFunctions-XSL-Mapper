using System;
using System.Runtime.Serialization;

using Microsoft.WindowsAzure.Storage.Blob;

namespace Aliencube.XslMapper.FunctionApp.Exceptions
{
    /// <summary>
    /// This represents the exception entity thrown when <see cref="CloudBlobContainer"/> doesn't exist.
    /// </summary>
    public class BlobContainerNotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerNotFoundException"/> class.
        /// </summary>
        public BlobContainerNotFoundException()
            : this("Blob container not found")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public BlobContainerNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner <see cref="Exception"/> instance.</param>
        public BlobContainerNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContainerNotFoundException"/> class.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> instance.</param>
        /// <param name="context"><see cref="StreamingContext"/> instance.</param>
        protected BlobContainerNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}