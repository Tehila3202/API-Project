# Chinese Auction Management API

A robust ASP.NET Core Web API designed to manage a complete Chinese Auction system.  
The platform supports administrative control over donors, items, raffle assignments, and winner selection.

---

## Overview

This RESTful API enables secure and efficient management of charity auction operations.  
Administrators can manage donors and items while the system automatically handles raffle logic and winner determination according to business rules.

The project implements authentication, logging, and clean architecture using Repository-Service design patterns.

---

## Features

### Administrative Management
- Create, update, and remove admin accounts

### Donor Management
- Register donors and manage donation records

### Auction Item Management
- Manage the lifecycle of items available for raffle

### Raffle System
- Assign donors to raffle items
- Automatic winner selection

### Security
- JWT-based authorization for sensitive endpoints

### Logging
- File logging for audit and traceability

---

## Tech Stack

| Layer | Technology |
|-------|------------|
| Backend | ASP.NET Core Web API (.NET 8) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Authentication | JWT |
| Documentation | Swagger / OpenAPI |

---

## Clean and Modular Architecture

