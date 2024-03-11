using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace minibank_client_api.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;

        //public JwtMiddleware(RequestDelegate next, IConfiguration config)
        //{
        //    _next = next;
        //    _secret = config.GetSection("AppSettings").Value??"test";
        //}

        //public async Task Invoke(HttpContext context, IUserService userService)
        //{
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        //    if (token != null)
        //        attachUserToContext(context, userService, token);

        //    await _next(context);
        //}

        //private void attachUserToContext(HttpContext context, IUserService userService, string token)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(_secret);
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //            ClockSkew = TimeSpan.Zero
        //        }, out SecurityToken validatedToken);

        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //        var clientId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

        //        // attach user to context on successful jwt validation
        //        context.Items["client"] = userService.GetById(clientId);
        //    }
        //    catch
        //    {
        //        // do nothing if jwt validation fails
        //    }
        //}
    }
}