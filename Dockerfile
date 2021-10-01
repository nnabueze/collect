FROM mcr.microsoft.com/dotnet/sdk:3.1

WORKDIR /Source

COPY . .

RUN dotnet restore

WORKDIR /Source/ercascollect

RUN dotnet publish -c release -o /app

EXPOSE 5000

WORKDIR /app

ENV ASPNETCORE_URLS http://*:5000

CMD dotnet ercascollect.dll

