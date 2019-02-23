using System.Collections.Generic;

namespace Walpy.VacancyApp.Server.Test.Data
{
    public class BadModelData : BaseTheoryData<string, BadModelDataItem>
    {
        public BadModelData(IDictionary<string, BadModelDataItem> list)
            : base(list)
        { }
    }
}