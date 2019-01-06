using System;
using System.Linq;
using System.Text;

namespace Aliencube.XslMapper.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The object to format.</param>
        /// <returns>A copy of format in which any format items are replaced by the string representation of arg0.</returns>
        public static string Format(this string format, object arg0)
        {
            return format.Format(new[] { arg0 });
        }

        /// <summary>
        /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string Format(this string format, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (!args.Any())
            {
                return format;
            }

            var result = string.Format(format, args);

            return result;
        }

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><c>true</c> if the value parameter is <c>null</c> or <see cref="System.String.Empty"/>, or if value consists exclusively of white-space characters.</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            var result = string.IsNullOrWhiteSpace(value);

            return result;
        }

        /// <summary>
        /// Converts the specified string representation of a logical value to its Boolean equivalent.
        /// </summary>
        /// <param name="value">A string that contains the value of either <see cref="System.Boolean.TrueString"/> or <see cref="System.Boolean.FalseString"/>.</param>
        /// <returns><c>true</c> if value equals <see cref="System.Boolean.TrueString"/>, or <c>false</c> if value equals <see cref="System.Boolean.FalseString"/>, <c>null</c> or <see cref="System.String.Empty"/>.</returns>
        public static bool ToBoolean(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return false;
            }

            var result = Convert.ToBoolean(value);

            return result;
        }

        /// <summary>
        /// Checks whether the given string value is the same as the comparer, regardless of their casing.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <param name="comparer">Value to be compared.</param>
        /// <returns><c>true</c>, if both values are the same as each other, regardless of their casing; otherwise returns <c>false</c>.</returns>
        public static bool IsEquivalentTo(this string value, string comparer)
        {
            var result = value.Equals(comparer, StringComparison.CurrentCultureIgnoreCase);

            return result;
        }

        /// <summary>
        /// Checks whether the given string value ends with the comparer, regardless of their casing.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <param name="comparer">Value to be compared.</param>
        /// <returns><c>true</c>, if the given value ends with the comparer, regardless of their casing; otherwise returns <c>false</c>.</returns>
        public static bool EndsWidthEquivalent(this string value, string comparer)
        {
            var result = value.EndsWith(comparer, StringComparison.CurrentCultureIgnoreCase);

            return result;
        }

        /// <summary>
        /// Converts the base64-encoded string into normal string value.
        /// </summary>
        /// <param name="value">Base64-encoded string.</param>
        /// <returns>Converted string.</returns>
        public static string FromBase64String(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return null;
            }

            var bytes = Convert.FromBase64String(value);
            var result = Encoding.UTF8.GetString(bytes);

            return result;
        }
    }
}
