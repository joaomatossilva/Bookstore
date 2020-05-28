FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Bookstore.Web/Bookstore.Web.csproj", "Bookstore.Web/"]
RUN dotnet restore "Bookstore.Web/Bookstore.Web.csproj"
COPY . .
WORKDIR "/src/Bookstore.Web"
RUN dotnet build "Bookstore.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bookstore.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookstore.Web.dll"]