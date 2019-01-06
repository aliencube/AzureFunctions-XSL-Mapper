using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Aliencube.XslMapper.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="CloudBlobClient"/> class.
    /// </summary>
    public static class CloudBlobClientExtensions
    {
        /// <summary>
        /// Creates a <see cref="CloudBlobClient"/> instance from the <see cref="CloudStorageAccount"/> instance.
        /// </summary>
        /// <param name="account"><see cref="CloudStorageAccount"/> instance.</param>
        /// <returns><see cref="CloudBlobClient"/> instance.</returns>
        public static CloudBlobClient CreateBlobClient(this CloudStorageAccount account)
        {
            var client = account.CreateCloudBlobClient();

            return client;
        }
    }
}