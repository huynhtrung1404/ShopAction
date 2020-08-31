#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ShopAction.Api/ShopAction.Api.csproj", "ShopAction.Api/"]
COPY ["ShopAction.ViewModels/ShopAction.ViewModels.csproj", "ShopAction.ViewModels/"]
COPY ["ShopAction.Data/ShopAction.Data.csproj", "ShopAction.Data/"]
COPY ["ShopAction.Utilities/ShopAction.Utilities.csproj", "ShopAction.Utilities/"]
COPY ["ShopAction.ApplicationService/ShopAction.ApplicationService.csproj", "ShopAction.ApplicationService/"]
RUN dotnet restore "ShopAction.Api/ShopAction.Api.csproj"
COPY . .
WORKDIR "/src/ShopAction.Api"
RUN dotnet build "ShopAction.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopAction.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopAction.Api.dll"]