using System.Collections.Generic;
using System.Net.Http;

using App.Server.Models.Requests;
using App.Server.Test.Models;

namespace App.Server.Test.Api
{
    public abstract class ApiTestBaseWithDatabase : ApiTestBase
    {
        protected ApiClient DatabaseAddClient { get; }

        protected ApiTestBaseWithDatabase(List<VacancyAddRequest> database)
        {
            PopulateDatabase(database);
        }

        protected void PopulateDatabase(List<VacancyAddRequest> database)
        {
            database.ForEach((item) => {
                var request = new HttpMessageModel();
                request.Data = item;
                SendRequest(request, HttpMethod.Post, "vacancy");
            });
        }
    }
}