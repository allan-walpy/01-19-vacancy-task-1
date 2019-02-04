using System.Collections.Generic;

namespace App.Server.Test.Data
{
    public class BadModelData : BaseTheoryData<string, BadModelDataItem>
    {
        public BadModelData(IDictionary<string, BadModelDataItem> list)
            : base(list)
        { }
    }
}