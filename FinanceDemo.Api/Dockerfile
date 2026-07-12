# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["FinanceDemo.Api/FinanceDemo.Api.csproj", "FinanceDemo.Api/"]
COPY ["FinanceDemo.Application/FinanceDemo.Application.csproj", "FinanceDemo.Application/"]
COPY ["FinanceDemo.Domain/FinanceDemo.Domain.csproj", "FinanceDemo.Domain/"]
COPY ["FinanceDemo.Infrastructure/FinanceDemo.Infrastructure.csproj", "FinanceDemo.Infrastructure/"]

RUN dotnet restore "FinanceDemo.Api/FinanceDemo.Api.csproj"

COPY . .

WORKDIR "/src/FinanceDemo.Api"

RUN dotnet build "FinanceDemo.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish

RUN dotnet publish "FinanceDemo.Api.csproj" \
-c Release \
-o /app/publish \
/p:UseAppHost=false

# Final
FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FinanceDemo.Api.dll"]