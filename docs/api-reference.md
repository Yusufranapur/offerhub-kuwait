# API Reference

OfferHub Kuwait uses RESTful APIs to communicate between the frontend portals and the backend systems. The API is documented using Swagger/OpenAPI.

## Swagger UI

When running the application locally, you can access the interactive Swagger documentation at:
- `http://localhost:5000/swagger`

## Authentication

All endpoints under `/api/admin/*` and `/api/vendor/*` require a valid JWT token.

Include the token in the `Authorization` header as a Bearer token:
```
Authorization: Bearer <your_jwt_token>
```

## Common Endpoints

### Auth
- `POST /api/auth/login`: Authenticate and receive a JWT.
- `POST /api/auth/refresh`: Refresh an expired JWT.

### Vendors
- `GET /api/vendors`: List vendors (paginated).
- `POST /api/vendors`: Create a new vendor (Admin only).
- `GET /api/vendors/{id}`: Get vendor details.

### Offers
- `GET /api/offers`: List all active offers.
- `POST /api/offers`: Create a new offer (Vendor/Admin).
- `PUT /api/offers/{id}`: Update an offer.
- `DELETE /api/offers/{id}`: Deactivate an offer.
