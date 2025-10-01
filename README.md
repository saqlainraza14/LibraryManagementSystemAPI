# LibraryManagementSystemAPI

ASP.NET Core Web API (C#) for a Library Management System using EF Core + SQLite.

## Features
- Manage Books and Members
- Borrow & Return books
- Uses SQLite for quick local testing
- Swagger UI included

## API Endpoints
- `GET /api/books`
- `GET /api/books/{id}`
- `POST /api/books`
- `PUT /api/books/{id}`
- `DELETE /api/books/{id}`

- `GET /api/members`
- `GET /api/members/{id}`
- `POST /api/members`
- `PUT /api/members/{id}`
- `DELETE /api/members/{id}`

- `GET /api/loans`
- `POST /api/loans/borrow`  (body: { bookId, memberId })
- `POST /api/loans/return`  (body: { bookId, memberId })

