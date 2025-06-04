# QtecTaskALS – A Modular Accounting Ledger System

A modular, testable, and scalable **Accounting System API** built with **ASP.NET Core 8**, following **Clean Architecture** principles. The system handles account creation, journal entries, and generates trial balance summaries using **stored procedures only** (no LINQ or EF queries).

---

## Tech Stack

- **Backend**: ASP.NET Core Web API (.NET 8)
- **Architecture**: Clean Architecture (Domain, Application, Infrastructure, API)
- **Database**: SQL Server (with stored procedures)
- **ORM**: EF Core (for migration support only)
- **Mediator Pattern**: [MediatR](https://github.com/jbogard/MediatR)
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Dependency Injection**: .NET built-in DI

---

## 📦 Features

| Endpoint               | Description                          |
|------------------------|--------------------------------------|
| `POST /accounts`       | Create new account                   |
| `GET /accounts`        | Get all accounts                     |
| `POST /journalentries` | Add journal entry with debit/credit |
| `GET /journalentries`  | List journal entries with lines      |
| `GET /trialbalance`    | Get net balances per account         |

---

## 📁 Folder Structure (Clean Architecture)
QtecTaskALS/
│
├── Api/ → ASP.NET Core entry point (Controllers, Program.cs)
├── Application/ → CQRS, DTOs, Interfaces, Validators
├── Domain/ → Entities
├── Infrastructure/ → DB access, SQL execution, Repositories
├── Persistence/ → (Optional) DbContext if needed later

---

## ⚙️ Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/QtecTaskALS.git
cd QtecTaskALS

2. Configure the Database Connection
Update the connection string in QtecTaskALS.Api/appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=QtecAccountingDB;User Id=your_user;Password=your_password;"
}


3. Set up the Database (Tables + Stored Procedures)
Create the following:

Tables:

 ├── Accounts

 ├── JournalEntries

 ├── JournalEntryLines

Stored Procedures:

 ├── usp_CreateAccount

 ├── usp_GetAccounts

 ├── usp_CreateJournalEntry

 ├── usp_CreateJournalEntryLine

 ├── usp_GetJournalEntries

 ├── usp_GetTrialBalance

You can find ready-to-run scripts in the /sql folder.

4. Run the API
  dotnet run --project QtecTaskALS.Api
Then open Swagger UI:
  https://localhost:5001/swagger

5. Validation Rules
POST /journalentries: Total Debit must equal Total Credit.

Entries must contain at least one journal line.

✍️ Author
Shuva Deb Nath
(https://github.com/ShuvaDebNath) | (https://shuvadebnathbd.com/)
