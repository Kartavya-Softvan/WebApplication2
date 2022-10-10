using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Filter
{
    public class CustomPolicyAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public CustomPolicyAttribute(params string[] customPolicies)
        {
            this.CustomPolicies = customPolicies;
        }

        public string[] CustomPolicies { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User == null)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            string policy = context.HttpContext.User.FindFirstValue("policy");
            if (!CustomPolicies.Contains(policy))
            {
                Console.WriteLine("UnAuthorize API");
                context.Result = new StatusCodeResult(401);
            }

        }
    }
}
