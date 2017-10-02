using IdentityServer4.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace IdentityServer4.Endpoints.Results
{
    /// <summary>
    /// Result for revocation
    /// </summary>
    /// <seealso cref="IdentityServer4.Hosting.IEndpointResult" />
    public class TokenRevocationResult : IEndpointResult
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        /// <value>
        /// The error description.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRevocationResult"/> class.
        /// </summary>
        /// <param name="code">Result code.</param>
        /// <param name="message">Result message.</param>
        public TokenRevocationResult(string code, string message)
        {
            Code = code;
            Message = message;
        }
        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        public Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            return context.Response.WriteJsonAsync(new { code = Code, message = Message });
        }
    }
}