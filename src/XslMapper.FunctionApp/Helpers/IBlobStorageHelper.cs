using System;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage.Blob;

namespace Aliencube.XslMapper.FunctionApp.Helpers
{
    /// <summary>
    /// This provides interfaces to the <see cref="BlobStorageHelper"/> class.
    /// </summary>
    public interface IBlobStorageHelper : IDisposable
    {
        /// <summary>
        /// Loads blob from the give blob container.
        /// </summary>
        /// <param name="container">Blob container name.</param>
        /// <param name="directory">Directory name in the container.</param>
        /// <param name="filename">Filename of the blob.</param>
        /// <returns><see cref="CloudBlockBlob"/> instance.</returns>
        Task<CloudBlockBlob> LoadBlobAsync(string container, string directory, string filename);
    }
}