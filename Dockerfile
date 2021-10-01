FROM mcr.microsoft.com/dotnet/sdk:3.1

WORKDIR /Source

COPY . .

RUN dotnet restore

WORKDIR /Source/ercascollect

RUN dotnet publish -c release -o /app

EXPOSE 80

WORKDIR /app

ENV ASPNETCORE_URLS http://*:80

CMD dotnet ercascollect.dll

