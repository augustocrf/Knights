# Usar a imagem oficial do .NET SDK para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos de projeto e restaurar as dependências
COPY *.sln .
COPY Knights.Core/Knights.Core.csproj Knights.Core/
COPY Knights.Application/Knights.Application.csproj Knights.Application/
COPY Knights.Infrastructure/Knights.Infrastructure.csproj Knights.Infrastructure/
COPY Knights.API/Knights.API.csproj Knights.API/
RUN dotnet restore

# Copiar o restante dos arquivos e construir a aplicação
COPY . .
WORKDIR /app/Knights.API
RUN dotnet publish -c Release -o out

# Usar a imagem oficial do .NET runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/Knights.API/out ./
ENTRYPOINT ["dotnet", "Knights.API.dll"]