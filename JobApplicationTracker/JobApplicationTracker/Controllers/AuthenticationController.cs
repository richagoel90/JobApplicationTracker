using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace JobApplicationTracker.Controllers
{
    public class AuthenticationController : Controller
    {
        /// <summary>
        /// User SignIn Action
        /// </summary>
        /// <returns> It returns ActionResult to the user</returns>
        [HttpGet]
        public IActionResult SignIn()
        {
            GoogleOAuthParameters gauth = new GoogleOAuthParameters();

            List<KeyValuePair<string, string>> requestParams = new List<KeyValuePair<string, string>>();
            requestParams.Add(new KeyValuePair<string, string>("response_type", gauth.response_type));
            requestParams.Add(new KeyValuePair<string, string>("client_id", gauth.client_id));
            requestParams.Add(new KeyValuePair<string, string>("redirect_uri", HttpUtility.UrlEncode(gauth.redirect_uri)));
            requestParams.Add(new KeyValuePair<string, string>("scope", gauth.scope));
            //requestParams.Add(new KeyValuePair<string, string>("prompt", gauth.prompt));
            requestParams.Add(new KeyValuePair<string, string>("access_type", gauth.access_type));

            StringBuilder builder = new StringBuilder();
            builder.Append(gauth.url);
            for (int i = 0; i < requestParams.Count; i++)
            {
                if (i != 0)
                {
                    builder.Append("&");
                }

                builder.Append(string.Format("{0}={1}", requestParams[i].Key, requestParams[i].Value));
            }

            return Redirect(builder.ToString());
        }

        [HttpGet]
        public async Task<ActionResult> OAuthCallback(string code)
        {
            GoogleOAuthParameters googleOAuthParameters = new GoogleOAuthParameters();

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://oauth2.googleapis.com/token");

            List<KeyValuePair<string, string>> formValues = new List<KeyValuePair<string, string>>();
            formValues.Add(new KeyValuePair<string, string>("code", code));
            formValues.Add(new KeyValuePair<string, string>("client_id", googleOAuthParameters.client_id));
            formValues.Add(new KeyValuePair<string, string>("client_secret", googleOAuthParameters.client_secret));
            formValues.Add(new KeyValuePair<string, string>("redirect_uri", googleOAuthParameters.redirect_uri));
            formValues.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            request.Content = new FormUrlEncodedContent(formValues);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                GoogleTokenResponse token = JsonConvert.DeserializeObject<GoogleTokenResponse>(responseBody);

                HttpRequestMessage userProfileRequest = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/oauth2/v2/userinfo");
                userProfileRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
                HttpResponseMessage userProfileResponse = await client.SendAsync(userProfileRequest);

                if (userProfileResponse.IsSuccessStatusCode)
                {
                    string userProfileJson = await userProfileResponse.Content.ReadAsStringAsync();
                    GoogleUserProfile userProfile = JsonConvert.DeserializeObject<GoogleUserProfile>(userProfileJson);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}