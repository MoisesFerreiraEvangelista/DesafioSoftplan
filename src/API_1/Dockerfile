#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY API_1.csproj .
RUN dotnet restore 
COPY . .
WORKDIR "/src"
RUN dotnet build "API_1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ENV TZ=America/Porto_Velho
ENV LANG pt_BR.UTF-8
ENV LANGUAGE ${LANG}
ENV LC_ALL ${LANG}
RUN rm -rf /var/cache/apk/*

ENTRYPOINT ["dotnet", "API_1.dll", "--environment=Staging"]


