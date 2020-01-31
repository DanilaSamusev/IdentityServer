using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        //Defining the InMemory Clients
        public static IEnumerable<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            //Client
            clients.Add(new Client()
            {
                ClientId = "Client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,               
                RequireClientSecret = false,
                AllowOfflineAccess = false,
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,  
                    IdentityServerConstants.StandardScopes.Profile,
                    //userId"
                }
            });
           
            return clients;
        }

        //Defining the InMemory API's
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> apiResources = new List<ApiResource>();

            apiResources.Add(new ApiResource("api1", "First API"));

            return apiResources;
        }

        //Defining the InMemory User's
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "admin",
                    Password = "password",                    
                },                
            };
        }

        //Support for OpenId connectivity scopes
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            List<IdentityResource> resources = new List<IdentityResource>();

            resources.Add(new IdentityResources.OpenId()); // Support for the OpenId    
            resources.Add(new IdentityResources.Profile());
            //resources.Add(new IdentityResource("userId", new List<string> { "userId" }));

            return resources;
        }
    }
}