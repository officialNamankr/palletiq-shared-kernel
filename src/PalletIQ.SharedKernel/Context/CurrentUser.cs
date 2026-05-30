using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using PalletIQ.SharedKernel.Abstractions;
using PalletIQ.SharedKernel.Constants;

namespace PalletIQ.SharedKernel.Context
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;


        public Guid UserId => Guid.TryParse(User?.FindFirst(PalletIQClaims.Subject)?.Value, out var userId) ? userId : Guid.Empty;

        public Guid TenantId => Guid.TryParse(User?.FindFirst(PalletIQClaims.TenantId)?.Value, out var tenantId) ? tenantId : Guid.Empty;

        public string Email => User?.FindFirst(PalletIQClaims.Email)?.Value ?? string.Empty;

        public string FullName => User?.FindFirst(PalletIQClaims.FullName)?.Value ?? string.Empty;

        public IReadOnlyList<string> Roles => throw new NotImplementedException();

        public string Plan => throw new NotImplementedException();  

        public bool IsAuthenticated => throw new NotImplementedException();

        public bool IsInAnyRole(params string[] roles)
        {
            throw new NotImplementedException();
        }

        public bool IsInRoles(string role)
        {
            throw new NotImplementedException();
        }
    }
}
