using Aliencube.AzureFunctions.Extensions.DependencyInjection.Abstractions;

using Microsoft.Extensions.Logging;

namespace Aliencube.XslMapper.FunctionApp.Functions
{
    /// <summary>
    /// This provides interfaces to the <see cref="XmlToXmlMapperFunction"/> class.
    /// </summary>
    public interface IXmlToXmlMapperFunction : IFunction<ILogger>
    {
    }
}