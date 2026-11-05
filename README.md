# Leave Management API — ABP Framework

A back-end API for managing employee leave requests with a **manager approval** flow, built on **ABP Framework** following Domain-Driven Design.

> Back-end only: the API is fully tested through Swagger. No UI is included.

## Features

- **Create leave requests** with start date, end date, and reason
- **Manager approval** — approve or reject pending requests
- **Business rules enforced in the domain:**
  - End date cannot be before start date
  - Only pending requests can be approved or rejected (e.g. approving twice is rejected)
- **Permissions** — separate permissions for creating and approving requests
- **Full auditing** — who created / modified each request and when (soft delete included)

## Domain Design

`LeaveRequest` inherits from `FullAuditedAggregateRoot<Guid>`:

- Properties use **private setters**, so state can only change through domain methods
- Status changes go through methods like `Approve()` and `Reject()`
- Invalid operations throw ABP `BusinessException` with error codes

This keeps business rules inside the entity instead of spreading them across services.

## Tech Stack

| Layer | Technologies |
| --- | --- |
| Framework | ASP.NET Core, ABP Framework |
| Data | Entity Framework Core, SQL Server |
| API Docs | Swagger |

## API Endpoints

| Method | Endpoint | Description |
| --- | --- | --- |
| POST | `/api/app/leave-request` | Create a leave request |
| GET | `/api/app/leave-request` | List leave requests |
| POST | `/api/app/leave-request/{id}/approve` | Approve a pending request |

## Getting Started

### Prerequisites

- .NET SDK 9+
- SQL Server
- ABP CLI: `dotnet tool install -g Volo.Abp.Studio.Cli`

### Run

1. Update the connection string in `appsettings.json` (HttpApi.Host and DbMigrator).
2. Install client libraries:
   ```
   abp install-libs
   ```
3. Apply migrations and seed data by running the **DbMigrator** project.
4. Run the **HttpApi.Host** project and open Swagger at `https://localhost:<port>/swagger`.
5. Authorize with `admin` / `1q2w3E*`.

## Author

**Mahmoud Mostafa** — Full-Stack .NET Developer
[GitHub](https://github.com/MahmoudMostafa5)
