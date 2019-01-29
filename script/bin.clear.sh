#!/bin/bash

## clears all genereted by dotnet files
##   must be launched from root repository folder;


echo "--- deleting files ---";

sudo rm -r -f ./out

sudo rm -r -f ./src/obj

echo "--- done ---";