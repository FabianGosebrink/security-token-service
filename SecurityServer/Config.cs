// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

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
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "taler_api",
                            DisplayName = "Scope for the taler ApiResource"
                        }
                    },
                    UserClaims = { "role", "admin", "user", "talerApiSecret", "talerApiSecret.admin", "talerApiSecret.user" }
                },
                // example code
                new ApiResource("gettogetherapi")
                {
                    ApiSecrets =
                    {
                        new Secret("gettogetherapiSecret".Sha256())
                    },
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "gettogether_api",
                            DisplayName = "Scope for the getogether ApiResource"
                        }
                    },
                    UserClaims = { "role", "admin", "user", "gettogetherapiSecret", "gettogetherapiSecret.admin", "gettogetherapiSecret.user" }
                },
                 // example code
                new ApiResource("hoorayApi")
                {
                    ApiSecrets =
                    {
                        new Secret("hoorayApiSecret".Sha256())
                    },
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "hooray_Api",
                            DisplayName = "Scope for the hoorayApi Resource"
                        }
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
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 30,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4200",
                        "https://localhost:4200/silent-renew.html"
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
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 30,

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
                        "taler_api"
                    }
                },
                new Client
                {
                    ClientName = "Implicit Flow Reference Token",
                    ClientId = "angularImplicitClient",
                    AccessTokenType = AccessTokenType.Reference,
                    // RequireConsent = false,
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 30,

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
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 30,

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

                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 45,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4204"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:4204/unauthorized",
                        "https://localhost:4204"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:4204"
                    },

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowedScopes = { "openid", "profile", "email", "taler_api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly
                 },

                new Client
                {
                    ClientName = "get together app",
                    ClientId = "gettogetherapp",

                    AccessTokenLifetime = 660,
                    IdentityTokenLifetime = 600,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4200",
                        "http://localhost/callback", // electron,
                        "https://localhost/callback" // electron
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
                    AllowedScopes = { "openid", "profile", "email", "gettogether_api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                 },

                 new Client
                {
                    ClientName = "Code Flow with refresh tokens",
                    ClientId = "angularClientForHoorayApi",

                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 45,

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
                    AllowedScopes = { "openid", "profile", "email", "hooray_Api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly
                },
            };
        }
    }
}