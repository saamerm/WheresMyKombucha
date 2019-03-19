using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace WheresMyKombucha
{
    public class KombuchaPage : ContentPage
    {
        string AccessToken = "e54ec36b6b139319129d8cd075cb88f095a9dce7";
        Label _resultLabel = new Label()
        {
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };

        public KombuchaPage()
        {
            var ChangeLedCommandOn = new Command<string>(LedOn);
            var ChangeLedCommandOff = new Command<string>(LedOff);
            var onButton = new Button { Text = "Full", Command = ChangeLedCommandOn };
            var offButton = new Button { Text = "Empty", Command = ChangeLedCommandOff };
            Title = "Where's My Kombucha";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to the World's First Essential Kombucha Notifier App!"
                    },
                    onButton,
                    offButton,
                    _resultLabel
                }
            };
            GetKombuchaStatus();
        }

        #region Private Functions
        private void LedOn(string changeValue = "on")
        {
            changeValue = "on";
            string accessToken = AccessToken; //This is your Particle Cloud Access Token
            string deviceId = "28003d001847343338333633"; //This is your Particle Device Id
            string partilceFunc = "led"; //This is the name of your Particle Function

            HttpClient client = new HttpClient
            {
                BaseAddress =
                new Uri("https://api.particle.io/")
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("access_token", accessToken),
                new KeyValuePair<string, string>("args", changeValue )
            });

            var result = client.PostAsync("v1/devices/" + deviceId + "/" + partilceFunc, content);
            _resultLabel.TextColor = Color.Blue;
            _resultLabel.Text = "The Kombucha is here!";
            ResultLabelUpdate(1);
        }
        private void LedOff(string changeValue = "off")
        {
            changeValue = "off";
            string accessToken = AccessToken; //This is your Particle Cloud Access Token
            string deviceId = "28003d001847343338333633"; //This is your Particle Device Id
            string partilceFunc = "led"; //This is the name of your Particle Function

            HttpClient client = new HttpClient
            {
                BaseAddress =
                new Uri("https://api.particle.io/")
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("access_token", accessToken),
                new KeyValuePair<string, string>("args", changeValue )
            });

            var result = client.PostAsync("v1/devices/" + deviceId + "/" + partilceFunc, content);
            ResultLabelUpdate(0);
        }
        private void ResultLabelUpdate(int status = -1)
        {
            if (status == 1)
            {
                _resultLabel.TextColor = Color.Blue;
                _resultLabel.Text = "The Kombucha is here!";
                BackgroundColor = Color.SkyBlue;
            }
            else if (status == 0)
            {
                _resultLabel.TextColor = Color.Red;
                _resultLabel.Text = "Rats! The Kombucha is gone again";
                BackgroundColor = Color.LightGray;
            }
            else
            {
                _resultLabel.Text = "Kombucha Status: Unknown";
                BackgroundColor = Color.LightYellow;
            }
        }
        private void GetKombuchaStatus()
        {
            string deviceId = "28003d001847343338333633"; //This is your Particle Device Id
            string accessToken = AccessToken; //This is your Particle Cloud Access Token
            HttpClient client = new HttpClient();
            var url = string.Format("https://api.particle.io/v1/devices/{0}/digitalValue?access_token={1}", deviceId, AccessToken);
            var json = client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<ParticleResponse>(json.Result);
            ResultLabelUpdate(result.result);
        }
        #endregion
    }

    public class CoreInfo
    {
        public string last_app { get; set; }
        public DateTime last_heard { get; set; }
        public bool connected { get; set; }
        public DateTime last_handshake_at { get; set; }
        public string deviceID { get; set; }
        public int product_id { get; set; }
    }

    public class ParticleResponse
    {
        public string cmd { get; set; }
        public string name { get; set; }
        public int result { get; set; }
        public CoreInfo coreInfo { get; set; }
    }
}

