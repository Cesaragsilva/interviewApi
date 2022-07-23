FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Interview.API/Interview.API.csproj", "Interview.API/"]
COPY ["Interview.Application/Interview.Application.csproj", "Interview.Application/"]
COPY ["Interview.Core/Interview.Core.csproj", "Interview.Core/"]
COPY ["Interview.Ioc/Interview.Ioc.csproj", "Interview.Ioc/"]
COPY ["Interview.Infrastructure/Interview.Infrastructure.csproj", "Interview.Infrastructure/"]
RUN dotnet restore "Interview.API/Interview.API.csproj"
COPY . .
WORKDIR "/src/Interview.API"
RUN dotnet build "Interview.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.API.dll"]