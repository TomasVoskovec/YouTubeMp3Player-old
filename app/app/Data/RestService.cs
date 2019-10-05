﻿using app.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace app.Data
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<Token> Login(User user)
        {
            // Form user login data to post
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("email", user.Email));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));

            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

            // Get request token
            Token token = await PostResponseLogin(Constants.LoginUrl, content);

            return token;
        }

        public async Task<Token> PostResponseLogin(string webUrl, FormUrlEncodedContent content)
        {
            HttpResponseMessage response = await client.PostAsync(webUrl, content);
            string jsonResult = response.Content.ReadAsStringAsync().Result;
            Token token = JsonConvert.DeserializeObject<Token>(jsonResult);

            return token;
        }

        public async Task<User> ValidateToken(Token token)
        {
            // Form token data to post
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("jwt", token.AccessToken));

            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

            // Get user data
            User user = await PostResponseValidateToken(Constants.ValidateTokenUrl, content);

            return user;
        }

        public async Task<User> PostResponseValidateToken(string webUrl, FormUrlEncodedContent content)
        {
            HttpResponseMessage response = await client.PostAsync(webUrl, content);
            string jsonResult = response.Content.ReadAsStringAsync().Result;
            User user = JsonConvert.DeserializeObject<User>(jsonResult);

            return user;
        }
    }
}
