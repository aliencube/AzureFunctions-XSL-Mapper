using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.DependencyInjection;
using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Aliencube.XslMapper.FunctionApp.Functions;
using Aliencube.XslMapper.FunctionApp.Models;
using Aliencube.XslMapper.FunctionApp.Modules;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Aliencube.XslMapper.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for XML to XML transformation.
    /// </summary>
    public static class XmlToXmlMapperHttpTrigger
    {
        /// <summary>
        /// Gets the <see cref="IFunctionFactory"/> instance.
        /// </summary>
        public static IFunctionFactory Factory { get; set; } = new FunctionFactory(new AppModule());

        /// <summary>
        /// Invokes the HTTP trigger.
        /// </summary>
        /// <param name="req"><see cref="HttpRequestMessage"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns><see cref="HttpResponseMessage"/> instance.</returns>
        [FunctionName(nameof(XmlToXmlMapperHttpTrigger))]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "mappers/xml/xml")] HttpRequestMessage req,
            ILogger log)
        {
            var result = (HttpResponseMessage)null;
            try
            {
                result = await Factory.Create<IXmlToXmlMapperFunction, ILogger>(log)
                                      .InvokeAsync<HttpRequestMessage, HttpResponseMessage>(req)
                                      .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var statusCode = HttpStatusCode.InternalServerError;
                var response = new ErrorResponse((int)statusCode, ex.Message, ex.StackTrace);

                result = req.CreateResponse(statusCode, response);
            }

            return result;
        }
    }
}