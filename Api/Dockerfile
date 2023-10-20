FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["e-commerce-api/e-commerce-api.csproj", "e-commerce-api/"]
RUN dotnet restore "e-commerce-api/e-commerce-api.csproj"
COPY . .
WORKDIR "/src/e-commerce-api"
RUN dotnet build "e-commerce-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "e-commerce-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "e-commerce-api.dll"]
