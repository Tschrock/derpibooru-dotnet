//-----------------------------------------------------------------------
// <copyright>
//     This Source Code Form is subject to the terms of the Mozilla Public
//     License, v. 2.0. If a copy of the MPL was not distributed with this
//     file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>
//-----------------------------------------------------------------------

namespace CP3.Derpi
{

    /// <summary>
    /// A Derpibooru User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The url slug for the user.
        /// </summary>
        public string slug { get; set; }

        /// <summary>
        /// The role of the user.
        /// </summary>
        public string role { get; set; }

        /// <summary>
        /// The user's profile description.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// The url for the user's avatar.
        /// </summary>
        public string avatar_url { get; set; }

        /// <summary>
        /// The date and time the user was created.
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// The number of comments the user has made.
        /// </summary>
        public int comment_count { get; set; }

        /// <summary>
        /// The number of pictures the user has uploaded.
        /// </summary>
        public int uploads_count { get; set; }

        /// <summary>
        /// The number of forum posts the user has made.
        /// </summary>
        public int post_count { get; set; }

        /// <summary>
        /// The number of forum topics the user has started.
        /// </summary>
        public int topic_count { get; set; }

        /// <summary>
        /// A list of user links for the user.
        /// </summary>
        public UserLink[] links { get; set; }

        /// <summary>
        /// A list of badges the user has been awarded.
        /// </summary>
        public UserAward[] awards { get; set; }
    }
}
