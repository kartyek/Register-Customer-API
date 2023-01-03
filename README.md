# Register-Customer-API
Customer Registration API

Purpose of the API

Allow Customers to register for the AFI customer portal using REST API in .NET Core.

Tools Used :- Visual Studio 2022 Community Edition  + SQL 2018 + Swagger Open API for testing the endpoint[http://localhost:4000/swagger/index.html] integrated with the project.

Covered Functionalities :- All logical requirements including validation  +  Saving to DB  +  Unit Test Cases

Steps to verify the Project

1)Create the DB called CustomerDB in SQL.

2)Change the Connection String in appSettings.Json/appsettings.Development.Json(feasibility for production/dev) where WebApiDatabase server name needs to be modified accordingly to your local server. Note:- used Integrated SSPI for convenience.

3)Use visual studio(Preferable) or VScode to run the project - By default creates Table using the configure method of Db Migration.

4)Please use the swagger URL to verify the all combination of scenarios
  http://localhost:4000/swagger/index.html

