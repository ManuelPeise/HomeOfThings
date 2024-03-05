#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Web.Core/Web.Core.csproj", "Web.Core/"]
COPY ["Data.Interfaces/Data.Interfaces.csproj", "Data.Interfaces/"]
COPY ["Date.Models/Date.Models.csproj", "Date.Models/"]
COPY ["Database.HotContext/Database.HotContext.csproj", "Database.HotContext/"]
COPY ["Logic.Administration/Logic.Administration.csproj", "Logic.Administration/"]
COPY ["Logic.Shared/Logic.Shared.csproj", "Logic.Shared/"]
COPY ["Data.Ressources/Data.Ressources.csproj", "Data.Ressources/"]
COPY ["Service.Administration/Service.Administration.csproj", "Service.Administration/"]
COPY ["Service.Shared/Service.Shared.csproj", "Service.Shared/"]
COPY ["Service.UserService/Service.UserService.csproj", "Service.UserService/"]
COPY ["Logic.UserService/Logic.UserService.csproj", "Logic.UserService/"]
RUN dotnet restore "./Web.Core/Web.Core.csproj"
COPY . .
WORKDIR "/src/Web.Core"
RUN dotnet build "./Web.Core.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.Core.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Core.dll"]