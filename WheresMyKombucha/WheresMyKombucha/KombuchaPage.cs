using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace WheresMyKombucha
{
    public class KombuchaPage : ContentPage
    {
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
                VerticalOptions = LayoutOptions.Center,
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
        }

        public void LedOn(string changeValue = "on")
        {
            changeValue = "on";
            string accessToken = "e54ec36b6b139319129d8cd075cb88f095a9dce7"; //This is your Particle Cloud Access Token
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
        }
        public void LedOff(string changeValue = "off")
        {
            changeValue = "off";
            string accessToken = "e54ec36b6b139319129d8cd075cb88f095a9dce7"; //This is your Particle Cloud Access Token
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
            _resultLabel.TextColor = Color.Red;
            _resultLabel.Text = "Rats! The Kombucha is gone again";
        }
    }
}

