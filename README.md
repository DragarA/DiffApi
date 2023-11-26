# DiffApi
REST Api for comparing base64 encoded data

### Requirements

- .NET 7 SDK
- Docker

### Setup
To get the application running, execute the following terminal command the root of the project:

```bash
docker-compose up --build
```
Docker compose will create database and application images, run the migrations and seed the user table. 

The code is reachable on `http://localhost`

### API endpoints

API endpoints can be explored with Swagger. 
The swagger UI is available at http://localhost/swagger/index.html after running the application. 


### Unit & Integration tests

The solution contains a `DiffApi.Tests` project. 
Tests are split into Unit and Integration tests, located in the corresponding folder. 

To run the test, use the following command in the terminal:
```bash
dotnet test
```

### API Usage

Add left data value for comparison
```bash
curl --location --request PUT 'http://localhost:80/v1/Diff/1/left' \
--header 'Content-Type: application/json' \
--data '{
  "data": "AAAAAA=="
}'
```

Add right data value for comparison
```bash
curl --location --request PUT 'http://localhost:80/v1/Diff/1/right' \
--header 'Content-Type: application/json' \
--data '{
  "data": "AAAAAA=="
}'
```

Compare data
```bash
curl --location 'http://localhost:80/v1/diff/1'
```