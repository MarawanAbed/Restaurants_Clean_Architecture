﻿

using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.User
{
    public class UserContext(IHttpContextAccessor httpContextAccessor)
    {
        public CurrentUser? GetCurrentUser() 
        {
        
            var user = httpContextAccessor.HttpContext?.User;
            if (user == null) 
            {
                throw new InvalidOperationException("User context  is not present.");
            }
            if(user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }
            var userId = user.FindFirst(c=>c.Type== ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = user.FindAll(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            return new CurrentUser(userId , email , roles);
        }
    }
   
}
