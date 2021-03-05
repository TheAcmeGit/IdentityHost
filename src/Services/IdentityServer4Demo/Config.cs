using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4Demo
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
           new List<IdentityResource>
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("ApiResourse1", "ApiResourse1NoScope"){

                 Scopes=new []{ "api1" }
              
                },
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "My API",new []{JwtClaimTypes.Role }),
                new ApiScope("ApiResourse1", "My ApiResourse1NoScope"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                // new Client
                // {
                //     ClientId = "mvc",
                //     ClientSecrets = { new Secret("secret".Sha256()) },

                //     AllowedGrantTypes = GrantTypes.Code,

                //     // where to redirect to after login
                //     RedirectUris = { "https://localhost:5002/signin-oidc" },

                //     // where to redirect to after logout
                //     PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                //        AllowOfflineAccess = true,

                //     AllowedScopes = new List<string>
                //     {
                //         IdentityServerConstants.StandardScopes.OpenId,
                //         IdentityServerConstants.StandardScopes.Profile,
                //         "api1",
                //         "ApiResourse1",
                //     }
                // },
                //  new Client
                //{
                //  ClientId = "vuejs4",
                //    ClientName = "JavaScript Client",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AllowAccessTokensViaBrowser = true,
                   

                //    RedirectUris = { "http://localhost:8080/#/CallBack#" },
                //    PostLogoutRedirectUris = { "http://localhost:8080 " },
                //    AllowedCorsOrigins = { "http://localhost:8080" },
                //    AlwaysIncludeUserClaimsInIdToken=false,
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "api1"
                //    },
                //},
                  new Client
                    {
                        ClientId = "vuejs5",
                        ClientName = "JavaScript Client",
                        //ClientSecrets=new []{ new Secret("secret".Sha256())},
                        RequireClientSecret=false,
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris = {
                         "http://localhost:9527/#/callback",
                         "http://localhost:9527/#/refreshtoken",

                      },
                        PostLogoutRedirectUris = { "http://localhost:9527 " },
                        AllowedCorsOrigins = { "http://localhost:9527" },
                        AlwaysIncludeUserClaimsInIdToken=false,
                        AllowOfflineAccess=true,
                        AccessTokenLifetime=90,
                        IdentityTokenLifetime=300,
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1"
                        },
                    },
                   new Client
                    {
                        ClientId = "element_admin",
                        ClientName = "测试",
                        //ClientSecrets=new []{ new Secret("secret".Sha256())},
                        RequireClientSecret=false,
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris = {
                         "http://localhost:8080/#/callback",
                         "http://localhost:8080/#/refresh",

                      },
                        PostLogoutRedirectUris = { "http://localhost:8080 " },
                        AllowedCorsOrigins = { "http://localhost:8080" },
                        AlwaysIncludeUserClaimsInIdToken=false,
                        AllowOfflineAccess=true,
                        AccessTokenLifetime=3600,
                        IdentityTokenLifetime=3600,
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1"
                        },
                    }
            };
    }
}