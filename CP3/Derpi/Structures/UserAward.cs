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
    /// A user badge.
    /// </summary>
    public class UserAward
    {
        /// <summary>
        /// The image url for the badge.
        /// </summary>
        public string image_url { get; set; }

        /// <summary>
        /// The title of the badge.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The id of the badge.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Flavor text for the badge.
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// The date and time the badge was awarded to the user.
        /// </summary>
        public string awarded_on { get; set; }
    }
}
