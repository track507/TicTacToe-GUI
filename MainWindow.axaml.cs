using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace TicTacToe;

public partial class MainWindow : Window {
    double xWins = 0;
    double oWins = 0;
    double totalGamesPlayed = 0;
    Bitmap myBitmapO;
    Bitmap myBitmapX;
    int turnOrder = 0;

    // Used to keep track of the 2D board
    private const char EmptyCell = '-';
    private const char PlayerX = 'X';
    private const char PlayerO = 'O';
    // make a 2D board to keep track of whos winning
    private char[,] board = new char[3,3];
    private void ResetButtonBackgrounds() { 
    Button1.Background = new SolidColorBrush(Colors.White);
    Button2.Background = new SolidColorBrush(Colors.White);
    Button3.Background = new SolidColorBrush(Colors.White);
    Button4.Background = new SolidColorBrush(Colors.White);
    Button5.Background = new SolidColorBrush(Colors.White);
    Button6.Background = new SolidColorBrush(Colors.White);
    Button7.Background = new SolidColorBrush(Colors.White);
    Button8.Background = new SolidColorBrush(Colors.White);
    Button9.Background = new SolidColorBrush(Colors.White);
}
    private void ResetBoard() {
        for (int row = 0; row < 3; row++) {
            for (int col = 0; col < 3; col++) {
                board[row, col] = EmptyCell;
            }
        }
        ResetButtonBackgrounds();
        WinBox.Text = "";
        turnOrder = 0;
    }
    private void UpdateBoard(int row, int col, char player) {
        board[row, col] = player;
    }
    private bool HasWon(char player) {
        // rows
        for (int row = 0; row < 3; row++) {
            if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player) {
                return true;
            }
        }
        // columns
        for (int col = 0; col < 3; col++) {
            if (board[0, col] == player && board[1, col] == player && board[2, col] == player) {
                return true;
            }
        }
        // diagonals
        if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
            (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)) {
            return true;
        }
        return false;
    }

    public void displayTurn() {
        TextBox1.Text = $"{(turnOrder % 2 == 0 ? "X's turn" : "O's turn")}";
    }

    private bool isBgEmpty(Button button) {
        if(button.Background is ImageBrush imageBrush) {
            return imageBrush.IsSet == null;
        }
        return true;
    }
    private void displayRecord() {
        double xPercentage = totalGamesPlayed == 0 ? 0 : xWins / totalGamesPlayed;
        double oPercentage = totalGamesPlayed == 0 ? 0 : oWins / totalGamesPlayed;
        
        string text = "Records" + "\n" + $"X winning: {xPercentage:F2}" + "\n" + $"O winning: {oPercentage:F2}";
        RecordBox.Text = text;
    }
    public MainWindow() {
        InitializeComponent();
        myBitmapO = new Bitmap("../../../Images/cat.png");
        myBitmapO = myBitmapO.CreateScaledBitmap(new Avalonia.PixelSize(100,100));
        myBitmapX = new Bitmap("../../../Images/logo.png");
        myBitmapX = myBitmapX.CreateScaledBitmap(new Avalonia.PixelSize(100,100));
        displayTurn();
        displayRecord();
    }
    public void ButtonHandler(object sender, RoutedEventArgs args) {
        if( sender is Button button ) {
            string ButtonName = button.Name;
            if(ButtonName == "ResetButton") {
                ResetBoard();
                xWins = 0;
                oWins = 0;
                totalGamesPlayed = 0;
                turnOrder = 0;
                displayTurn();
                displayRecord();
            }
            if(ButtonName == "PlayAgainButton") {
                ResetBoard();
                displayTurn();
            }
            if(turnOrder < 9) {
                char currentPlayer = (turnOrder % 2) == 0 ? 'X' : 'O';
                ImageBrush background = null;
                background = turnOrder % 2 == 0 ? new ImageBrush(myBitmapX) : new ImageBrush(myBitmapO);
                
                if(isBgEmpty(button) && ButtonName != "PlayAgainButton" && ButtonName != "ResetButton" && !HasWon('X') && !HasWon('O')) { 
                    switch(ButtonName) {
                        case "Button1":
                            Button1.Background = background;
                            UpdateBoard(0, 0, currentPlayer);
                            break;
                        case "Button2":
                            Button2.Background = background;
                            UpdateBoard(0, 1, currentPlayer);
                            break;
                        case "Button3":
                            Button3.Background = background;
                            UpdateBoard(0, 2, currentPlayer);
                            break;
                        case "Button4":
                            Button4.Background = background;
                            UpdateBoard(1, 0, currentPlayer);
                            break;
                        case "Button5":
                            Button5.Background = background;
                            UpdateBoard(1, 1, currentPlayer);
                            break;
                        case "Button6":
                            Button6.Background = background;
                            UpdateBoard(1, 2, currentPlayer);
                            break;
                        case "Button7":
                            Button7.Background = background;
                            UpdateBoard(2, 0, currentPlayer);
                            break;
                        case "Button8":
                            Button8.Background = background;
                            UpdateBoard(2, 1, currentPlayer);
                            break;
                        case "Button9":
                            Button9.Background = background;
                            UpdateBoard(2, 2, currentPlayer);
                            break;
                        }
                    turnOrder++;
                    displayTurn();
                    if(HasWon(currentPlayer)) {
                        if(currentPlayer == 'X') {
                            xWins++;
                        }
                        else {
                            oWins++;
                        }
                        totalGamesPlayed++;
                        displayRecord();
                        WinBox.Text = $"{currentPlayer} has won";
                    }
                }
            }
            else {
                TextBox1.Text = "Tied Game";
                displayRecord();
                totalGamesPlayed++;
            }
        }
    }
}