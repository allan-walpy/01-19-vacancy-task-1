using System.Collections.Generic;
using Xunit;

namespace App.Server.Test.Data
{
    public class BaseTheoryData<TKey, TValue> : TheoryData<TKey>
    {
        public BaseTheoryData(IDictionary<TKey, TValue> list)
        {
            foreach(var item in list)
            {
                Add(item.Key);
            }
        }
    }
}