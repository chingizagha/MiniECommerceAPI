using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dto = ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<dto.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<dto.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
