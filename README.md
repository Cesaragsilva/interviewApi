## About the architecture of application

I used the Clean Architecture and DDD for building this application. Follow bellow the packages used.

- EntityFrameworkCore - Used for building an in Memory Database (InMemory extension) and for access the data using ORM. I prefered to use Entity than Dapper because last versions of entity are more flexible and fast than dapper.

- FluentValidation - Used for create validations of business and for implement the Notification Partner

- XUnit - Used for building the tests case (Tests only to simulate a project with tests)

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

# Scenarios With Some Erros

## Slot Start: 27/07/2022 17:00:00 - End 27/07/2022 19:00:00 it can't be more than One Hour

    {
      "name": "Joao",
      "availabilities": [
        {
          "start": "2022-07-27T17:00",
          "end": "2022-07-27T19:00"
        }
      ]
    }


## End must be Greater Than Start
    {
      "name": "Joao",
      "availabilities": [
        {
          "start": "2022-07-27T17:00",
          "end": "2022-07-27T17:00"
        }
      ]
    }


## Two Notifications 

"End must be Greater Than Start"

"End it's a weekend and it's not allowed"

    {
      "name": "Joao",
      "availabilities": [
        {
          "start": "2022-07-27T17:00",
          "end": "2022-07-23T17:00"
        }
      ]
    }


## Must be equal to HH:00:00

    {
      "name": "Joao",
      "availabilities": [
        {
          "start": "2022-07-27T17:00",
          "end": "2022-07-27T18:01"
        }
      ]
    }


# Scenarios with success 

/candidate (POST)

    {
      "name":"Joao",
      "availabilities":[
         {
            "start":"2022-07-27T10:00",
            "end":"2022-07-27T11:00"
         },
         {
            "start":"2022-07-27T11:00",
            "end":"2022-07-27T12:00"
         },
         {
            "start":"2022-08-01T09:00",
            "end":"2022-08-01T10:00"
         },
         {
            "start":"2022-08-02T09:00",
            "end":"2022-08-02T10:00"
         },
         {
            "start":"2022-08-03T09:00",
            "end":"2022-08-03T10:00"
         },
         {
            "start":"2022-08-04T09:00",
            "end":"2022-08-04T10:00"
         },
         {
            "start":"2022-08-05T09:00",
            "end":"2022-08-05T10:00"
         }
      ]
    }

