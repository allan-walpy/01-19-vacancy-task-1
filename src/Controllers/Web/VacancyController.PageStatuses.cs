using System.Collections.Generic;

using App.Server.Models.Web.Vacancy;

namespace App.Server.Controllers.Web
{
    partial class VacancyController
    {
        private const string NotFoundStatusDataKey = "404";

        private static readonly IReadOnlyDictionary<string, IndexPageStatus> PageStatusData
            = new Dictionary<string, IndexPageStatus>
            {
                {
                    NotFoundStatusDataKey,
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Вакансия с идентификационным номером {0} не найдена"
                    }
                },
                {
                    $"{nameof(Create)}:true",
                    new IndexPageStatus
                    {
                        Success = true,
                        Message = "Вакансия создана успешно. Ей присвоен индентификационный номер {0}"
                    }
                },
                {
                    $"{nameof(Create)}:false",
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Что-то полшо не так при создании вакансии"
                    }
                },
                {
                    $"{nameof(Edit)}:true",
                    new IndexPageStatus
                    {
                        Success = true,
                        Message = "Вакансия обновлена успешно"
                    }
                },
                {
                    $"{nameof(Edit)}:false",
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Что-то пошло не так при обновлении вкансии"
                    }
                },
                {
                    $"{nameof(Delete)}:true",
                    new IndexPageStatus
                    {
                        Success = true,
                        Message = "Вакансия успешно удалена"
                    }
                },
                {
                    $"{nameof(Delete)}:false",
                    new IndexPageStatus
                    {
                        Success = false,
                        Message = "Что-то пошло не так при удалении вакансии"
                    }
                }
            };
    }
}