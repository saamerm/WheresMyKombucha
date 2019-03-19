using System;

using Xamarin.Forms;

namespace WheresMyKombucha
{
    public class CrushFinderPage : ContentPage
    {
        public CrushFinderPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

