# Reservation System API

This simple ASP.NET Core API exposes item endpoints. Authentication for users and reservation features has been removed. The API only manages `Item` entities and requires an API key for all requests.

## Running

Build and run the application with `dotnet run`. The API listens on the configured HTTPS port.

## API Key

When using Swagger UI, this header is automatically included in the generated curl commands.


Example `appsettings.json` snippet:

```json
"ApiKey": "INNINLNNINIB "
```

Include the header in your requests:

```bash
curl -X GET 'https://localhost:7036/api/Items' \
  -H 'ApiKey: INNINLNNINIB'
```

## Item endpoints

- `GET /api/Items` – list all items
- `GET /api/Items/{id}` – fetch an item
- `POST /api/Items` – create a new item
- `PUT /api/Items/{id}` – update an item
- `DELETE /api/Items/{id}` – delete an item

All requests and responses use the `ItemDTO` format defined in `Models/Item.cs`.

