    namespace JobApplicationTracker.Models
{
    public class GoogleOAuthParameters
    {
        #region OAuthParamenters
        public readonly string response_type ="code";
        public readonly string client_id = "916830414475-s4k2akkfdvvpcpc5keoohiehq5ivek54.apps.googleusercontent.com";
        public readonly string client_secret = "_vpx0zefNUloXImPwMl1Nzk6";
        public readonly string redirect_uri = "https://localhost:44373/Authentication/OAuthCallback";
        public readonly string scope = "https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fgmail.readonly+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.profile";
        public readonly string prompt = "consent";
        public readonly string access_type = "offline";
        public readonly string url = "https://accounts.google.com/o/oauth2/v2/auth?";
        #endregion
    }
}   