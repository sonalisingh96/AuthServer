using IdentityServer4.Models;
using System.Collections.Generic;
using GrantTypes = IdentityServer4.Models.GrantTypes;
using IdentityServer4.Test;
using static IdentityServer4.IdentityServerConstants;

public class Config
{
    public static List<TestUser> GetUsers()
    {
        return new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "0001",
                Username = "sonali",
                Password = "singh",
            },
            new TestUser
            {
                SubjectId = "0002",
                Username = "sanchit",
                Password = "kumar",
            }
        };
    }


    public static IEnumerable<ApiResource>GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("api", "My API")
        };
    }


    public static IEnumerable<Client>GetClients()
    {
        return new List<Client>
        {
            new Client
            {
                ClientName = "Api client Name", //Image Gallery
                ClientId = "resourceOwner", //imagegalleryclient
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 120,
                AllowOfflineAccess = true,
                UpdateAccessTokenClaimsOnRefresh = true,
                 AllowedScopes =
                    {
                    "api"
                     },
                  ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
            }
        };
    }
 
 }


