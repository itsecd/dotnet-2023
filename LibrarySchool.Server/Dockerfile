FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LibrarySchool.Server/LibrarySchool.Server.csproj", "LibrarySchool.Server/"]
COPY ["LibrarySchool.Domain/LibrarySchool.Domain.csproj", "LibrarySchool.Domain/"]
RUN dotnet restore "LibrarySchool.Server/LibrarySchool.Server.csproj"
COPY . .
WORKDIR "/src/LibrarySchool.Server"
RUN dotnet build "LibrarySchool.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibrarySchool.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY temp/* ./temp/

# Set the environment variables for HTTPS
ENV ASPNETCORE_URLS=https://+:443;http://+:80
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=Password
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/temp/key.pfx


ENTRYPOINT ["dotnet", "LibrarySchool.Server.dll"]

# Command to build image and run container:
# 1. Create a certificate to run on https: 
# dotnet dev-certs https -ep ./temp/key.pfx -p Password
# dotnet dev-certs https --trust
# 2. Build image:
# docker compose build
# 3. Run container:
# docker compose up
# Web app server run on https://localhost:7097