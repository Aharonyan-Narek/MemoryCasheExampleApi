#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MemoryCasheExampleApi/MemoryCasheExampleApi.csproj", "MemoryCasheExampleApi/"]
RUN dotnet restore "MemoryCasheExampleApi/MemoryCasheExampleApi.csproj"
COPY . .
WORKDIR "/src/MemoryCasheExampleApi"
RUN dotnet build "MemoryCasheExampleApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MemoryCasheExampleApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MemoryCasheExampleApi.dll"]