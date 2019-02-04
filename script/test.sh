#!/bin/bash

## tests app;
##   must be launched from root repository folder;

dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.GetAllTest" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.GetTest" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.AddTest" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.DeleteTest" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.UpdateTest.Valid200Title" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.UpdateTest.Valid200Description" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.UpdateTest.Valid200Salary" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.UpdateTest.Valid200ContactPhone" --verbosity n
dotnet test --filter FullyQualifiedName~"App.Server.Test.Api.Vacancy.UpdateTest.Valid200ContactPerson" --verbosity n