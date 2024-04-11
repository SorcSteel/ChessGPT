//using OpenAI;
//using OpenAI.Proxy;
//using System.Security.Authentication;

//namespace ChessGPT.API
//{
//    public class AuthenticationFilter : AbstractAuthenticationFilter
//    {
//        public override void ValidateAuthentication(IHeaderDictionary request)
//        {
//            var userToken = new OpenAIClient(OpenAIAuthentication.LoadFromPath("appsettings.json"));
//            // You will need to implement your own class to properly test
//            // custom issued tokens you've setup for your end users.
//            if (!request.Authorization.ToString().Contains(userToken))
//            {
//                throw new AuthenticationException("User is not authorized");
//            }
//        }
//    }
//}
