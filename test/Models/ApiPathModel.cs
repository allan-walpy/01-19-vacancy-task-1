using System;

namespace Walpy.VacancyApp.Server.Test.Models
{
    public class ApiPathModel
    {
        public const string PathUrlTemplate = "{0}/{1}";

        public string BasePath { get; set; }

        public string AdditionalPath { get; set; }

        public override string ToString()
            => String.Format(
                PathUrlTemplate,
                BasePath,
                AdditionalPath ?? String.Empty);
    }
}