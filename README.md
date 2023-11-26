# DiffApi
REST Api for comparing base64 encoded data

### Requirements

- .NET 7 SDK
- Docker

### Setup
To get the application running, execute the following terminal command the root of the project:

```shell
docker-compose up --build
```
Docker compose will create database and application images, run the migrations and seed the user table. 

The code is reachable on `http://localhost`

### API endpoints

API endpoints can be explored with Swagger. 
The swagger UI is available at http://localhost/swagger/index.html after running the application. 
