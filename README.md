
### StatePattern

https://en.wikipedia.org/wiki/State_pattern

This repository demonstrates the implementation of the State design pattern using C# to model the various states of an ATM (Automatic Teller Machine). The State pattern allows an object to alter its behavior when its internal state changes, making the code more modular and easier to maintain.

## Table of Contents

- [Introduction](#introduction)
- [States](#states)
- [Structure](#structure)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The StatePattern project provides a clear example of how to implement the State design pattern in C#. It models an ATM with four primary states:
1. Idle
2. Authentication
3. Transaction Selection
4. Transaction Processing

Each state has specific behaviors and transitions to handle user interactions and ATM operations.

## States

1. **Idle State**: The ATM is waiting for a user to insert a card.
2. **Authentication State**: The ATM prompts the user to enter their PIN and verifies it.
3. **Transaction Selection State**: The user selects the type of transaction they want to perform.
4. **Transaction Processing State**: The ATM processes the selected transaction.

## Structure

The project consists of several components:

- **Interfaces**:
  - \`IATMState\`: Defines the methods that each state must implement.

- **Concrete States**:
  - \`IdleState\`: Handles the behavior when the ATM is idle.
  - \`AuthenticationState\`: Handles the behavior during user authentication.
  - \`TransactionSelectionState\`: Handles the behavior for transaction selection.
  - \`TransactionProcessingState\`: Handles the behavior during transaction processing.

- **Context**:
  - \`ATMMachine\`: Maintains the current state and delegates state-specific behavior to the current state object.

### Directory Layout

\`\`\`
.
├── ATMMachine.cs
├── IATMState.cs
├── IdleState.cs
├── AuthenticationState.cs
├── TransactionSelectionState.cs
├── TransactionProcessingState.cs
└── Program.cs
\`\`\`

## Usage

To run the ATM state machine simulation, follow these steps:

1. Clone the repository:
   \`\`\`sh
   git clone https://github.com/stevsharp/StatePattern.git
   cd StatePattern
   \`\`\`

2. Open the project in your preferred IDE (e.g., Visual Studio).

3. Build and run the project. The \`Program.cs\` file contains a sample usage of the ATM state machine:
   \`\`\`csharp
   class Program
   {
       static void Main(string[] args)
       {
           ATMMachine atmMachine = new ATMMachine();

           // Test the ATM states
           atmMachine.InsertCard();
           atmMachine.EnterPIN(1234);
           atmMachine.SelectTransaction();
           atmMachine.ProcessTransaction();
           atmMachine.EjectCard();
       }
   }


## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details." > README.md
