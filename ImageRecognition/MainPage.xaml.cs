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

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() {PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium });
                var stream = photo.GetStream();
               // if (photo != null)
                  //  Preview.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

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
