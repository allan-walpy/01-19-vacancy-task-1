using System.Collections.Generic;

using Walpy.VacancyApp.Server.All.Controllers.Web;

namespace Walpy.VacancyApp.Server.All.Models.Web.Vacancy
{
    public static class VacancyIndexPageStatuses
    {
        public const string NotFoundKey = "404";

        public static readonly IReadOnlyDictionary<string, IndexPageStatus> Data
            = new Dictionary<string, IndexPageStatus>
            {
                {
                    NotFoundKey.ToLower(),
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Вакансия с идентификационным номером {0} не найдена"
                    }
                },
                {
                    $"{nameof(VacancyController.Create)}:true".ToLower(),
                    new IndexPageStatus
                    {
                        Success = true,
                        Message = "Вакансия создана успешно. Ей присвоен индентификационный номер {0}"
                    }
                },
                {
                    $"{nameof(VacancyController.Create)}:false".ToLower(),
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Что-то полшо не так при создании вакансии"
                    }
                },
                {
                    $"{nameof(VacancyController.Edit)}:true".ToLower(),
                    new IndexPageStatus
                    {
                        Success = true,
                        Message = "Вакансия обновлена успешно"
                    }
                },
                {
                    $"{nameof(VacancyController.Edit)}:false".ToLower(),
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Что-то пошло не так при обновлении вкансии"
                    }
                },
                {
                    $"{nameof(VacancyController.Delete)}:true".ToLower(),
                    new IndexPageStatus
                    {
                        Success = true,
                        Message = "Вакансия успешно удалена"
                    }
                },
                {
                    $"{nameof(VacancyController.Delete)}:false".ToLower(),
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Что-то пошло не так при удалении вакансии"
                    }
                }
            };
    }
}