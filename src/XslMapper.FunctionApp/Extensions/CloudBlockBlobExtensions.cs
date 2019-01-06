using System.Threading.Tasks;

using Aliencube.XslMapper.FunctionApp.Exceptions;

using Microsoft.WindowsAzure.Storage.Blob;

namespace Aliencube.XslMapper.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="CloudBlockBlob"/> class.
    /// </summary>
    public static class CloudBlockBlobExtensions
    {
        /// <summary>
        /// Gets the <see cref="CloudBlockBlob"/> instance.
        /// </summary>
        /// <param name="container"><see cref="Task{CloudBlobContainer}"/> instance.</param>
        /// <param name="directory">Directory name in the container.</param>
        /// <param name="filename">Filename of the blob.</param>
        /// <returns><see cref="CloudBlockBlob"/> instance.</returns>
        public static async Task<CloudBlockBlob> GetBlockBlobAsync(this Task<CloudBlobContainer> container, string filename, string directory = null)
        {
            var instance = await container.ConfigureAwait(false);
            var blobName = directory.IsNullOrWhiteSpace() ? filename : $"{directory}/{filename}";
            var blob = instance.GetBlockBlobReference(blobName);

            var exists = await blob.ExistsAsync().ConfigureAwait(false);
            if (!exists)
            {
                throw new BlobNotFoundException();
            }

            return blob;
        }
    }
}