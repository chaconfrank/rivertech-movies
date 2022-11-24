# Movies Microservice
**Version: 1.0**
## Scenario

The microservice was designed under a hexagonal architecture and in the application layer it implemented a Mediator Command pattern, in order to separate the responsibilities for writing and reading data towards the MongoDB database that is in the container.

With this microservice you can add new movie, update some movies and get one movie o get all movies.

The benefit of using the mediator pattern is that it allows us to separate the responsibility for reading and writing data at the software level, in addition to being able to decouple the microservice into another microservice much more easily in the future.

Currently the persistence of the data is written directly to the database but we could evolve the microservice so that the write data is written to a Kafka, SNS or RabbitMQ queue to ensure that the data is always stored.
## Patter Software

    |-- movier.API
    |   |-- Application
    |   |   |-- [domain]
    |   |   |   |-- |-- Command
    |   |   |   |   |-- Dto
    |   |   |   |   |-- Handler
    |   |   |   |   |-- Query
    |   |   |-- Mediator
    |   |-- Domain
    |   |   |-- Model
    |   |   |-- Context
    |   |-- Infrastructure
    |   |   |-- Controller
    |   |   |-- GraphQL
    |   |   |-- Repository
    |   |
    |
  

### Requirements
You will need:

    Install ASP.NET Core Runtime 6.0.11
    Install Docker
    Git

### Technologies required

- [ASP.NET (AspNetCore)](https://dotnet.microsoft.com/apps/aspnet)
- [Meditor R](https://github.com/jbogard/MediatR)
- [GraphQL](https://github.com/graphql-dotnet/graphql-dotnet)

### Steps to run application

You need run a Docker Container with docker compose to create a new mongo database with some data preload.

In root folder run
- ``docker-compose up -d``
- ``dotnet run --project RiverTechMovies/Movies.API/Movies.API.csproj``

### Url's
- ``https://localhost:7002/swagger/index.html``
- ``https://localhost:7002/graphql/``