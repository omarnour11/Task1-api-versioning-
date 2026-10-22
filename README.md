# Task 1 — Implement API Versioning

ASP.NET Core Products API with URL-segment versioning (`Asp.Versioning.Mvc`).

## Endpoints

| Version | Request | Response |
|---------|---------|----------|
| v1 | `GET /api/v1/products` | `{ "id", "name", "price" }` |
| v2 | `GET /api/v2/products` | `{ "id", "name", "price", "categoryName" }` |

Both versions also support `GET /api/v{n}/products/{id}`.

## Example

`GET /api/v1/products/1`

```json
{
  "id": 1,
  "name": "Laptop",
  "price": 25000
}
```

`GET /api/v2/products/1`

```json
{
  "id": 1,
  "name": "Laptop",
  "price": 25000,
  "categoryName": "Electronics"
}
```

## Design notes

- Each version has its own controller and DTO, so changing the v2 response never affects v1 clients.
- Both versions share the same `ProductRepository` (data + domain logic). A database change only needs a new version if the API contract changes.
- Requests without a version fall back to v1.

## Run

```bash
dotnet restore
dotnet run
```

Swagger UI is available in Development at `/swagger`.
