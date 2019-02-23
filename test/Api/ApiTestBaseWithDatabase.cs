using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

using Walpy.VacancyApp.Server.All.Models.Requests;
using Walpy.VacancyApp.Server.All.Models.Responses;
using Walpy.VacancyApp.Test.Models;

namespace Walpy.VacancyApp.Test.Api
{
    public abstract class ApiTestBaseWithDatabase : ApiTestBase
    {
        protected ApiClient DatabaseAddClient { get; }

        protected List<string> DatabaseGuids { get; }

        protected ApiTestBaseWithDatabase(List<VacancyAddRequest> database)
        {
            DatabaseGuids = PopulateDatabase(database);
        }

        protected List<string> PopulateDatabase(List<VacancyAddRequest> database)
            => database.ConvertAll((item) => {
                var request = new HttpMessageModel();
                request.Data = item;
                var response = SendRequest(request, HttpMethod.Post, "vacancy");
                var addResponse = JsonConvert.DeserializeObject<VacancyAddResponse>(response.Data as string);
                return addResponse.Id;
            });

        protected List<VacancyResponse> GetItems()
        {
            var request = new HttpMessageModel();
            var response = SendRequest(request, HttpMethod.Get, "vacancy");
            var getAllResponse = JsonConvert.DeserializeObject<VacancyGetAllResponse>(response.Data as string);
            return getAllResponse.List;
        }
    }
}