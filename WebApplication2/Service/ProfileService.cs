

using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication2.Service
{
    public class ProfileService : IProfileService
    {
        //private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        //private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService()
        {
            //_userManager = userManager;
            //_claimsFactory = claimsFactory;
        }

        //public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        //{
        //    //>Processing
        //    var sub = context.Subject.GetSubjectId();
        //    var user = await _userManager.FindByIdAsync(sub);
        //    var principal = await _claimsFactory.CreateAsync(user);

        //    var claims = principal.Claims.ToList();
        //    claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

        //    // Add custom claims in token here based on user properties or any other source

        //    if (context.Client.ClientId == "cwm.client")
        //    {
        //        claims.Add(new Claim("role", "testAPI"));
        //    }
        //    if (context.Client.ClientId == "awm.client")
        //    {
        //        claims.Add(new Claim("role", "liveAPI"));
        //    }
        //}

        //public async Task IsActiveAsync(IsActiveContext context)
        //{
        //    var sub = context.Subject.GetSubjectId();
        //    var user = await _userManager.FindByIdAsync(sub);
        //    context.IsActive = user != null;
        //}

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims.Add(new Claim("role", "admin"));
            //return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.FromResult(0);
        }
    }
}
