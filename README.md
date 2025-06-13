# Reservation System API


## Running

Build and run the application with `dotnet run`. The API listens on the configured HTTPS port.


## Item endpoints

- `GET /api/Items` – list all items
- `GET /api/Items/{id}` – fetch an item
- `POST /api/Items` – create a new item
- `PUT /api/Items/{id}` – update an item
- `DELETE /api/Items/{id}` – delete an item

All requests and responses use the `ItemDTO` format defined in `Models/Item.cs`.

