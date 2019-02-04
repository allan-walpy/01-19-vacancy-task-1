using System.Collections.Generic;

namespace App.Server.Test.Data
{
    public class BadModelDataItem
    {
        public ICollection<string> InvalidFields { get; set; }
        public object RequestData { get; set; }
    }
}