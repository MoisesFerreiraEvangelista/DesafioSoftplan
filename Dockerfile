FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/API_2/API_2.csproj", "src/API_2/"]
COPY ["src/Historias/Historias.csproj", "src/Historias/"]
COPY ["src/Dominio/Dominio.csproj", "src/Dominio/"]
COPY ["src/Adaptadores/Adaptadores.csproj", "src/Adaptadores/"]
RUN dotnet restore "src/API_2/API_2.csproj"
COPY . .
WORKDIR "/src/src/API_2"
RUN dotnet build "API_2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ENV TZ=America/Porto_Velho
ENV LANG pt_BR.UTF-8
ENV LANGUAGE ${LANG}
ENV LC_ALL ${LANG}
RUN rm -rf /var/cache/apk/*

ENTRYPOINT ["dotnet", "API_2.dll", "--environment=Staging"]