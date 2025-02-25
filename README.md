Hotel Management System 🏨
The Hotel Management System is a comprehensive Windows Forms application designed to manage hotel operations efficiently. It provides features for managing rooms, reservations, and employees, along with advanced functionalities like Excel import/export using reflection, password hashing for secure authentication, and a dashboard for real-time insights.

This project was developed using 3-Tier Architecture to ensure separation of concerns, scalability, and maintainability. It also includes a secure admin login system and dynamic Excel import/export capabilities.

Key Features ✨
1. Dashboard
Real-Time Insights: Display key metrics such as:

Number of employees.

Number of available rooms.

Upcoming reservations.

Recent reservations.

User-Friendly Interface: Visualize data in an easy-to-understand format.

2. Room Management
Add, Update, Delete Rooms: Manage room details such as room number, type, price, and availability.

Room Availability: Automatically update room availability based on reservations.

Validation: Prevent deletion of rooms with active reservations.

3. Reservation Management
Add, Update, Delete Reservations: Manage reservations with details like customer name, check-in/out dates, and status.

Reservation Status: Track reservations using statuses like Upcoming, Ongoing, CheckedOut, Canceled, and NoShow.

Room Assignment: Ensure only available rooms can be selected for new reservations.

4. Employee Management
Add, Update, Delete Employees: Manage employee details such as name, position, and salary.

5. User Authentication
Admin Login: Secure login for administrators using SHA-256 password hashing.

Password Security: Passwords are hashed before storing in the database.

6. Excel Import/Export
Generic Excel Import: Use reflection to dynamically import data from Excel files into the database. Supports importing rooms, reservations, and employees.

Generic Excel Export: Use reflection to dynamically export data from the database to Excel files. Supports exporting rooms, reservations, and employees.

Flexibility: The import/export functionality works with any entity, making it highly reusable.

7. Database Management
Entity Framework Core: Used for database operations and migrations.

SQLite Database: Lightweight and easy-to-use database for local storage.

One-to-Many Relationship: Rooms and reservations are linked, ensuring data consistency.

3-Tier Architecture 🏗️
The application is built using 3-Tier Architecture, which separates the application into three logical layers:

1. Presentation Layer (UI)
Handles user interaction and displays data.

Built using Windows Forms.

Communicates with the Business Logic Layer to fetch and update data.

2. Business Logic Layer (BLL)
Contains the core logic of the application.

Validates data, enforces business rules, and processes requests from the Presentation Layer.

Communicates with the Data Access Layer to retrieve and store data.

3. Data Access Layer (DAL)
Manages interactions with the database.

Built using Entity Framework Core.

Handles CRUD operations for entities like rooms, reservations, and employees.

This architecture ensures separation of concerns, making the application scalable, maintainable, and easy to test.

Technologies Used 🛠️
C#: Primary programming language.

Windows Forms: For building the user interface (Presentation Layer).

Entity Framework Core: For database management and migrations (Data Access Layer).

SQLite: As the local database.

EPPlus: For Excel import/export functionality.

Reflection: For dynamic handling of Excel import/export.

SHA-256: For secure password hashing.

Advanced Features 🚀
1. Dashboard
The dashboard provides real-time insights into hotel operations, including:

Total number of employees.

Number of available rooms.

Upcoming reservations.

Recent reservations (e.g., last 5 reservations).

This helps administrators make informed decisions quickly.

2. Reflection for Excel Import/Export
The system uses reflection to dynamically read and write data from/to Excel files. This makes the import/export functionality generic and reusable for any entity (e.g., rooms, reservations, employees).

Example: When importing rooms from an Excel file, the system dynamically maps Excel columns to room properties using reflection.

3. Secure Authentication
Passwords are hashed using SHA-256 before storing in the database, ensuring secure authentication.

Example: When a user registers, their password is hashed and stored. During login, the entered password is hashed and compared to the stored hash.

How to Use 🛠️
Login: Use the default admin credentials (admin / admin123) or register a new user.

Dashboard: View real-time insights into hotel operations.

Manage Rooms: Add, update, or delete rooms. Ensure rooms with active reservations cannot be deleted.

Manage Reservations: Add, update, or delete reservations. Ensure only available rooms can be selected.

Manage Employees: Add, update, or delete employees.

Import/Export Data: Use the import/export functionality to manage data in Excel files.

