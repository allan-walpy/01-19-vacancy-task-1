using System.Collections.Generic;

using App.Server.Models.Requests;
using App.Server.Models;

namespace App.Server.Test.Data
{
    public static class DefaultData
    {
        public static List<VacancyAddRequest> VacancyData
            => new List<VacancyAddRequest>
            {
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    Salary = 15000,
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        Surname = "Милов",
                        MiddleName = "Андреевич"
                    },
                    ContactPhone = "8 (960) 444-33-42"
                },
                new VacancyAddRequest
                {
                    Title = "Кок",
                    Description = "Варить лапшу на корбале",
                    Organization = "OOO \"Shipping Food Industries\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Стажёр младший разработчик на .Net C# Beginner .Net C# Developer",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на: .Net C#; /(Junior Dev)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    Salary = null
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    Salary = 0
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Кок",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    Salary = 1_000_000_000
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipisc a",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"(Not) Suspicious -42 Организация\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "ООО",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious Gaming Industry LLC Never Trust Me 12345678\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FixedScheldure", "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "RemoteMethod", "FixedScheldure", "FullTime" }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = null
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Андрей"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Андрей",
                        Surname = "Милов",
                        MiddleName = "Сергеевич"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Оля"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "АьбдурахманНоДлиннее"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Andrew-Андрей"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        Surname = null
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        Surname = "Мил"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        Surname = "АьбдурахманНоДлиннее"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        Surname = "Smith-Смит"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        MiddleName = null
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        MiddleName = "Мил"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        MiddleName = "АьбдурахманНоДлиннее"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPerson = new Person
                    {
                        Name = "Сергей",
                        MiddleName = "Egor-Егорович"
                    }
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPhone = null
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPhone = "8 (903) 222-33-42"
                },
                new VacancyAddRequest
                {
                    Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                    Description = "Писать программы и т.д.",
                    Organization = "OOO \"Not Suspicious\"",
                    EmploymentType = new List<string> { "FullTime" },
                    ContactPhone = "8 (4842) 22-33-42"
                }
            };
    }
}