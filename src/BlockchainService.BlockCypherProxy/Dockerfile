FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY BlockchainService.BlockCypherProxy/BlockchainService.BlockCypherProxy.csproj BlockchainService.BlockCypherProxy/
COPY BlockchainService.Abstractions/BlockchainService.Abstractions.csproj BlockchainService.Abstractions/
COPY BlockchainService.BlockCypher/BlockchainService.BlockCypher.csproj BlockchainService.BlockCypher/
RUN dotnet restore BlockchainService.BlockCypherProxy/BlockchainService.BlockCypherProxy.csproj
COPY . .
WORKDIR /src/BlockchainService.BlockCypherProxy
RUN dotnet build BlockchainService.BlockCypherProxy.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish BlockchainService.BlockCypherProxy.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlockchainService.BlockCypherProxy.dll"]
