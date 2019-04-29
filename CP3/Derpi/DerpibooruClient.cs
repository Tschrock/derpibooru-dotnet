//-----------------------------------------------------------------------
// <copyright>
//     This Source Code Form is subject to the terms of the Mozilla Public
//     License, v. 2.0. If a copy of the MPL was not distributed with this
//     file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace CP3.Derpi
{
    /// <summary>
    /// A client for interacting with Derpibooru.
    /// </summary>
    public class DerpibooruClient
    {

        /// <summary>
        /// The http client for api requests.
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// The api key to use for secured or personalized requests.
        /// </summary>
        private string ApiKey;

        /// <summary>
        /// Creates a new Derpibooru api client.
        /// </summary>
        /// <param name="apiKey">The api key to use for secured or personalized requests.</param>
        public DerpibooruClient(string apiKey) : this("https://derpibooru.org/", apiKey) { }

        /// <summary>
        /// Creates a new Derpibooru api client.
        /// </summary>
        /// <param name="serverAddress">The address of the Derpibooru server.</param>
        /// <param name="apiKey">The api key to use for secured or personalized requests.</param>
        public DerpibooruClient(string serverAddress, string apiKey) : this(new Uri(serverAddress), apiKey) { }

        /// <summary>
        /// Creates a new Derpibooru api client.
        /// </summary>
        /// <param name="serverAddress">The address of the Derpibooru server.</param>
        /// <param name="apiKey">The api key to use for secured or personalized requests.</param>
        public DerpibooruClient(Uri serverAddress, string apiKey)
        {
            this.ApiKey = apiKey;
            this.client = new HttpClient();
            this.client.BaseAddress = serverAddress;
        }

        // User actions

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns>Returns the current user.</returns>
        public async Task<User> GetCurrentUser()
        {
            var response = await client.GetAsync("/api/v2/users/current.json", new QueryString { { "key", this.ApiKey } });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<User>();
        }

        /// <summary>
        /// Gets a user by their id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>Returns the user.</returns>
        public async Task<User> GetUserById(int id)
        {
            var response = await client.GetAsync("/api/v2/users/show.json", new QueryString { { "id", id } });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<User>();
        }

        /// <summary>
        /// Gets multiple users by their ids.
        /// </summary>
        /// <param name="ids">The users' ids.</param>
        /// <returns>Returns an array of users.</returns>
        public async Task<User[]> GetUsersById(int[] ids)
        {
            var response = await client.GetAsync("/api/v2/users/fetch_many.json", new QueryString { { "ids", ids } });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<User[]>();
        }

        /// <summary>
        /// Gets a user by their name.
        /// </summary>
        /// <param name="name">The user's name.</param>
        /// <returns>Returns the user.</returns>
        public async Task<User> GetUserByName(string name)
        {
            var response = await client.GetAsync(string.Format("/profiles/{0}.json", Uri.EscapeDataString(name)));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<User>();
        }

    }
}
