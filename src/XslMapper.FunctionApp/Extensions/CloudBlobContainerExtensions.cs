using System.Threading.Tasks;

using Aliencube.XslMapper.FunctionApp.Exceptions;

using Microsoft.WindowsAzure.Storage.Blob;

namespace Aliencube.XslMapper.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="CloudBlobContainer"/> class.
    /// </summary>
    public static class CloudBlobContainerExtensions
    {
        /// <summary>
        /// Gets the <see cref="CloudBlobContainer"/> instance.
        /// </summary>
        /// <param name="client"><see cref="CloudBlobClient"/> instance.</param>
        /// <param name="containerName">Blob container name.</param>
        /// <returns><see cref="CloudBlobContainer"/> instance.</returns>
        public static async Task<CloudBlobContainer> GetBlobContainerAsync(this CloudBlobClient client, string containerName)
        {
            var container = client.GetContainerReference(containerName);

            var exists = await container.ExistsAsync().ConfigureAwait(false);
            if (!exists)
            {
                throw new BlobContainerNotFoundException();
            }

            return container;
        }
    }
}