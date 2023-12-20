This is a simple Task Management Api written in .NET 7 

I've used following techniques to build the solution.

1. Maintained clean architecture
2. Used Repository and UnitOfWork Pattern
3. Added Unit test (thats not sufficient though)


Improvement Areas:
Nothing is best in softwae engineering. There always a scope to improve. This the basic improvement areas

1. Couldn't get a change to refactor the code.
2. Add more validation which inserting data into the database
3. Add more unit tests (as much as possible)
4. Authentication/Authorization
5. Error Looging



Here are the endpoints below

1. Get All Tasks (GET)
  https://localhost:7058/Task/GetAll

2. Find Task By Id (GET)
   https://localhost:7058/Task/GetById/1

3. Delete Task By Id: (POST)
   https://localhost:7058/Task/Delete

4. Create new task (POST)
    https://localhost:7058/Task/create

5. Update existing task (POST)
   https://localhost:7058/Task/update

Sample Task Object:
{
    Id= 0,
    Title = "Demo Task",
    Status = "Pending",
    Description = "Test Description",
    DueDate = DateTime.Now,
};


How to Run the project:

1. Please clone the repository
2. Open it in Visual studio
3. Make a build
4. Change the connection string
5. Run update-database command

------------Thank you--------------
