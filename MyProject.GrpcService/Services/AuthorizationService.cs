using Grpc.Core;
using MyProject.Services.Interfaces;

namespace MyProject.GrpcService.Services
{
    public class AuthorizationService : Authorization.AuthorizationBase
    {
        private readonly ILogger<AuthorizationService> _logger;

        public AuthorizationService(ILogger<AuthorizationService> logger)
        {
            _logger = logger;
        }

        public override Task<AuthorizationResponse> CheckAccess(AuthorizationRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Check Access");
            //get user roles
            //get claims by permission id.
            //filter claims by user roles.
            //return true if any claim has policy = allow, otherwise - return false.
            return Task.FromResult(new AuthorizationResponse()
            {
                Allow = true
            });
        }
    }
}
