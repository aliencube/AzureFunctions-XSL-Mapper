using System;
using System.Runtime.Serialization;

using Microsoft.WindowsAzure.Storage;

namespace Aliencube.XslMapper.FunctionApp.Exceptions
{
    /// <summary>
    /// This represents the exception entity thrown when <see cref="CloudStorageAccount"/> doesn't exist.
    /// </summary>
    public class CloudStorageNotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageNotFoundException"/> class.
        /// </summary>
        public CloudStorageNotFoundException()
            : this("Storage account not found")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public CloudStorageNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner <see cref="Exception"/> instance.</param>
        public CloudStorageNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageNotFoundException"/> class.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> instance.</param>
        /// <param name="context"><see cref="StreamingContext"/> instance.</param>
        protected CloudStorageNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}