# Parks Lookup API

#### By: Estevan Lopez

## Description
This project is called the "Park Lookup API" and serves as an archive of national parks. It fulfills an epciodus prompt for creating an API with ASP.NET Core. It utilizes Swashbuckle an implimenatation of swagger which can documents endpoints. 

## Technologies Used
- C#
- Entity Framework Core
- ASP.NET Core
- MySQL
- Postman
- Github
- Swagger
- Vs Code 

## Setup/Installation Pre-reqs

1. Install the `dotnet-ef` tool by running the following command in your terminal: 
``dotnet tool install --global dotnet-ef --version 6.0.0``
2. Enter the command ``dotnet tool install -g dotnet-script`` in Terminal.
3. [Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/).
4. [Download and install Postman](https://www.postman.com/downloads/).


### Set Up and Run Project

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory called "ParksLookupApi".
3. Within the production directory "ParksLookupApi", create two new files: `appsettings.json` and `appsettings.Development.json`.
4. Within `appsettings.json`, put in the following code. Make sure to replacing the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL. 

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=parks_lookup_api;uid=[YOUR_USERNAME];pwd=[YOUR_PASSWORD];"
  }
}
```

5. Within `appsettings.Development.json`, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

6. Create the database using the migrations in the ParkLookupApi project. Open your shell (e.g., Terminal or GitBash) to the production directory "ParksLookupApi", and run `dotnet ef database update`. You may need to run this command for each of the branches in this repo. 
7. Within the production directory "ParksLookupApi", run `dotnet watch run` in the command line to start the project server and monitor it. 
9. Use your program of choice to make API calls. In your API calls, use the local host domain _http://localhost:5000_. 
10.  Open the browser to _https://localhost:5001_/swagger to view endpoints through swagger ui. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. 

## Endpoints and Further Exploration
Explore the API endpoints and test them in Postman or Swagger ui in a browser accessed through localhost (see step above) otherwise look below.
There is full CRUD functionality for the 'Parks' class, here are the endpoints.
### GET /api/Parks
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/Parks</td>
        <td>Returns an array containing all Parks objects in the database.</td>
        <td>200: Ok</td>
      </tr>
</table>

Expected Response:
```json
[
  {
    "parkId": 1,
    "name": "Yellowstone National Park",
    "climate": "subarctic",
    "location": "United States"
  },
  {
    "parkId": 2,
    "name": "Banff National Park",
    "climate": "subarctic",
    "location": "Canada"
  }
]
```

### GET /api/Parks with optional query params
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Optional URL Parameters</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/Parks?[PARAMETER NAME]=[PARAMETER VALUE]</td>
        <td>name (string) <br> climate (string) <br> location (string)</td>
        <td>Returns an array containing all Park objects in the database that match the included parameters, multiple parameters may be included.</td>
        <td>200: Ok</td>
      </tr>
</table>

Example Request URL: `GET /api/Parks?climate=subarctic&parkId=1`

Expected Response:

```json
[
 {
    "parkId": 1,
    "name": "Yellowstone National Park",
    "climate": "subarctic",
    "location": "United States"
  }
]
```

### GET /api/Parks/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/Parks/{id}</td>
        <td>id (int)</td>
        <td>Returns a JSON object representing a Park with a "ParkId" property that matches the "id" provided in the URL parameter.</td>
        <td>200: Ok</td>
      </tr>
</table>

Example Request URL: `GET /api/Parks/1`

Expected Response: 

```json
[
  {
    "parkId": 1,
    "name": "Yellowstone National Park",
    "climate": "subarctic",
    "location": "United States"
  },
]
```

### POST /api/Parks
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Request Body *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>POST</td>
        <td>/api/Parks</td>
        <td>A JSON object containing key-value pairs for: <br> - name(string), <br> - climate(string), <br> - location(string) <br> - ParkId(int) value will be set by the database when the record is saved.</td>
        <td>Creates a new Park object in the database.</td>
        <td>201: Created</td>
      </tr>
</table>

Example Request Body *required:

```json
  {
    "name": "Weenie Hutt jr",
    "climate": "temperate",
    "location": "United States"
  }
```

Expected Response:

```json
  {
    "ParkId": 101,
    "name": "Weenie Hutt jr",
    "climate": "temperate",
    "location": "United States"
  }
```

### PUT /api/Parks/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Request Body *required</th>
        <th>Expected Response</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>PUT</td>
        <td>/api/Parks/{id}</td>
        <td>id (int)</td>
        <td>A JSON object containing key-value pairs for: <br> - ParkId(int) <br> - name(string), <br> - climate(string), <br> - location(string) <br> *the "parkId" must match the "id" provided as a URL parameter.</td>
        <td>No content</td>
        <td>204: No Content</td>
      </tr>
</table>

Example Request Body *required:

```json
  {
    "ParkId": 101,
    "name": "Weenie Hutt jr",
    "climate": "temperate",
    "location": "United States"
  }
```

### DELETE /api/Parks/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>DELETE</td>
        <td>/api/Parks/{id}</td>
        <td>id (int)</td>
        <td>Deletes a Park from the database.</td>
        <td>204: No Content</td>
      </tr>
</table>


## Note on CORS
CORS is a W3C standard that allows a server to relax the same-origin policy. It is not a security feature, CORS relaxes security. It allows a server to explicitly allow some cross-origin requests while rejecting others. An API is not safer by allowing CORS. For more information or to see how CORS functions, see the Microsoft documentation.

## Known Bugs
- Please email the host or submit an issue/pull Request.

## License
MIT License

Copyright (c) Estevan L 2023 
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.







