using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer4.Events
{
    /// <summary>
    /// Event for failure token revocation
    /// </summary>
    /// <seealso cref="IdentityServer4.Events.Event" />
    public class TokenRevokedFailureEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRevokedFailureEvent"/> class.
        /// </summary>
        /// <param name="requestResult">The request result.</param>
        /// <param name="client">The client.</param>
        public TokenRevokedFailureEvent(TokenRevocationRequestValidationResult requestResult, Client client)
            : base(EventCategories.Token,
                  "Token Revoked Failure",
                  EventTypes.Failure,
                  EventIds.TokenRevokedFailure,
                  string.Format("Error revoking token {0} {1}", requestResult.TokenTypeHint, requestResult.Token))
        {
            ClientId = client.ClientId;
            ClientName = client.ClientName;
            TokenType = requestResult.TokenTypeHint;
            // Token = Obfuscate(requestResult.Token);
            Token = requestResult.Token;
        }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>
        /// The name of the client.
        /// </value>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}