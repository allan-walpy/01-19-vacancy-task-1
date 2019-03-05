#!/bin/bash

## tests app;
##   must be launched from root repository folder;

echo "Building app"

dotnet build -c Release

echo "Listing tests"

dotnet test -c Release --no-build --no-restore -t

echo "Doing tests"

dotnet test --configuration Release --no-restore --no-build --verbosity n