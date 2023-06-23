# MongoDBDataAccessLayer

A generic data access layer for MongoDB written in C# to reference in other projects. 
Dependencies: 
* MongoDB.Driver
* Microsoft.Extensions.Options

Import method of connection string is not provided in this template because it can be used in different projects and the method for using the connection string can vary.
To be able to use this template, simply add the following code to builder of your application.

```
builder.Services.Configure<MongoDBSettings>(CONNECTION_STRING);
builder.Services.AddSingleton<MongoDBService>();
```
