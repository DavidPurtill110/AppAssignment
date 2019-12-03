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
            var credentials = new ApiKeyServiceClientCredentials("391c3dc5c5d449c3ac19a7f8cff686e1");
            azureImageAnalyzer = new ComputerVisionClient(credentials) { Endpoint = "https://northeurope.api.cognitive.microsoft.com/" };
        }

        public async Task<ImageResult> AnalyzeImage(Stream imageData)
        {
            var visualFetures = new System.Collections.Generic.List<VisualFeatureTypes>
            {
                VisualFeatureTypes.Description,
                VisualFeatureTypes.Tags
            };
            var imageRes = await azureImageAnalyzer.AnalyzeImageInStreamAsync(imageData, visualFetures);
            var result = new ImageResult();
            result.Description = imageRes.Description.Captions[0].Text;
            var tags = new List<string>();
            foreach (var Tag in imageRes.Tags)
            {
                tags.Add(Tag.Name);
            }
            result.Tags = tags;
            
            return result;
        }
    }
}
