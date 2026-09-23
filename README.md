# Library Management System

A web-based **Library Management System** developed using **ASP.NET Web Forms, C#, .NET Framework 4.8, SQL Server LocalDB, and ADO.NET**.

The system provides separate functionality for **users and administrators**, including secure authentication, book searching, book management, and user role management.

---

## 📌 Project Overview

The Library Management System is designed to manage basic library operations through a web-based application.

Users can create an account, log in, and view or search available books. Administrators have additional access to manage books and registered users through an administrative dashboard.

The project demonstrates the implementation of:

- Web-based authentication
- Role-based authorization
- Database connectivity
- CRUD operations
- Search functionality
- Password security
- Session management
- Form validation

---

## ✨ Features

### 👤 User Features

- User registration
- User login and logout
- Secure password hashing
- Session-based authentication
- View available books
- Search books
- Search by:
  - Book Name
  - Author
  - Category
  - ISBN
- User dashboard
- Restricted access to administrator pages

### 🛡️ Admin Features

- Admin login
- Admin dashboard
- Add new books
- Edit book details
- Delete books
- Search books
- View registered users
- Change user roles
- Delete users
- Prevent administrator from deleting their own account
- Prevent administrator from changing their own role

---

## 🔐 Security Features

The project implements several basic security mechanisms:

- Password hashing using **PBKDF2**
- Random salt generation
- Parameterized SQL queries
- Session-based authentication
- Role-based authorization
- Server-side form validation
- Restricted access to admin pages
- Protection against unauthorized access
- Prevention of self-role modification and self-deletion

Passwords are not stored as plain text in the database.

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Web Forms | Web application development |
| C# | Backend programming |
| .NET Framework 4.8 | Application framework |
| SQL Server LocalDB | Database management |
| ADO.NET | Database connectivity |
| HTML | Page structure |
| CSS | User interface styling |
| Visual Studio | Development environment |

---

## 🗄️ Database Design

The application uses **SQL Server LocalDB**.

### Users Table

Stores registered user information.

| Column | Description |
|---|---|
| UserId | Unique user ID |
| Name | User name |
| Email | User email |
| PasswordHash | Hashed password |
| Role | User or Admin |

### Books Table

Stores library book information.

| Column | Description |
|---|---|
| BookId | Unique book ID |
| BookName | Name of the book |
| Author | Book author |
| Category | Book category |
| ISBN | Book ISBN |
| Quantity | Available quantity |

---

## 🔄 Application Flow

```text
User
  │
  ├── Register
  │
  ├── Login
  │
  └── Dashboard
        │
        └── View / Search Books


Admin
  │
  ├── Login
  │
  └── Admin Dashboard
        │
        ├── Manage Books
        │     ├── Add
        │     ├── View
        │     ├── Update
        │     └── Delete
        │
        └── Manage Users
              ├── View
              ├── Change Role
              └── Delete
