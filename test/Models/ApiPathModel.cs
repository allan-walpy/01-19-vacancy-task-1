using System;

namespace App.Server.Test.Models
{
    public class ApiPathModel
    {
        public const string PathUrlTemplate = "http://localhost:5002/api/{0}/{1}";

        public string BasePath { get; set; }

        public string AdditionalPath { get; set; }

        public override string ToString()
            => String.Format(
                PathUrlTemplate,
                BasePath,
                AdditionalPath ?? String.Empty);
    }
}