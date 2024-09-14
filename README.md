
![sv2](https://github.com/user-attachments/assets/a18a5ab8-4223-4166-a594-5f5aee990ad5)
# UserVersionTwo

This is a simple ASP.NET Core MVC project where users can manage their profiles and tasks without using a database. The project focuses on demonstrating basic CRUD (Create, Read, Update, Delete) operations, view models, and modal handling with Bootstrap.

## Features

- **User Management**: Add, edit, and delete users.
- **Task Management**: Add, edit, and delete tasks assigned to users.
- **Login System**: Tracks if a user is logged in and hides login options for logged-in users.
- **Modal Dialogs**: Uses Bootstrap static backdrop modals for smooth user interaction.
- **Custom Layout**: Implements custom layouts for specific pages without affecting the main layout.

## Technologies Used

- **ASP.NET Core MVC**: The main framework for building the application.
- **C#**: Primary programming language used for backend logic.
- **Bootstrap**: Used for responsive design and modal handling.
- **Razor View Engine**: For rendering views and dynamic content.
- **LINQ**: For performing data operations on lists.

## Project Structure

- **Controllers**: Manages the user and task-related requests and responses.
- **ViewModels**: `UserListViewModel` and `TaskListViewModel` are used for displaying and handling data in the views.
- **Views**: Contains Razor views for displaying the user interface.
- **Modals**: Bootstrap modals are used for creating and editing users and tasks.

## Installation & Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/kaankaya/UserVersionTwo.git
   
2. Open the project in your favorite IDE (e.g., Visual Studio).
   
3.Build the solution and run the project.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue for bug fixes, suggestions, or improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
