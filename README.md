# Reservation System API


# Project Startup
Open the project folder in the terminal:
1.
cd ReservationSystem2022finalver
2.
Build the project:
dotnet build
3.
Run the application:
dotnet run
4.
Open a browser and go to:
https://localhost:7036/swagger

If you encounter the error:
"The process cannot access the file 'reservation.db' because it is being used by another process."
Reason:
When starting, the program tries to delete the database file reservation.db, but another process (or program) is using it at that moment.
Try:
"Remove-Item .\reservation.db"

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

