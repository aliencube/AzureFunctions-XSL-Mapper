using Newtonsoft.Json;

namespace Aliencube.XslMapper.FunctionApp.Models
{
    /// <summary>
    /// This represents the response entity for error.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="details">Error details.</param>
        public ErrorResponse(int statusCode, string message, string details = null)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Details = details;
        }

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        [JsonProperty(Order = 1)]
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the error details.
        /// </summary>
        [JsonProperty(Order = 3)]
        public string Details { get; set; }
    }
}
