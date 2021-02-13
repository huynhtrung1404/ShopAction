FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY src/ShopAction.Web/*.csproj ./src/ShopAction.Web/
COPY src/ShopAction.Application/*.csproj ./src/ShopAction.Application/
COPY src/ShopAction.Infrastructure/*.csproj ./src/ShopAction.Infrastructure/
COPY src/ShopAction.Domain/*.csproj ./src/ShopAction.Domain/
RUN dotnet restore "src/ShopAction.Web/ShopAction.Web.csproj"
COPY . .
WORKDIR "/src/src/ShopAction.Web"
RUN dotnet build "ShopAction.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopAction.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopAction.Web.dll"]