/interviewer (POST)

    {
      "name":"Diana",
      "availabilities":[
         {
            "start":"2022-08-02T09:00",
            "end":"2022-08-02T10:00"
         },
         {
            "start":"2022-08-02T10:00",
            "end":"2022-08-02T11:00"
         },
         {
            "start":"2022-08-02T11:00",
            "end":"2022-08-02T12:00"
         },
         {
            "start":"2022-08-04T09:00",
            "end":"2022-08-04T10:00"
         },
         {
            "start":"2022-08-04T10:00",
            "end":"2022-08-04T11:00"
         },
         {
            "start":"2022-08-04T11:00",
            "end":"2022-08-04T12:00"
         },
         {
            "start":"2022-08-01T12:00",
            "end":"2022-08-01T13:00"
         },
         {
            "start":"2022-08-01T13:00",
            "end":"2022-08-01T14:00"
         },
         {
            "start":"2022-08-01T14:00",
            "end":"2022-08-01T15:00"
         },
         {
            "start":"2022-08-01T15:00",
            "end":"2022-08-01T16:00"
         },
         {
            "start":"2022-08-01T16:00",
            "end":"2022-08-01T17:00"
         },
         {
            "start":"2022-08-01T17:00",
            "end":"2022-08-01T18:00"
         },
         {
            "start":"2022-08-03T12:00",
            "end":"2022-08-03T13:00"
         },
         {
            "start":"2022-08-03T13:00",
            "end":"2022-08-03T14:00"
         },
         {
            "start":"2022-08-03T14:00",
            "end":"2022-08-03T15:00"
         },
         {
            "start":"2022-08-03T15:00",
            "end":"2022-08-03T16:00"
         },
         {
            "start":"2022-08-03T16:00",
            "end":"2022-08-03T17:00"
         },
         {
            "start":"2022-08-03T17:00",
            "end":"2022-08-03T18:00"
         }
      ]
    }

    {
      "name":"Mary",
      "availabilities":[
         {
            "start":"2022-08-01T09:00",
            "end":"2022-08-01T10:00"
         },
         {
            "start":"2022-08-01T10:00",
            "end":"2022-08-01T11:00"
         },
         {
            "start":"2022-08-01T11:00",
            "end":"2022-08-01T12:00"
         },
         {
            "start":"2022-08-01T12:00",
            "end":"2022-08-01T13:00"
         },
         {
            "start":"2022-08-01T13:00",
            "end":"2022-08-01T14:00"
         },
         {
            "start":"2022-08-01T14:00",
            "end":"2022-08-01T15:00"
         },
         {
            "start":"2022-08-01T15:00",
            "end":"2022-08-01T16:00"
         },
         {
            "start":"2022-08-02T09:00",
            "end":"2022-08-02T10:00"
         },
         {
            "start":"2022-08-02T10:00",
            "end":"2022-08-02T11:00"
         },
         {
            "start":"2022-08-02T11:00",
            "end":"2022-08-02T12:00"
         },
         {
            "start":"2022-08-02T12:00",
            "end":"2022-08-02T13:00"
         },
         {
            "start":"2022-08-02T13:00",
            "end":"2022-08-02T14:00"
         },
         {
            "start":"2022-08-02T14:00",
            "end":"2022-08-02T15:00"
         },
         {
            "start":"2022-08-02T15:00",
            "end":"2022-08-02T16:00"
         },
         {
            "start":"2022-08-03T09:00",
            "end":"2022-08-03T10:00"
         },
         {
            "start":"2022-08-03T10:00",
            "end":"2022-08-03T11:00"
         },
         {
            "start":"2022-08-03T11:00",
            "end":"2022-08-03T12:00"
         },
         {
            "start":"2022-08-03T12:00",
            "end":"2022-08-03T13:00"
         },
         {
            "start":"2022-08-03T13:00",
            "end":"2022-08-03T14:00"
         },
         {
            "start":"2022-08-03T14:00",
            "end":"2022-08-03T15:00"
         },
         {
            "start":"2022-08-03T15:00",
            "end":"2022-08-03T16:00"
         },
         {
            "start":"2022-08-04T09:00",
            "end":"2022-08-04T10:00"
         },
         {
            "start":"2022-08-04T10:00",
            "end":"2022-08-04T11:00"
         },
         {
            "start":"2022-08-04T11:00",
            "end":"2022-08-04T12:00"
         },
         {
            "start":"2022-08-04T12:00",
            "end":"2022-08-04T13:00"
         },
         {
            "start":"2022-08-04T13:00",
            "end":"2022-08-04T14:00"
         },
         {
            "start":"2022-08-04T14:00",
            "end":"2022-08-04T15:00"
         },
         {
            "start":"2022-08-04T15:00",
            "end":"2022-08-04T16:00"
         },
         {
            "start":"2022-08-05T09:00",
            "end":"2022-08-05T10:00"
         },
         {
            "start":"2022-08-05T10:00",
            "end":"2022-08-05T11:00"
         },
         {
            "start":"2022-08-05T11:00",
            "end":"2022-08-05T12:00"
         },
         {
            "start":"2022-08-05T12:00",
            "end":"2022-08-05T13:00"
         },
         {
            "start":"2022-08-05T13:00",
            "end":"2022-08-05T14:00"
         },
         {
            "start":"2022-08-05T14:00",
            "end":"2022-08-05T15:00"
         },
         {
            "start":"2022-08-05T15:00",
            "end":"2022-08-05T16:00"
         }
      ]
    }

# Calendar with collections of slots

/calendar

    {
      "candidateId": 1,
      "interviewersIds": [
        1,2
      ]
    }