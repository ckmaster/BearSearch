FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TestHarness_NETCore_ASP/TestHarness_NETCore_ASP.csproj TestHarness_NETCore_ASP/
RUN dotnet restore TestHarness_NETCore_ASP/TestHarness_NETCore_ASP.csproj
COPY . .
WORKDIR /src/TestHarness_NETCore_ASP
RUN dotnet build TestHarness_NETCore_ASP.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TestHarness_NETCore_ASP.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestHarness_NETCore_ASP.dll"]
