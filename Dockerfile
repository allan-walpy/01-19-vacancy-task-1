FROM microsoft/dotnet:2.2.103-sdk AS build
WORKDIR /

# copy configuration
COPY src/appsettings.private.docker.json ./src/appsettings.private.json

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/*.csproj ./src/
RUN dotnet restore src

# copy everything else and build app
COPY src/. ./src/
RUN dotnet publish -c Release -o out/docker src

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
COPY --from=build /out/docker ./
ENTRYPOINT ["dotnet", "App.Server.dll"]