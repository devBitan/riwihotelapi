# Products API with JWT Authentication
This API, built using .NET, provides a set of endpoints for managing a hotel. The API is connected to a MySQL database and environment variables are used for configuration.

## Features
CRUD (Create, Read, Update, Delete) operations for hotel management.
Integration with Swagger for testing and API exploration.

## Requirements
+ .NET 8 SDK or higher.
+ MySQL server.
+ Swagger is integrated, so no need for Postman or external API testing tools.
+ Environment Variables
Ensure you set the following environment variables before running the application:

```csharp
DB_HOST = buis7p0gebobbyn7focd-mysql.services.clever-cloud.com
DB_NAME = buis7p0gebobbyn7focd
DB_PORT = 3306
DB_USERNAME = uf6oy8af36gekntr
DB_PASSWORD = SFKteSfX1Cg6qBMfEtQ

JWT_KEY = 1uñosdjfou244ojfbWRFJ244PRNRPENEb
JWT_ISSUER = http://localhost:5144
JWT_AUDIENCE = http://localhost:5144
JWT_EXPIRES_IN = 6
```
## Project Setup
### Clone the repository:

```bash
git clone https://github.com/devBitan/riwihotelapi
```
```bash
cd riwihotelapi
```

### Restore NuGet packages:

Run the following command in the project directory to restore necessary packages:

```bash
dotnet restore
```

### Set environment variables:

Before running the application, ensure that the environment variables for the database and JWT are set up as shown above.

### Apply database migrations:

Run the following command to apply migrations and set up the database tables:

```bash
dotnet ef database update
```

###  Run the API:

Start the API using the following command:

```bash
dotnet run
```

###  Access Swagger UI:

After running the API, Swagger will be available at https://localhost:5001/swagger or http://localhost:5000/swagger, where you can explore and test the API directly.


## Technologies Used
+ ASP.NET Core 8
+ Entity Framework Core
+ MySQL Database
+ Swagger (for testing and API documentation)

## License

© 2024 Riwi. All rights reserved.

The content of this project, including but not limited to text, images, graphics, and code, is the property of Riwi and is protected by copyright laws. It may not be reproduced, distributed, modified, or transmitted in any form or by any means without the prior written permission of Riwi.

For inquiries regarding the use or distribution of this project, please contact Riwi at [jquiramadev@outlook.com](mailto:jquiramadev@outlook.com).