using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationTracker.Models
{
    public class GoogleUserProfile
    {
        #region PropertiesOfUser
        /// <summary>
        /// ID received from Google User Profile
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Name of the User
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Given Name of the User
        /// </summary>
        public string given_name { get; set; }
        /// <summary>
        /// Family Name of the User
        /// </summary>
        public string family_name { get; set; }
        /// <summary>
        /// URL of the picture of the User
        /// </summary>
        public string picture { get; set; }
        /// <summary>
        /// Language used by the User
        /// </summary>
        public string locale { get; set; }
        #endregion

    }
}
