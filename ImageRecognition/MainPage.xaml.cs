using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageRecognition
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // button to take and analyze the image.
        // also saving the image with this button.
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            // try catch for an error i was getting with this snippet of code({PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium}) 
            //for the image been to big it was causing a bad request error
            try
            {
                // setting the size for the image and saving it to the phone gallery 
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() {PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium, SaveToAlbum = true });
                var stream = photo.GetStream();

                // calling back the image taken with the camera to be viewed on the screen
                Preview.Source = photo.Path;
                var analyzer = new ImageAnalyzer();
                var data = await analyzer.AnalyzeImage(stream);
                ImgDescription.Text = data.Description;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
