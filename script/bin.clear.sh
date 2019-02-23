#!/bin/bash

## clears all genereted by dotnet files
##   must be launched from root repository folder;


echo "--- deleting files ---";

#? remove all generated files;
sudo rm -r -f ./out

#? remove `obj` of server project;
sudo rm -r -f ./src/all/obj

#? remove `obj` of test project;
sudo rm -r -f ./test/obj

echo "--- done ---";
