
# Class Tracking

School “ABC” has some classes from 1 to 5. Every class has a teacher and students. Please create application for School “ABC” to track their information.


## Tech Stack

**Client:** Blazow web assembly, css

**Server:** .net 6

**Database:** Sql Server(Code First)



## Source Code Structure

    1. ClassTracking.Client (Blazor Web Assembly)
    2. ClassTracking.Client.Provider (Services for the client, calling API)
    3. ClassTracking.Shared (Models for both client and server)
    4. ClassTracking.Server (Startup Project, Contain with API)
    5. ClassTracking.Domain (All interfaces for the server application with Generic Repository and Unit of Work)
    6. ClassTracking.EFCore (Entity Framework core as ORM and its implmentation)


## Database Migration

Open the Package Manager Console and select ```ClassTracking.EFCore``` as default project
then run these command

```bash
  Update-Database
```
    
