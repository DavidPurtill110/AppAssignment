using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CognitiveServices.Vision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace ImageRecognition
{
    public class ImageAnalyzer
    {
        private ComputerVisionClient azureImageAnalyzer;
        public ImageAnalyzer()
        {
            // getting my api key from Mircosoft Azure and the startpoint
            var credentials = new ApiKeyServiceClientCredentials("391c3dc5c5d449c3ac19a7f8cff686e1");
            // and the end point for the image to be analyzed and sent back from the api
            azureImageAnalyzer = new ComputerVisionClient(credentials) { Endpoint = "https://northeurope.api.cognitive.microsoft.com/" };
        }

        public async Task<ImageResult> AnalyzeImage(Stream imageData)
        {
            // using a list to gather the information to be displayed on the main page
            var visualFetures = new System.Collections.Generic.List<VisualFeatureTypes>
            {
                // sending back the description and tags of the image
                VisualFeatureTypes.Description,
                VisualFeatureTypes.Tags
            };


            var imageRes = await azureImageAnalyzer.AnalyzeImageInStreamAsync(imageData, visualFetures);
            var result = new ImageResult();
            result.Description = imageRes.Description.Captions[0].Text;
            // overloading the list to pass description and tags to the list
            var tags = new List<string>();
            foreach (var Tag in imageRes.Tags)
            {
                tags.Add(Tag.Name);
            }
            result.Tags = tags;
            // returning the result of the description and tags from the foreach loop
            return result;
        }
    }
}
