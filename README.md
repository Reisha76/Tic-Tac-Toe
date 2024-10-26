# Tic Tac Toe Game

## Overview
This is a simple Tic Tac Toe (or Noughts and Crosses) game implemented in C# using Windows Forms. The game features two players, Player 1 and Player 2, who take turns to play. The game has a user-friendly interface, and it highlights the winning combination once a player wins.

## Features
- Classic 3x3 grid Tic Tac Toe game.
- Player 1 and Player 2 take turns.
- Winning rows, columns, or diagonals are highlighted.
- The game keeps track of whose turn it is.
- Supports restarting the game.

## Requirements
- .NET Framework
- Visual Studio (or any compatible C# IDE)
- Windows OS to run the WinForms application

## How to Run
1. Clone this repository.
   ```sh
   git clone https://github.com/Reisha76/Tic-Tac-Toe
   ```
2. Open the solution file (`TicTacToe.sln`) in Visual Studio.
3. Build the solution to restore any dependencies.
4. Run the application.

## How to Play
- The game starts with Player 1.
- Players take turns to click on the empty cells, trying to form a line (either horizontally, vertically, or diagonally).
- When a player forms a line, the winning cells are highlighted.
- Once the game is over, you can click the "Restart" button to start a new game.

## Game Logic
- **Enums** are used for defining the players and the game status.
- **Structs** are used to maintain the game state, including tracking the winner and the play count.
- The grid is represented by buttons, and each button click triggers the game logic.

## Code Overview
- **`Form1.cs`**: The main code for handling the UI and game logic.
  - `Form1_Paint()`: Draws the Tic Tac Toe grid.
  - `ChangeImage()`: Updates the image of the button clicked by a player.
  - `CheckWinner()`: Checks the current state of the game for a winner.
  - `EndGame()`: Displays the game result and disables further moves.
  - `RestartGame()`: Resets all buttons and game state to start a new game.

## Screenshot
![Tic Tac Toe Screenshot](https://github.com/Reisha76/Tic-Tac-Toe/blob/main/TicTacToeProjectPic.png) 



## Author
[Your Name](https://github.com/Reisha76)

