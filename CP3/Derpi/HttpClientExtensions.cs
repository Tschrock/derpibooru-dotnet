//-----------------------------------------------------------------------
// <copyright>
//     This Source Code Form is subject to the terms of the Mozilla Public
//     License, v. 2.0. If a copy of the MPL was not distributed with this
//     file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CP3.Derpi
{

    /// <summary>
    /// Some helpful extensions for HttpClient.
    /// </summary>
    public static class HttpClientExtensions
    {

        /// <summary>
        /// Preforms an async GET request for the given resource.
        /// </summary>
        /// <param name="client">The HttpClient.</param>
        /// <param name="requestUri">The uri of the resource.</param>
        /// <param name="queryParameters">The query parameters for the request.</param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> GetAsync(this HttpClient client, string requestUri, QueryString queryParameters)
        {
            return client.GetAsync(requestUri + "?" + queryParameters.Build());
        }

    }

}
