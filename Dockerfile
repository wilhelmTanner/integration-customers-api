FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80

COPY ./*.sln ./
COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*} && mv $file ${file%.*}; done

RUN dotnet restore
WORKDIR /app/
COPY . .
WORKDIR /app/FCUBS.Customer.Service.API
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/FCUBS.Customer.Service.API/out ./
ENTRYPOINT ["dotnet", "FCUBS.Customer.Service.API.dll"]