FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DiffApi/DiffApi.csproj", "DiffApi/"]
RUN dotnet restore "DiffApi/DiffApi.csproj"
COPY . .
WORKDIR "/src/DiffApi"
RUN dotnet build "DiffApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiffApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiffApi.dll"]
