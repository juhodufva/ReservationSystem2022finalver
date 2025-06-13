# Reservation System API


## Running

Build and run the application with `dotnet run`. The API listens on the configured HTTPS port.

On startup the application checks that the SQLite database schema exists and recreates it if necessary, so GET requests work even if the database file is missing tables.


## Item endpoints

- `GET /api/Items` – list all items
- `GET /api/Items/{id}` – fetch an item
- `POST /api/Items` – create a new item
- `PUT /api/Items/{id}` – update an item
- `DELETE /api/Items/{id}` – delete an item

All requests and responses use the `ItemDTO` format defined in `Models/Item.cs`.

