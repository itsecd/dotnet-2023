FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaxiDepo.Server/TaxiDepo.Server.csproj", "TaxiDepo.Server/"]
RUN dotnet restore "TaxiDepo.Server/TaxiDepo.Server.csproj"
COPY . .
WORKDIR "/src/TaxiDepo.Server"
RUN dotnet build "TaxiDepo.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxiDepo.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxiDepo.Server.dll"]
