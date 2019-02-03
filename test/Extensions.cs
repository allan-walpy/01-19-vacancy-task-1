using System.Net.Http;
using Newtonsoft.Json;

namespace App.Server.Test
{
    public static class Extensions
    {
        public static T ReadAs<T>(this HttpContent content)
        {
            var stringContent = content.ReadAsStringAsync().Result;
            if (stringContent == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        public static T GetFromJson<T>(this HttpResponseMessage response)
            => response.Content.ReadAs<T>();

        public static TResponse GetAs<TResponse>(this HttpResponseMessage response)
            => response.GetFromJson<TResponse>();

        public static T UpdateIfNull<T>(T oldValue, T newValue)
            where T : class
            => oldValue == null ? newValue : oldValue;
    }
}