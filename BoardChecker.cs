using System.Linq;

public class BoardChecker : IChecker {
    // our 2d game board
    private char[] board = new char[9];

    // Keeps track of our board.
    public void Accumulate(int i, string s) {
        if (i >= 0 && i < 9 && (s == "X" || s == "O")) {
            board[i] = s[0]; 
        }
    }
    // clears the board setting the characters back to null
    public void Clear() {
        for (int i = 0; i < 9; i++) {
            board[i] = '\0'; 
        }
    }
    // checks every possible X win
    public bool Xwin() {
        return (board[0] == 'X' && board[1] == 'X' && board[2] == 'X') ||
               (board[3] == 'X' && board[4] == 'X' && board[5] == 'X') ||
               (board[6] == 'X' && board[7] == 'X' && board[8] == 'X') ||
               (board[0] == 'X' && board[3] == 'X' && board[6] == 'X') ||
               (board[1] == 'X' && board[4] == 'X' && board[7] == 'X') ||
               (board[2] == 'X' && board[5] == 'X' && board[8] == 'X') ||
               (board[0] == 'X' && board[4] == 'X' && board[8] == 'X') ||
               (board[2] == 'X' && board[4] == 'X' && board[6] == 'X');
    }
    // checks every possiby O win
    public bool Owin() {
        return (board[0] == 'O' && board[1] == 'O' && board[2] == 'O') ||
               (board[3] == 'O' && board[4] == 'O' && board[5] == 'O') ||
               (board[6] == 'O' && board[7] == 'O' && board[8] == 'O') ||
               (board[0] == 'O' && board[3] == 'O' && board[6] == 'O') ||
               (board[1] == 'O' && board[4] == 'O' && board[7] == 'O') ||
               (board[2] == 'O' && board[5] == 'O' && board[8] == 'O') ||
               (board[0] == 'O' && board[4] == 'O' && board[8] == 'O') ||
               (board[2] == 'O' && board[4] == 'O' && board[6] == 'O');
    }
    
    //if neither won, then its a draw.
    public bool Tie() {
        return !Xwin() && !Owin() && board.All(cell => cell != '\0');
    }
}