# Basic Sales Management System in C#

This project is a straightforward implementation of a sales management system in C#. It offers essential CRUD (Create, Read, Update, Delete) functionalities for overseeing sales transactions, managing products, and handling customer information.

## Features

1. **Add Sale**: Allows users to record a new sale transaction.
2. **View All Sales**: Provides a comprehensive list of all recorded sales transactions.
3. **Search Sale**: Enables users to find specific sales transactions based on id.
4. **Update Sale**: Allows users to modify existing sale transaction details, such as name, description, value or the quantity.
5. **Delete Sale**: Enables users to remove a recorded sale transaction from the system. If a sale contains products or customers that the user attempts to delete, the system notifies the user that the product/customer is associated with a sale and prevents deletion.

## Technologies Used

- **C#**: The primary programming language used for the application logic and interface.
- **SQL Server**: Utilized for database management, storing and retrieving sales transaction data, product information, and customer details.
- **Windows Forms**: Employed for creating the graphical user interface (GUI) of the application, facilitating user interaction.
