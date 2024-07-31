# Usar a imagem oficial do .NET SDK para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Copiar os arquivos de projeto e restaurar as dependências
COPY *.sln .
COPY knights.Core/knights.Core.csproj knights.Core/
COPY knights.Application/knights.Application.csproj knights.Application/
COPY knights.Infrastructure/knights.Infrastructure.csproj knights.Infrastructure/
COPY knights.Tests/knights.Tests.csproj knights.Tests/
COPY knights.API/knights.API.csproj knights.API/
RUN dotnet restore

# Copiar o restante dos arquivos e construir a aplicação
COPY . .
WORKDIR /app/knights.API
RUN dotnet publish -c Release -o out

# Usar a imagem oficial do .NET runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/knights.API/out ./
ENTRYPOINT ["dotnet", "knights.API.dll"]