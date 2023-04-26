# Todo Service
## Work in Progress

## Description
This is a simple Todo service that allows users to create, read, update, and delete todo items.



### Endpoints
| Method | Endpoint | Description |
| ------ | -------- | ----------- |
| GET | /api/tasks | Get all todo items |
| GET | /api/tasks/{id} | Get a todo item by id |
| POST | /api/tasks | Create a new todo item |
| PUT | /api/tasks/{id} | Update a todo item |
| DELETE | /api/tasks/{id} | Delete a todo item |

### Models
#### TodoItem
```json
{
    "id": 1,
    "title": "Todo Item",
    "description": "This is a todo item",
    "dueDate": "2021-01-01T00:00:00",
    "completed": false,
    "projectId": 1 // not used at the moment
}
```

## Setup
1. Clone the repository
2. set environment variables
   1. SQL_SERVER_PASSWORD
   2. SQL_SERVER_USERNAME
3. Run dotnet ef database update --startup-project "../Todo Web Api"


## Development

### Migrations
    dotnet ef migrations add init --startup-project "../Todo Web Api"


## Version History
* 1.0.0
    * Initial Release
    * Added basic CRUD operations for TodoItems