#!/bin/bash

## tests app;
##   must be launched from root repository folder;

echo "Listing tests"

dotnet test -c Release -t

echo "Doing tests"

dotnet test -c Release --no-restore --no-build --verbosity n