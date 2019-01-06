using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.XslMapper.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for <see cref="byte"/>.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Checks whether the byte array starts with the given byte array values or not.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <param name="values">Byte array to check.</param>
        /// <returns><c>True</c>, if the byte array starts with the values; otherwise returns <c>False</c>.</returns>
        public static bool StartsWith(this byte[] bytes, byte[] values)
        {
            var result = false;
            for (var i = 0; i < values.Length; i++)
            {
                result |= bytes[i] == values[i];
            }

            return result;
        }

        /// <summary>
        /// Checks whether the byte array starts with BOM or not.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <returns><c>True</c>, if the byte array starts with BOM; otherwise returns <c>False</c>.</returns>
        public static bool StartsWithBom(this byte[] bytes)
        {
            var bom = Encoding.UTF8.GetPreamble();

            return bytes.StartsWith(bom);
        }

        /// <summary>
        /// Removes BOM from the byte array.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <returns>Byte array that BOM has been removed.</returns>
        public static byte[] RemoveBom(this byte[] bytes)
        {
            var bom = Encoding.UTF8.GetPreamble();

            if (!bytes.StartsWith(bom))
            {
                return bytes;
            }

            bytes = bytes.Skip(bom.Length).ToArray();

            return bytes;
        }

        /// <summary>
        /// Converts the byte array into base-64 encoded string.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <returns>Base-64 encoded string.</returns>
        public static string ToBase64String(this byte[] bytes)
        {
            if (!bytes.Any())
            {
                return string.Empty;
            }

            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Converts the byte array into string.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <param name="encodeBase64">Value indicating whether to encode the output string in Base-64 or not.</param>
        /// <returns>string converted.</returns>
        public static async Task<string> ToStringAsync(this Task<byte[]> bytes, bool encodeBase64 = true)
        {
            var instance = await bytes.ConfigureAwait(false);

            if (!instance.Any())
            {
                return string.Empty;
            }

            return encodeBase64 ? Convert.ToBase64String(instance) : Encoding.UTF8.GetString(instance);
        }
    }
}