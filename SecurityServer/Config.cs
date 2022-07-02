// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace StsServerIdentity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("taler_api", "Scope for the taler_api ApiResource"),
                new ApiScope("gatherr_api", "Scope for the gatherr_api ApiResource"),
                new ApiScope("hooray_Api", "Scope for the hooray_Api ApiResource"),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                // example code
                new ApiResource("talerApi")
                {
                    ApiSecrets =
                    {
                        new Secret("talerApiSecret".Sha256())
                    },
                    Scopes = new List<string> { "taler_api" },
                    UserClaims = { "role", "admin", "user", "talerApiSecret", "talerApiSecret.admin", "talerApiSecret.user" }
                },
                // example code
                new ApiResource("gatherrapi")
                {
                    ApiSecrets =
                    {
                        new Secret("gatherrapiSecret".Sha256())
                    },
                    Scopes = new List<string> { "gatherr_api" },
                    UserClaims = { "role", "admin", "user", "gatherrapiSecret", "gatherrapiSecret.admin", "gatherrapiSecret.user" }
                },
                 // example code
                new ApiResource("hoorayApi")
                {
                    ApiSecrets =
                    {
                        new Secret("hoorayApiSecret".Sha256())
                    },
                    UserClaims = { "role", "admin", "user", "hoorayApiSecret", "hoorayApiSecret.admin", "hoorayApiSecret.user" }
                },
            };
        }

        public static IEnumerable<Client> GetClients(IConfigurationSection stsConfig)
        {
            // TODO use configs in app
            //var yourConfig = stsConfig["ClientUrl"];

            return new List<Client>
            {
                new Client
                {
                    ClientName = "Code Flow PKCE",
                    ClientId = "angularClient",
                    AccessTokenType = AccessTokenType.Reference,
                    // RequireConsent = false,
                    AccessTokenLifetime = 900,// 900 seconds, default 60 minutes
                    IdentityTokenLifetime = 600,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4200",
                        "https://localhost:4200/silent-renew.html",
                        "https://localhost:4205",
                        "https://localhost:4205/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4200/unauthorized",
                        "https://localhost:4200",
                        "https://localhost:4205/unauthorized",
                        "https://localhost:4205"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4200",
                        "https://localhost:4205"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "role",
                        "profile",
                        "email"
                    }
                },

                new Client
                {
                    ClientName = "Code Flow PKCE Reference Token",
                    ClientId = "talerClient",
                    AccessTokenType = AccessTokenType.Reference,
                    // RequireConsent = false,
                    AccessTokenLifetime = 900,// 900 seconds, default 60 minutes
                    IdentityTokenLifetime = 600,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4200",
                        "https://localhost:4200/silent-renew.html",
                        "https://localhost:4201",
                        "https://localhost:4201/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4200/unauthorized",
                        "https://localhost:4200",
                        "https://localhost:4201/unauthorized",
                        "https://localhost:4201"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4200",
                        "https://localhost:4201"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "role",
                        "profile",
                        "email",
                        "taler_api",
                         IdentityServerConstants.StandardScopes.OfflineAccess
                    }
                },
                new Client
                {
                    ClientName = "Implicit Flow Reference Token",
                    ClientId = "angularImplicitClient",
                    AccessTokenType = AccessTokenType.Reference,
                    // RequireConsent = false,
                    AccessTokenLifetime = 900,// 900 seconds, default 60 minutes
                    IdentityTokenLifetime = 600,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4202",
                        "https://localhost:4202/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4202/unauthorized",
                        "https://localhost:4202"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4202"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "role",
                        "profile",
                        "email"
                    }
                },
                new Client
                {
                    ClientName = "Implicit Flow JWT Token",
                    ClientId = "angularJwtClient",
                    AccessTokenType = AccessTokenType.Jwt,
                    // RequireConsent = false,
                    AccessTokenLifetime = 900,// 900 seconds, default 60 minutes
                    IdentityTokenLifetime = 600,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4203",
                        "https://localhost:4203/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4203/unauthorized",
                        "https://localhost:4203"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4203"
                    },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "role",
                        "profile",
                        "email"
                    }
                },
                new Client
                {
                    ClientName = "Code Flow Refresh Tokens(Code with PKCE)",
                    ClientId = "angularCodeRefreshTokens",

                    AccessTokenLifetime = 900,// 900 seconds, default 60 minutes
                    IdentityTokenLifetime = 600,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4204",
                        "https://localhost:4206"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4204/unauthorized",
                        "https://localhost:4204",
                        "https://localhost:4206/unauthorized",
                        "https://localhost:4206"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4204",
                        "https://localhost:4206"
                    },

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowedScopes = { 
                        "openid", 
                        "profile", 
                        "email", 
                        "taler_api",
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly
                 },

                new Client
                {
                    ClientName = "gatherrapi app",
                    ClientId = "gatherrapp",

                    AccessTokenLifetime = 900,// 900 seconds, default 60 minutes
                    IdentityTokenLifetime = 600,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4200",
                        "http://localhost/callback", // electron,
                        "https://localhost/callback",  // electron
                        "https://proud-island-014203c10.azurestaticapps.net",
                        "gatherrapp://localhost",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4200/unauthorized",
                        "https://localhost:4200",
                        "https://proud-island-014203c10.azurestaticapps.net",
                        "gatherrapp://callback",
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4200",
                        "https://proud-island-014203c10.azurestaticapps.net",
                        "gatherrapp://localhost"
                    },

                    RequireClientSecret = false,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowedScopes = { "openid", "profile", "email", "gatherr_api",
                        IdentityServerConstants.StandardScopes.OfflineAccess  },
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                 },

                 new Client
                {
                    ClientName = "Code Flow with refresh tokens",
                    ClientId = "angularClientForHoorayApi",

                    AccessTokenLifetime = 900,// 900 seconds, default 60 minutes
                    IdentityTokenLifetime = 600,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4200"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4200/unauthorized",
                        "https://localhost:4200"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4200"
                    },

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowedScopes = { 
                         "openid", 
                         "profile", 
                         "email", 
                         "hooray_Api", 
                         IdentityServerConstants.StandardScopes.OfflineAccess 
                     },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly
                },
            };
        }
    }
}