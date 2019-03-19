using System;

using Xamarin.Forms;

namespace WheresMyKombucha
{
    public class CrushFinderPage : ContentPage
    {
        int _counter = 0;
        Label _resultLabel = new Label();

        #region Constructor
        public CrushFinderPage()
        {
            //InitializeComponent(); Commenting this line ignores the Xaml file
            var headingLabel = new Label()
            {
                Text = "Crush Finder",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            var crushNameEntry = new Entry();
            crushNameEntry.Placeholder = "Type Your Crush's Name Here...";
            var crushFinderButton = new Button();
            crushFinderButton.Text = "Find Out If She Likes You";
            _resultLabel.TextColor = Color.Red;
            crushFinderButton.Clicked += PerformClickFunctionality;

            var stackLayout = new StackLayout()
            {
                Children = { headingLabel, crushNameEntry, crushFinderButton, _resultLabel },
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Content = stackLayout;
        }
        #endregion

        void PerformClickFunctionality(object sender, EventArgs e)
        {
            _counter++;
            switch (_counter)
            {
                case 1:
                    _resultLabel.Text = "Nah she ain't into you.";
                    break;
                case 2:
                case 3:
                case 4:
                    _resultLabel.Text = "You can stop already!";
                    break;
                default:
                    _resultLabel.Text = "Clicking Isn't Going to Help you know";
                    break;
            }
        }
    }
}

