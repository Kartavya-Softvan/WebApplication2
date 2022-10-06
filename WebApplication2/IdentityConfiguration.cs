using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
        //new TestUser
        //{
        //    SubjectId = "1144",
        //    Username = "mukesh",
        //    Password = "mukesh",
        //    Claims =
        //    {
        //        new Claim(JwtClaimTypes.Name, "Mukesh Murugan"),
        //        new Claim(JwtClaimTypes.GivenName, "Mukesh"),
        //        new Claim(JwtClaimTypes.FamilyName, "Murugan"),
        //        new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
        //        //new Claim(JwtClaimTypes.Scope,"api1"),
        //        new Claim(JwtClaimTypes.Role,"api")
        //    }
        //},
        new TestUser
        {
            SubjectId = "1145",
            Username = "admin",
            Password = "admin",
            Claims =
            {
                new Claim(JwtClaimTypes.Name, "Admin admin"),
                new Claim(JwtClaimTypes.GivenName, "admin"),
                new Claim(JwtClaimTypes.FamilyName, "admin"),
                new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
                //new Claim(JwtClaimTypes.Scope,"api1"),
                new Claim(JwtClaimTypes.Role,"admin")
            }
        }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
        new ApiScope("myApi.read"),
        new ApiScope("myApi.write"),
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
        new ApiResource("myApi")
        {
            Scopes = new List<string>{ "myApi.read","myApi.write" },
            ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
        }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read", "myApi.write", JwtClaimTypes.Role }
                    //AllowedScopes = { "myApi.read","myApi.write" },
                    //Claims={new Claim(ClaimTypes.Role,"admin") }
                },
            };
    }
}
