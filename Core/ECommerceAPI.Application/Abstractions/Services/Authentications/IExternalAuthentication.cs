using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dto = ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<dto.Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
        Task<dto.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
