#!/bin/bash

## refreshes dependencies at dotnet;
##   must be launched from root repository folder;

echo "--- clearing out files ---";

./script/bin.clear.sh

echo "--- restoring files ---";

cd src/ || exit 1;

dotnet restore

echo "--- done ---";