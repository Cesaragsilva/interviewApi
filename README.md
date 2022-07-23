## About the architecture of application

I used the Clean Architecture and DDD for building this application. Follow bellow the packages used.

- AutoMapper - Used for auto mapping Domain class to View Model class and Input Model Class to Domain 

- EntityFrameworkCore - Used for building an in Memory Database (InMemory extension) and for access the data using ORM. I prefered to use Entity than Dapper because last versions of entity are more flexible and fast than dapper.

- FluentValidation - Used for create validations of business and for implement the Notification Partner

- XUnit and MOQ - Used for building the tests case

## How to use API

# Docker

- Install docker https://docs.docker.com/get-docker/ and docker-compose https://docs.docker.com/compose/install/

- After install, access the folder **src** 

- Executing the command: docker-compose up -d

- Access the path in your browser: http://localhost:5142/swagger

# Executing application

- Install the .NET SDK 6 https://dotnet.microsoft.com/en-us/download/dotnet/6.0

- Install Visual Studio or Visual Studio Code 

- Clone the repository and execute the application using **dotnet run Interview.API**