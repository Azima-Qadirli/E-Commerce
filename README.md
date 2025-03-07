# 🌐 **Mini E-Commerce Website - Backend**

This is the backend for a **mini e-commerce website** built using **ASP.NET Core**. The application provides functionalities such as **product management**, **order management**, **authentication**, and **notification services**, with security features like **role-based access control** and **password reset** functionality. The backend is built using the **CQRS**, **Mediator**, and **Repository** patterns, and utilizes **SignalR** for notifications and **Mail Service** for password resets.

## 🛠️ **Tech Stack**

The application is built using the following technologies:

- **ASP.NET Core**: Framework for building the application
- **C#**: Programming language used for backend logic
- **MSSQL**: Database management system for storing product, order, and user data
- **CQRS (Command Query Responsibility Segregation)**: Pattern for handling requests
- **Mediator**: Pattern used for decoupling components
- **Repository Pattern**: Used for data access abstraction
- **SignalR**: For real-time notifications
- **Google & Facebook Authentication**: For third-party login integration
- **Mail Service**: For sending password reset emails

---

## 📋 **Prerequisites**

Before running this project, ensure you have the following installed:

- ✅ **.NET 6.0** or later
- ✅ **MSSQL Server** (or another database provider if configured)
- ✅ **Postman** (for testing API requests)
- ✅ **Google Developer API Key** (if using Google login)
- ✅ **Facebook Developer API Key** (if using Facebook login)
