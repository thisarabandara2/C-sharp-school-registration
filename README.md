# C-sharp-school-registration
A simple and efficient student registration and login system for Skills International School, developed in C# with SQL Server integration. The application includes secure login, student registration, and data management features, providing an easy-to-use interface for administrators and students alike.
aHere’s the complete README with the contact details and additional information matching your project requirements:

---

# 🎓 Skills International School Management System

Welcome to the Skills International School Management System! This project was developed as a final assignment using Visual Studio and C#. It includes essential functionalities for managing student registrations, user authentication, and database integration.

## 📋 Project Overview

This software solution is designed to help Skills International School streamline student registration processes. The project features a user-friendly interface and ensures secure access through a login form.

## 💻 Tech Stack

- **Frontend & Backend:** C# using Visual Studio
- **Database:** SQL Server (SQL Server Management Studio)
- **Tools:** Microsoft Visual Studio, SQL Server Management Studio

## ✨ Key Features

- **🔒 Login Form:** Secure login with pre-defined credentials (`Admin / Skills@123`). Error handling for incorrect credentials.
- **📝 Registration Form:** 
  - Register new students by capturing basic details, contact information, and parent details.
  - Features for updating, deleting, and searching student records.
  - Dropdown to view registered students by `Reg No`.
- **📊 Database:** Fully integrated with SQL Server, with a `Student` database and `Registration` table.

## 🛠️ Getting Started

To get the project up and running, follow these steps:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/skills-international-school.git
   cd skills-international-school
   ```

2. **Open the project in Visual Studio:**
   - Ensure you have Visual Studio installed with C# support.
   - Open the solution file (`.sln`).

3. **Set up the SQL Server database:**
   - Create a database named `Student`.
   - Add the `Registration` table using the provided structure:
     - `regNo`: Integer (Primary Key)
     - `firstName`: varchar(50)
     - `lastName`: varchar(50)
     - `dateOfBirth`: dateTime
     - `gender`: varchar(50)
     - `address`: varchar(50)
     - `email`: varchar(50)
     - `mobilePhone`: Integer
     - `homePhone`: Integer
     - `parentName`: varchar(50)
     - `nic`: varchar(50)
     - `contactNo`: Integer

4. **Run the application:**
   - Set the Login form as the startup form.
   - Test the login functionality with the default credentials.
   - Explore the registration features and database connectivity.

## 📷 Screenshots

Include screenshots of the forms and code snippets as required in the project documentation.

## 👥 Team Members

- **Frontend & Backend Developers:** Lahiru Prasad and Thisara Bandara

## 📞 Contact

For inquiries or support, you can reach out to the developers:

- **Lahiru Prasad** - [Email/Contact Info] 
- **Thisara Bandara** - [Email/Contact Info]

## 📅 Submission Guidelines

- Submit the full project folder along with a Microsoft Word document containing screenshots and code snippets.
- Follow all formatting guidelines as mentioned in the project brief.

## 📢 Feedback & Support

If you encounter any issues or have suggestions, feel free to open an issue or contact the project contributors.
