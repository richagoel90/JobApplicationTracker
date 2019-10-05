using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationTracker.Models
{
    public class GoogleTokenResponse
    {
        #region Properties
        /// <summary>
        /// Access_Token used to get data from Google API
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// Token Expiry value
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// Type of token
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// Refresh Token is used to access API offline
        /// </summary>
        public string refresh_token { get; set; }
        #endregion
    }
}
