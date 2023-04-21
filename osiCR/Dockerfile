FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["osiCR/osiCR.csproj", "osiCR/"]
RUN dotnet restore "osiCR/osiCR.csproj"
COPY . .
WORKDIR "/src/osiCR"
RUN dotnet build "osiCR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "osiCR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "osiCR.dll"]
