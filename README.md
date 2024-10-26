GymMe is a web app for buying health supplements, designed for fitness enthusiasts and managed by store admins. Your task is to build a simplified ASP.NET-based version using Domain Driven Design. The app has several layers:


View – Displays information to users and handles input.

Controller – Validates and forwards user input for processing.

Handler – Manages business logic and database operations.

Repository – Provides database access and object manipulation.

Factory – Handles complex object creation.

Model – Represents business data with an Entity Framework.

User Roles and Access

Admin: Manage supplements, handle orders, view reports.

Customer: View, order, and checkout supplements, view history.

Guest: Login or register.


Key Pages

Login/Register: Accessible to guests for user authentication.

Home: Displays user role and customer data (for admin).

Order Supplement: For customers to view and order supplements.

Profile: Allows users to update personal info and passwords.

History: Shows past transactions for customers and all for admin.

Manage Supplements: Admin-only page to add, edit, or delete products.

Transaction Reports: Admin-only sales data and reports view.

The navigation bar adapts to user roles, simplifying access to relevant pages.

