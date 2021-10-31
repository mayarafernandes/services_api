# What

An architecture design proposal for a system composed of independent microservices (both business logic and data source) that receives requests from a REST API

# How

Developed with .NET Core 5 and C# using dependency injection principles with Entity Framework Core connected to SQLite databases for simplicity

# Run

Navigate to `.\src\` and open `ServicesAPI.sln` on Visual Studio 2019, set `ServicesAPI` as Startup Project and press Run (F5) 

or

Navigate to `.\src\ServicesAPI\` through command line and run `dotnet run .\ServicesAPI.csproj`

then

Open http://localhost:5000/swagger/ to see API documentation and execute endpoints

# Test

Navigate to `.\src\` and open `ServicesAPI.sln` on Visual Studio 2019 and use Test Explorer to run tests from `ServicesAPI.Tests` project

or

Navigate to `.\src\ServicesAPI.Tests\` through command line and run `dotnet test`