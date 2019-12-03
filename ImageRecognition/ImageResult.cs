using System;
using System.Collections.Generic;

namespace ImageRecognition
{
    public class ImageResult
    {
        public ImageResult()
        {

        }
        public string Description { get; set; }

        public List<string> Tags { get; set; }
    }
}
