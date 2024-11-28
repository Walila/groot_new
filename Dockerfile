ARG SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0
ARG RUNTIME_IMAGE=mcr.microsoft.com/dotnet/aspnet:8.0

### Builder stage ###
FROM ${SDK_IMAGE} AS builder

WORKDIR /app
COPY nuget.config ./
COPY Groot ./

RUN dotnet restore
RUN dotnet publish Groot.csproj -c Release -o ./out

### Runtime stage ###
FROM ${RUNTIME_IMAGE} AS runtime

ENV APP_HOME /app
WORKDIR ${APP_HOME}
ENV TZ=America/Anguilla
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

COPY --from=builder /app/out .
EXPOSE 8080

ENTRYPOINT [ "dotnet", "Groot.dll" ]
