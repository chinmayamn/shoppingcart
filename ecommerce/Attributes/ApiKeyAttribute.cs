using System.Web.Http.Filters;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Security.Principal;

namespace ecommerce.Attributes
{
    public class ApiKeyAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Authorization", request);
                return;
            }
            if (authorization.Scheme != "Bearer" && authorization.Scheme != "Basic")
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid Authorization Scheme", request);
                return;
            }

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Token", request);
                return;
            }


            bool checkToken = await ValidateTokenAsync(authorization.Scheme,authorization.Parameter);
            if (!checkToken)
                context.ErrorResult = new AuthenticationFailureResult("Invalid Token", request);
            return;
        }
        private Task<bool> ValidateTokenAsync(string scheme, string parameter)
        {
            //TO DO: Validate Token
            if (scheme == "Bearer")
            {
                if (parameter == "123456")
                    return Task.FromResult(true);
                else
                    return Task.FromResult(false);
            }
            else if(scheme=="Basic")
            {
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(parameter));
                string userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

                //if user is authenticated set principal
                var identity = new GenericIdentity(userName);
                SetPrincipal(new GenericPrincipal(identity, null));
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            if (context.Result is AuthenticationFailureResult)
            {
                var challenge = new AuthenticationHeaderValue[]
                {
                    new AuthenticationHeaderValue("Bearer","<token>")
                };
                context.Result = new UnauthorizedResult(challenge, context.Request);
                return Task.FromResult(context.Result);
            }
            else
                return Task.FromResult(0);
        
         }

        private static void SetPrincipal(IPrincipal principal)
        {
            // setting.   
            Thread.CurrentPrincipal = principal;
            // Verification.   
            if (HttpContext.Current != null)
            {
                // Setting.   
                HttpContext.Current.User = principal;
            }
        }
        //private const string APIKEYNAME = "ApiKey";
        //public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
        //    {
        //        context.Result = new ContentResult()
        //        {
        //            StatusCode = 401,
        //            Content = "Api Key was not provided"
        //        };
        //        return;
        //    }

        //    var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        //    var apiKey = appSettings.GetValue<string>(APIKEYNAME);

        //    if (!apiKey.Equals(extractedApiKey))
        //    {
        //        context.Result = new ContentResult()
        //        {
        //            StatusCode = 401,
        //            Content = "Api Key is not valid"
        //        };
        //        return;
        //    }

        //    await next();
        //}
    }

    public class AuthenticationFailureResult : IHttpActionResult
    {
        private string ReasonPhrase;
        private HttpRequestMessage Request;

        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            this.ReasonPhrase = reasonPhrase;
            this.Request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            response.ReasonPhrase = ReasonPhrase;
            return Task.FromResult(response);
        }
    }
}