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
    /// A link between a user and a tag.
    /// </summary>
    public class UserLink
    {

        /// <summary>
        /// The user id.
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        /// The date and time the link was created.
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// The state of the link.
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// The tag id.
        /// </summary>
        public int tag_id { get; set; }
    }
}
