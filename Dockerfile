#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Finances/Finances.csproj", "Finances/"]
COPY ["Finances.CrossCutting.Helper/Finances.CrossCutting.Helper.csproj", "Finances.CrossCutting.Helper/"]
COPY ["Finances.Enums/Finances.Enums.csproj", "Finances.Enums/"]
COPY ["Finances.Models/Finances.Models.csproj", "Finances.Models/"]
COPY ["Finances.ModelView/Finances.ModelView.csproj", "Finances.ModelView/"]
COPY ["Finances.Identity/Finances.Identity.csproj", "Finances.Identity/"]
COPY ["Finances.CrossCutting.DependencyInjection/Finances.CrossCutting.DependencyInjection.csproj", "Finances.CrossCutting.DependencyInjection/"]
COPY ["Finances.Services/Finances.Services.csproj", "Finances.Services/"]
COPY ["Finances.Domain/Finances.Domain.csproj", "Finances.Domain/"]
RUN dotnet restore "Finances/Finances.csproj"
COPY . .
WORKDIR "/src/Finances"
RUN dotnet build "Finances.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finances.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finances.dll"]