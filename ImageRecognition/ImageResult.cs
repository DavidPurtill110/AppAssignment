using System;
using System.Collections.Generic;

namespace ImageRecognition
{
    public class ImageResult
    {
        public ImageResult()
        {

        }
        // gets and sets for description
        public string Description { get; set; }

        // gets and sets for list of tags
        public List<string> Tags { get; set; }
    }
}
