# LibraryManagerSQLProject

A simple C# Console Application to manage a library database using SQL Server. This project demonstrates basic CRUD operations (Create, Read, Update, Delete/Search) from a console menu, suitable for learning, interviews, and university assessments.

## Features

- **Add Book:** Enter book title, author, price and save to SQL Server database.
- **View All Books:** Display all books currently present in the database.
- **Search Book:** Find books by keyword in the title.
- **Delete Book:** Remove books using their ID.
- **Menu-driven interface:** Full user-friendly navigation from the terminal.

## Technologies Used

- C#
- .NET Core / .NET 7/8
- SQL Server (Express or Developer)
- Visual Studio 2022

## How to Run

1. **Clone or Download Repository**
    - Open terminal/cmd and run:
      ```
      git clone https://github.com/<your-username>/LibraryManagerSQLProject.git
      ```
2. **Open in Visual Studio**
    - Double-click `.sln` file or open Folder in VS.

3. **Ensure SQL Server is Running**
    - Start SQL Server service (default: SQLEXPRESS).
    - Open SQL Server Management Studio (SSMS).

4. **Create Database & Table**
    - Create a new database named `LibraryDB`.
    - Execute the following SQL code to create the `Books` table:
      ```
      CREATE TABLE Books (
          Id INT PRIMARY KEY IDENTITY(1,1),
          Title NVARCHAR(100) NOT NULL,
          Author NVARCHAR(100) NOT NULL,
          Price DECIMAL(10,2)
      );
      ```

5. **Update Connection String if Needed**
    - The connection string is in `Program.cs`:
      ```
      string connectionString = "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
      ```
    - Adjust server name if your SQL Server instance uses a different name.

6. **Build and Run**
    - Press F5 or click "Start" in Visual Studio.
    - Use the menu to manage your library.

## Example Usage

- Add books by providing details.
- View the full list of books.
- Search for a book by title.
- Delete a book using its ID.

## License

This project is open for educational use. No warranty provided.

---

> **Contact:**  
> Reach out via GitHub issues for suggestions or questions.
