# Solver
## Solver Project

To use the API, run the Solver.API project and use the swagger ui. Be sure to change connection strings to reference appropriate server

To use the Angular app, run `npm install` on the 'Solver.FrontEnd' directory.
After the dependencies are installed, run `npm run start` and navigate to 'http://localhost:4200'.

## Problem - 1
- Based on the database structure, I decided to use a path format of `http://localhost:12345/{databaseId}/data/{schema}/{tableName}`.
## Problem - 2
- I don't think I understood the ask here based on the scope of the project and how long I was supposed to spend working on it (3-4 hours).
- If I was to continue working on the project, to make this work, I would:
  - Create C# POCO objects for all database tables.
  - Create a new database with a table that has the following data structure:
    - Data type of column
    - Customer's custom column name
    - Real column name
    - Table name
    - Database name
    - Customer's unique id tied to customer column names
  - Write the necessary logic to map the query from problem #1 endpoints to get the customer's custom column names. 
    - This would be done in the Solver.Service library.
## Problem - 3
- Based on the information provided in problem #2 statement, this metadata would be provided to pass on to front end from the new table.
- I'm not sure yet how to best pass this to the frontend. I think I would provide the information in the response JSON but the structure is unclear to me still.
## Problem - 4
- Based on time, I hardcoded the path to save the file ('C:\results.csv'). 
- If I were to spend more time on the project, I would change the endpoint to return an HttpResponseMessage that includes the csv file.

## Bonus Questions
### Paging
I added paging to the server and client side (although the client side needs more work). 
It's returning enough information to make some future decisions to the api for now.
### Reduce JSON payload size
I added GZIP compression to the response pipeline but I still need to do more research on how to exactly reduce the JSON payloads.
I looked into a few methods (excluding null values, serializing the object to an array, and shorter field names), but all required more effort that I felt the necessary for bonus question.
I do understand the importance of making a response smaller though!
### Display Foreign Keys
My assumption is this bonus question is tied to Problem #2 and #3. 
Since I did not complete those problems, I did not complete this bonus question.
That being said, I understand the ask to display values tied to foreign keys.
### Front End
I decided to use Angular as the frontend framework and client application. 
I'm still new to angular as I mostly work on frontends that are tightly coupled to the ASP.NET MVC framework so its definitly a rough draft.

### Discarded Ideas
- Using EF for database access
  - I was planning on using Entity Framework to access the databases but I wanted to learn Dapper since Solver doesn't and/or can't use EF.
- Creating POCO objects for each database
  - I initially was going to create POCO objects for all the tables in each database (Database-First Code Generation) but decided that would take extra time.
### Pursued Ideas
- Used Dapper for database access
  - Since Solver uses Dapper, I thought I should learn and use for this project.
- Used Angular for front end
  - Instead of using a more tightly coupled frontend/backend setup (like ASP.NET Core MVC), I've been wanting to learn angular and thought it would work well for a simple frontend.
  - I repurposed an existing angular app I used for learning on another project.
### General Choices
- Service layer
  - I split out the service layer to another library for future enhancement.
- Repository layer
  - Same as service layer library. The idea here being that since these libraries implement interfaces, they could be used by other web api's.
### Trade Offs
- I tried to explain some trade offs throughout my explanation above. 
- Most trade offs were because of either trying to learn a new tool and or the time constraint.
### Future Changes
- I would spend time completing problem #2, #3, and #4 after getting feedback and additional questions answered.
- I would add logging and error handling to the service layer
