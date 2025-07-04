FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["qrMenu.csproj", "./"]
RUN dotnet restore "qrMenu.csproj"

COPY . .
RUN dotnet build "qrMenu.csproj" -c Release -o /app/build
RUN dotnet publish "qrMenu.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "qrMenu.dll"]
