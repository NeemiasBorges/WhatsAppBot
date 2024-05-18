# WhatsAppBot

This repository contains the code for a WhatsApp Bot built using C#. The project is structured into several components, including Root, DTO, Interfaces, Repository, and the `infra.csproj` file.

## Table of Contents
- [Introduction](#introduction)
- [Project Structure](#project-structure)
- [Setup and Installation](#setup-and-installation)
- [Configuration](#configuration)
- [Running the Project](#running-the-project)
- [Contributing](#contributing)
- [License](#license)

## Introduction
WhatsAppBot is a C# project designed to create a bot that interacts with WhatsApp. This bot can handle various messaging tasks and integrates seamlessly with the WhatsApp API.

## Project Structure
- **Root**: Contains the main entry point and primary logic for the bot.
- **DTO**: Data Transfer Objects used to encapsulate data.
- **Interfaces**: Interface definitions for various components of the bot.
- **Repository**: Handles data access and storage.
- **infra.csproj**: The project file defining the .NET project configuration.
- **appsettings**: Configuration file for storing application settings, including the connection string.

## Setup and Installation
To set up and run this project, follow these steps:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/Neemoasb/WhatsAppBot
    ```

2. **Install .NET 7**:
    Download and install the .NET 7 SDK from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/7.0).

3. **Install project dependencies**:
    Navigate to the project directory and restore the dependencies:
    ```bash
    cd WhatsAppBot
    dotnet restore
    ```

## Configuration
Before running the project, you need to configure the connection string in the `appsettings.json` file. Update the `ConnectionStrings` section with your database connection details.

Example `appsettings.json` snippet:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_Connection_String_Here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```
## Running the Project
After setting up the configuration, you can run the project using the following command:
```bash
dotnet run --project infra.csproj
```

## Contributing
If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a Pull Request.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

