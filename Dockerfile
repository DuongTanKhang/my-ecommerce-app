FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj riêng để tránh lỗi restore
COPY ECommerceBackend.csproj ./
RUN dotnet restore ECommerceBackend.csproj

# Copy toàn bộ source sau khi restore xong
COPY . . 
RUN dotnet publish ECommerceBackend.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ECommerceBackend.dll"]
