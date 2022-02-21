
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
MAINTAINER Flavio Cortés "flcortes@cscintact.com"
ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0
WORKDIR /build
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c $BUILDCONFIG -o out

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
MAINTAINER Flavio Cortés "flcortes@cscintact.com"

ENV REDISHOST=190.9.92.9
ENV REDISPORT=6090

EXPOSE 5600

WORKDIR /src
COPY ["TestMasiv/TestMasiv.csproj", "TestMasiv/"]
RUN dotnet restore "TestMasiv/TestMasiv.csproj"
COPY . .
WORKDIR "/src/TestMasiv"
RUN dotnet build "TestMasiv.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestMasiv.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestMasiv.dll"]