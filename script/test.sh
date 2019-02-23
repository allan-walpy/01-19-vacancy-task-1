#!/bin/bash

## tests app;
##   must be launched from root repository folder;

echo "Building app"

dotnet build -c Release

echo "Listing tests"

dotnet test -c Release --no-build --no-restore -t

echo "Doing tests"

dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.GetAllTest" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.GetTest" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.AddTest" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.DeleteTest" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.UpdateTest.Valid200Title" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.UpdateTest.Valid200Description" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.UpdateTest.Valid200Salary" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.UpdateTest.Valid200ContactPhone" --configuration Release --no-restore --no-build --verbosity n
dotnet test --filter FullyQualifiedName~"Walpy.VacancyApp.Test.Api.Vacancy.UpdateTest.Valid200ContactPerson" --configuration Release --no-restore --no-build --verbosity n