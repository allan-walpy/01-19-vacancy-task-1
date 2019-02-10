using System.Collections.Generic;
using System.Linq;

using Walpy.VacancyApp.Server.Models;
using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Test.Data
{
    public static class DefaultData
    {
        public static List<VacancyAddRequest> VacancyData
            => VacancyAddData201.Values.ToList();

        public static Dictionary<string, VacancyAddRequest> VacancyAddData201
            => new Dictionary<string, VacancyAddRequest>
            {
                {
                    "Request.Requered",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\""
                    }
                },
                {
                    "Request.All",
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
                    }
                },
                {
                    "Title.3minLength",
                    new VacancyAddRequest
                    {
                        Title = "Кок",
                        Description = "Варить лапшу на корбале",
                        Organization = "OOO \"Shipping Food Industries\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "Title.64maxLength",
                    new VacancyAddRequest
                    {
                        Title = "Стажёр младший разработчик на .Net C# Beginner .Net C# Developer",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "Title.AllowedSymbols",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на: .Net C#; /(Junior Dev)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "Slary.CanBeNull",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        Salary = null
                    }
                },
                {
                    "Salary.Min0",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        Salary = 0
                    }
                },
                {
                    "Description.Max1_000_000_000_000",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Кок",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        Salary = 1_000_000_000_000
                    }
                },
                {
                    "Description.3minLength",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Кок",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        Salary = 5000
                    }
                },
                {
                    "Description.4096maxValue",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipisc a",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "Organization.AllowedSymbolsRegex",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"(Not) Suspicious -42 Организация\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "Organization.3minLength",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "ООО",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "Organization.64maxLength",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious Gaming Industry LLC Never Trust Me 12345678\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "EmploymentType.Null",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = null
                    }
                },
                {
                    "EmploymentType.Empty",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { }
                    }
                },
                {
                    "EmploymentType.OptionCount.1",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" }
                    }
                },
                {
                    "EmploymentType.OptionsCount.2",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FixedScheldure", "FullTime" }
                    }
                },
                {
                    "EmploymentType.OptionsCount.3",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "RemoteMethod", "FixedScheldure", "FullTime" }
                    }
                },
                {
                    "EmploymentType.OptionsCount.0",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { }
                    }
                },
                {
                    "ContactPerson.CanBeNull",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        ContactPerson = null
                    }
                },
                {
                    "ContactPerson.RequiredOnly",
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
                    }
                },
                {
                    "ContactPerson.AllFields",
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
                    }
                },
                {
                    "ContactPerson.Name.3minLength",
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
                    }
                },
                {
                    "ContactPerson.Name.20maxLength",
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
                    }
                },
                {
                    "ContactPerson.Name.AllowedSymbols",
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
                    }
                },
                {
                    "ContactPerson.Surname.CanBeNull",
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
                    }
                },
                {
                    "ContactPerson.Surname.3minLength",
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
                    }
                },
                {
                    "ContactPerson.Surname.20maxLength",
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
                    }
                },
                {
                    "ContactPerson.Surname.AllowedSymbols",
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
                    }
                },
                {
                    "ContactPerson.MiddleName.CanBeNull",
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
                    }
                },
                {
                    "ContactPerson.MiddleName.3minLength",
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
                    }
                },
                {
                    "ContactPerson.MiddleName.20maxLength",
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
                    }
                },
                {
                    "ContactPerson.MiddleName.AllowedSymbols",
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
                    }
                },
                {
                    "ContactPhone.CanBeNull",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        ContactPhone = null
                    }
                },
                {
                    "ContactPhone.ValidMobile",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        ContactPhone = "8 (903) 222-33-42"
                    }
                },
                {
                    "ContactPhone.ValidHomePhone",
                    new VacancyAddRequest
                    {
                        Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                        Description = "Писать программы и т.д.",
                        Organization = "OOO \"Not Suspicious\"",
                        EmploymentType = new List<string> { "FullTime" },
                        ContactPhone = "8 (4842) 22-33-42"
                    }
                }
            };

        public static Dictionary<string, BadModelDataItem> VacancyAddData400
            => new Dictionary<string, BadModelDataItem>
            {
                {
                    "Title.Required",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Title" },
                        RequestData = new
                        {
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Title.RequiredNotNull",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Title" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = null,
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Title.2less3length",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Title" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "да",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"Not Suspicious\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Title.65more64length",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Title" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)no smoke",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"Not Suspicious\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Title.RegexForbidSymbol",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Title" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Мл@дший разработчик на .Net c# (Junior .Net Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"Not Suspicious\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Organization.Required",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Organization" },
                        RequestData = new
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Organization.RequiredNotNull",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Organization" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = null,
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Organization.65more64length",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Organization" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"Not Suspicious Gaming Industry LLC Never Trust Me 123456789\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Organization.2less3minLength",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Organization" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OO",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Organization.RegexForbidSymbol",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Organization" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"C# proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Description.Required",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Description" },
                        RequestData = new
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Description.RequiredNotNull",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Description" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = null,
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Description.4097more4096maxLength",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Description" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diem nonummy nibh euismod tincidunt ut lacreet dolore magna aliguam erat volutpat. Ut wisis enim ad minim veniam, quis nostrud exerci tution ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetuer adipisc an",
                            Organization = "OOO \"CSharp proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "Description.2less3minLength",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Description" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "ОО",
                            Organization = "OOO \"CSharp proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" }
                        }
                    }
                },
                {
                    "EmploymentType.NotEmploymentTypeItem",
                    new BadModelDataItem {
                        InvalidFields = new [] { "EmploymentType" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "NotFullTime" }
                        }
                    }
                },
                {
                    "Salary.-1Less0",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Salary" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            Salary = -1
                        }
                    }
                },
                {
                    "Salary.1_000_000_000_001More1_000_000_000_000",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Salary" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            Salary = 1_000_000_000_001
                        }
                    }
                },
                {
                    "Salary.NotANumber",
                    new BadModelDataItem {
                        InvalidFields = new [] { "Salary" },
                        RequestData = new
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            Salary = "от 12000 до 15000 рублей"
                        }
                    }
                },
                {
                    "ContactPerson.Name.Required",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPerson" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPerson = new Person
                            {
                                Surname = "Милов",
                                MiddleName = "Андреевич"
                            }
                        }
                    }
                },
                {
                    "ContactPerson.Name.21more20length",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPerson" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPerson = new Person
                            {
                                Name = "АьбдурахманНоДлиннеее",
                                Surname = "Милов",
                                MiddleName = "Андреевич"
                            }
                        }
                    }
                },
                {
                    "ContactPerson.Name.ForbidSymbol",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPerson" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPerson = new Person
                            {
                                Name = "Аьбдурахман Но Нет",
                                Surname = "Милов",
                                MiddleName = "Андреевич"
                            }
                        }
                    }
                },
                {
                    "ContactPerson.Surname.21more20length",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPerson" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPerson = new Person
                            {
                                Name = "Сергей",
                                Surname = "АьбдурахманНоДлиннеее",
                                MiddleName = "Андреевич"
                            }
                        }
                    }
                },
                {
                    "ContactPerson.Surname.ForbidSymbol",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPerson" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPerson = new Person
                            {
                                Name = "Аьбдурахман",
                                Surname = "Милов Да нет",
                                MiddleName = "Андреевич"
                            }
                        }
                    }
                },
                {
                    "ContactPerson.MiddleName.21more20length",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPerson" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPerson = new Person
                            {
                                Name = "Сергей",
                                Surname = "Милов",
                                MiddleName = "АьбдурахманНоДлиннеее"
                            }
                        }
                    }
                },
                {
                    "ContactPerson.MiddleName.ForbidSymbol",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPerson" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPerson = new Person
                            {
                                Name = "Аьбдурахман",
                                Surname = "Милов",
                                MiddleName = "Андреевич вроде"
                            }
                        }
                    }
                },
                {
                    "ContactPhone.NoFormatting",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPhone" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPhone = "89064441244"
                        }
                    }
                },
                {
                    "ContactPhone.PlussFormatting",
                    new BadModelDataItem {
                        InvalidFields = new [] { "ContactPhone" },
                        RequestData = new VacancyAddRequest
                        {
                            Title = "Младший разработчик на .Net C# (Junior .Net C# Developer)",
                            Description = "Писать программы и т.д.",
                            Organization = "OOO \"CSHARP proffesionals\"",
                            EmploymentType = new List<string> { "FullTime" },
                            ContactPhone = "+79064441244"
                        }
                    }
                }
        };
    }
}