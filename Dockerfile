FROM mcr.microsoft.com/dotnet/core/runtime:3.1-nanoserver-1909 AS base
WORKDIR ./app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1909 AS build
WORKDIR /src
COPY ["./WpfApp1/WpfApp1.csproj", "./"]
RUN dotnet restore "./WpfApp1/WpfApp1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./WpfApp1/WpfApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./WpfApp1/WpfApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR ./app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WpfApp1.dll"]
EXPOSE 8080