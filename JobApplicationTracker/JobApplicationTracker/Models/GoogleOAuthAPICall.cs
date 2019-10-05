namespace JobApplicationTracker.Models
{

    public class GoogleOAuthAPICall
    {
        #region Properties
        /// <summary>
        /// Authorization code required to fetch token 
        /// </summary>
        public string code { get; set; }
        #endregion
        #region OAuthAPICallParameters
        public readonly string client_ID = "916830414475-s4k2akkfdvvpcpc5keoohiehq5ivek54.apps.googleusercontent.com";
        public readonly string client_secret = "_vpx0zefNUloXImPwMl1Nzk6";
        public readonly string redirect_uri = "http://localhost:49855/Home/Login";
        public readonly string grant_type = "authorization_code";
        #endregion
    }
}