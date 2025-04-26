# Imagen base de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen para build (compilación)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj y restaurar dependencias
COPY ["Parcial_2025_I.csproj", "./"]
RUN dotnet restore "./Parcial_2025_I.csproj"

# Copiar todo el código y compilar
COPY . .
RUN dotnet publish "./Parcial_2025_I.csproj" -c Release -o /app/publish

# Imagen final: solo el runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Parcial_2025_I.dll"]