# Usa a imagem oficial do .NET SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto para dentro do contêiner
COPY . ./

# Restaura as dependências e compila o projeto
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Usa uma imagem mais leve do .NET Runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta 8080 para acesso externo
EXPOSE 8080

# Define o comando para iniciar a aplicação
CMD ["dotnet", "CleanArchitectureApi.dll"]
