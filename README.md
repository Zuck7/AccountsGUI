# AccountsGUI - Banking System Simulator

A comprehensive C# console application that simulates a banking system with multiple account types, user authentication, and transaction management. This **group project** was collaboratively developed by a team of 4 developers, demonstrating object-oriented programming principles, event handling, and data persistence in .NET 8.0.

## 🚀 Features

### Account Types
- **Visa Account**: Credit card functionality with purchase and payment capabilities
- **Saving Account**: Traditional savings account with interest calculations and transaction fees
- **Checking Account**: Basic checking account with optional overdraft protection

### User Management
- Secure user authentication system
- Multi-user account access (shared accounts)
- Password-based login with SIN (Social Insurance Number) validation
- Session management with authentication status tracking

### Transaction System
- Real-time transaction processing
- Transaction history and logging
- Event-driven architecture for transactn notifications
- Balance tracking with lowest balance monitoring
- Monthly report generation

### Advanced Features
- Exception handling with custom account exception types
- Event delegation system for login and transaction events
- JSON-based data persistence for users and accounts
- Comprehensive logging system
- Interest rate calculations for different account types

## 🏗️ Project Structure

```
AccountsGUI/
├── Program.cs              # Main entry point and demo scenarios
├── Bank.cs                 # Static bank class managing users and accounts
├── Account.cs              # Abstract base class for all account types
├── VisaAccount.cs          # Credit card account implementation
├── SavingAccount.cs        # Savings account with transaction fees
├── CheckingAccount.cs      # Checking account with overdraft support
├── Person.cs               # User management and authentication
├── Transaction.cs          # Transaction data model
├── AccountException.cs     # Custom exception handling
├── AccountExceptionType.cs # Exception type enumeration
├── Delegates.cs           # Event handler delegates
├── LoginEventArgs.cs      # Login event arguments
├── TransactionEventArgs.cs # Transaction event arguments
├── Logger.cs              # Logging functionality
├── DayTime.cs             # Date/time utilities
└── Util.cs                # Utility functions
```

## 🛠️ Technologies Used

- **.NET 8.0**: Latest .NET framework
- **C#**: Primary programming language
- **System.Text.Json**: JSON serialization for data persistence
- **Event-driven Architecture**: For real-time notifications
- **Object-Oriented Design**: Inheritance, polymorphism, and encapsulation

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Any C# compatible IDE (Visual Studio, VS Code, Rider)

## 🚀 Getting Started

### Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd AccountsGUI
   ```

2. Navigate to the project directory:
   ```bash
   cd AccountsGUI
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

### Usage

The application comes with pre-configured demo data including:

#### Pre-loaded Users
- Narendra, Ilia, Mehrdad, Vinay, Arben, Patrick, Yin, Hao, Jake, Mayy, Nicoletta

#### Pre-configured Accounts
- **VS-100000**: Visa account (shared by Narendra, Ilia, Mehrdad)
- **VS-100001**: Visa account with $150 balance and -$500 credit limit
- **SV-100002**: Savings account with $5000 balance
- **CK-100004**: Checking account with $2000 balance
- **CK-100005**: Checking account with overdraft protection

#### Sample Operations
The `Program.cs` demonstrates various banking operations:
- User authentication
- Visa purchases and payments
- Savings account withdrawals
- Checking account transactions
- Account balance inquiries

## 💡 Key Design Patterns

### Inheritance Hierarchy
```
Account (Abstract)
├── VisaAccount
├── SavingAccount
└── CheckingAccount
```

### Event-Driven Architecture
- **Login Events**: Track authentication attempts
- **Transaction Events**: Monitor account activities
- **Exception Events**: Handle error scenarios

### Data Persistence
- User data stored in `users.json`
- Account data stored in `accounts.json`
- Automatic serialization/deserialization

## 🔧 Configuration

### Account Settings
- **Visa Account**: 19.95% interest rate, $1200 default credit limit
- **Saving Account**: 1.5% interest rate, $0.50 transaction fee
- **Checking Account**: 0.5% interest rate, $0.05 transaction fee

### Authentication
- Passwords are auto-generated from the first 3 digits of SIN
- Session-based authentication with logout capabilities

## 🧪 Sample Transactions

```csharp
// User login
person.Login("123");

// Visa account operations
visaAccount.Purchase(200, person);
visaAccount.Pay(400, person);

// Savings account operations
savingsAccount.Withdraw(300, person);
savingsAccount.Deposit(500, person);

// Checking account operations
checkingAccount.Withdraw(100, person);
checkingAccount.Deposit(250, person);
```

## 🤝 Team Contributors

This project was developed as a **collaborative group effort by a team of 4 developers**, showcasing teamwork and various aspects of software engineering including:
- Object-oriented design principles
- Event-driven programming
- Exception handling strategies
- Data persistence techniques
- User authentication systems
- Collaborative development practices
- Code review and integration workflows

## 📊 Exception Handling

The system includes comprehensive error handling for:
- **PASSWORD_INCORRECT**: Invalid authentication attempts
- **NAME_NOT_ASSOCIATED_WITH_ACCOUNT**: Unauthorized account access
- **NO_OVERDRAFT**: Insufficient funds without overdraft
- **CREDIT_LIMIT_EXCEEDED**: Visa account limit violations

## 🔮 Future Enhancements

- GUI implementation using WPF or WinUI
- Database integration (SQL Server/SQLite)
- RESTful API development
- Mobile application support
- Advanced reporting and analytics
- Multi-currency support

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🚦 Build Status

- Target Framework: .NET 8.0
- Language Version: C# 12.0
- Nullable Reference Types: Enabled
- Implicit Usings: Enabled

---

**Note**: This is an educational project demonstrating banking system concepts. It should not be used for actual financial transactions without proper security implementations.
