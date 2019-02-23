using System.Collections.Generic;

namespace Walpy.VacancyApp.Test.Data
{
    public class BadModelDataItem
    {
        public ICollection<string> InvalidFields { get; set; }
        public object RequestData { get; set; }
    }
}