#!/bin/bash

## runs app;
##   must be launched from root repository folder;

dotnet run --project ./src/server.csproj "$@"