FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ShopAction/ShopAction.Web/*.csproj ./ShopAction/ShopAction.Web/
COPY ShopAction/ShopAction.Application/*.csproj ./ShopAction/ShopAction.Application/
COPY ShopAction/ShopAction.Infrastructure/*.csproj ./ShopAction/ShopAction.Infrastructure/
COPY ShopAction/ShopAction.Domain/*.csproj ./
COPY ShopAction/ShopAction.CrossCutting/*.csproj ./ShopAction/ShopAction.CrossCutting/
RUN dotnet restore "ShopAction/ShopAction.Web/ShopAction.Web.csproj"
COPY . .
WORKDIR /src/ShopAction/ShopAction.Web
RUN dotnet build "ShopAction.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopAction.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopAction.Web.dll"]