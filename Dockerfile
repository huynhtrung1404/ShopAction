FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY src/ShopAction.Api/ShopAction.Api.csproj ./src/ShopAction.Api/
COPY src/ShopAction.ViewModels/ShopAction.ViewModels.csproj ./src/ShopAction.ViewModels/
COPY src/ShopAction.Data/ShopAction.Data.csproj ./src/ShopAction.Data/
COPY src/ShopAction.Utilities/ShopAction.Utilities.csproj ./src/ShopAction.Utilities/
COPY src/ShopAction.ApplicationService/ShopAction.ApplicationService.csproj ./src/ShopAction.ApplicationService/
RUN dotnet restore "src/ShopAction.Api/ShopAction.Api.csproj"
COPY . .
WORKDIR "/src/src/ShopAction.Api"
RUN dotnet build "ShopAction.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopAction.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopAction.Api.dll"]