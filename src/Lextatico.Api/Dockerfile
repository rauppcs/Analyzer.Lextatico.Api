FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 9002
EXPOSE 9003

ENV ASPNETCORE_URLS=http://+:9002;https://+:9003

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app && chown -R appuser /root
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/Lextatico.Api/Lextatico.Api.csproj", "src/Lextatico.Api/"]
RUN dotnet restore "src/Lextatico.Api/Lextatico.Api.csproj"
COPY . .
WORKDIR "/src/src/Lextatico.Api"
RUN dotnet build "Lextatico.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lextatico.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lextatico.Api.dll"]
