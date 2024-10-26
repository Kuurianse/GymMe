# GymMe

**GymMe** is a web application designed for health and fitness enthusiasts to browse and purchase supplements, with features for admins to manage products and orders. Built with **ASP.NET** using **Domain-Driven Design (DDD)**, this project layers responsibilities to create a scalable and maintainable architecture.

## Overview

GymMe allows users to browse, order, and manage health supplements. Admins can manage inventory, handle orders, and view transaction reports. This project is a simplified version designed to showcase and test web development skills.

## Layers & Architecture

The application is divided into six key layers, each handling a distinct responsibility:

1. **View** – Manages the user interface and user interactions.
2. **Controller** – Validates and processes inputs from the View layer.
3. **Handler** – Encapsulates business logic, delegating database operations to the Repository.
4. **Repository** – Interfaces with the database, providing data manipulation methods.
5. **Factory** – Encapsulates complex object creation.
6. **Model** – Represents business data, using Entity Framework for database integration.

## User Roles & Permissions

| Role     | Permissions                                                                                     |
|----------|-------------------------------------------------------------------------------------------------|
| **Admin**  | Manage products, handle orders, view customer data, access transaction reports.               |
| **Customer** | Browse and order supplements, view order history, manage profile.                              |
| **Guest**    | Register and log in.                                                                          |

### Admin Permissions

- **View Customers**
- **Insert, Update, Delete Supplements**
- **View and Handle Orders**
- **Update Profile**
- **View Reports**

### Customer Permissions

- **Browse and Order Supplements**
- **Manage Cart** (Add, Clear, Checkout)
- **View Order History**
- **Update Profile**

### Guest Permissions

- **Register**
- **Log in**

## Key Pages & Functionalities

### Login

- Accessible only to guests.
- Validates username and password.
- Includes "Remember Me" checkbox for auto-login.

### Register

- Allows guests to create accounts.
- Validates personal details (e.g., username, email, password).

### Home

- Displays current user role.
- Shows customer data (for admin users).

### Order Supplement

- Displays supplement details for customers.
- Allows ordering and managing the cart.

### Profile

- Editable user profile information and password update.
  
### History

- Shows all customer transactions, with order detail view for each.

### Manage Supplements

- Admin-only access.
- Options to add, update, and delete products.

### Transaction Reports

- Admin-only access.
- Displays all transaction details with total income and subtotals.

## Navigation Bar

Dynamic navigation based on user role:

- **Customer**: Order Supplement, History, Profile, Logout.
- **Admin**: Home, Manage Supplements, Order Queue, Profile, Transaction Report, Logout.

---

## Development Requirements

- **Framework**: ASP.NET
- **Design Methodology**: Domain-Driven Design
- **Database Access**: Entity Framework (optional web services)

---

## Setup & Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Kuurianse/GymMe.git
