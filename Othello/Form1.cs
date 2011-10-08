using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class Othello : Form
    {
        public class PointValue
        {
            public int x;
            public int y;
            public int value;
            public PointValue(int X, int Y, int Value)
            {
                x = X;
                y = Y;
                value = Value;
            }
        }
        public class BoardValue
        {
            public int[,] Board;
            public int value;
            public BoardValue(int[,] board, int Value)
            {
                Board = new int[8, 8];
                Array.Copy(board, Board, board.Length);
                value = Value;
            }
        }

        int[,] weights = new int[8, 8];
        int[,] pieces = new int[8, 8];
        static int white = 1;
        static int black = -1;
        static int none = 0;
        int turn = black;
        int human = 0;
        int computer = 0;
        bool gameover = false;
        bool twoplayer = false;
        int level = 0;

        public Othello()
        {
            InitializeComponent();

        }

        private void Othello_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            gfx.Clear(Color.Green);
            Pen myPen = new Pen(Color.Black, 4);
            Brush myBrush = new SolidBrush(Color.Black);
            for (int x = 0; x < 800; x = x + 100)
            {
                for (int y = 28; y < 800; y = y + 100)
                {
                    gfx.DrawRectangle(myPen, x, y, 100, 100);
                }
            }
        }

        private bool isPossibleMove(int[,] board, int Turn)
        {
            bool possibleMove = false;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    possibleMove = isValidMove(board, x, y, Turn);
                    if (possibleMove == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void drawBoard()
        {
            Graphics gfx = Graphics.FromHwnd(this.Handle);
            gfx.Clear(Color.Green);
            Pen myPen = new Pen(Color.Black, 4);
            Brush myBrush = new SolidBrush(Color.Black);
            for (int x = 0; x < 800; x = x + 100)
            {
                for (int y = 28; y < 800; y = y + 100)
                {
                    gfx.DrawRectangle(myPen, x, y, 100, 100);
                }
            }
        }

        private void drawPiece(int color, int x, int y)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            Brush myBrush;
            if (color == -1)
            {
                myBrush = new SolidBrush(Color.Black);
            }
            else if (color == 1)
            {
                myBrush = new SolidBrush(Color.White);
            }
            else
            {
                return;
            }
            g.FillEllipse(myBrush, x * 100 + 15, y * 100 + 15 + 28, 70, 70);
        }

        private void updateBoard()
        {
            int blackCount = 0;
            int whiteCount = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (pieces[x, y] == white)
                        whiteCount++;
                    if (pieces[x, y] == black)
                        blackCount++;
                    drawPiece(pieces[x, y], x, y);

                }
                System.Threading.Thread.Sleep(100);
            }

            whiteLabel.Text = whiteCount.ToString();
            whiteLabel.Update();
            blackLabel.Text = blackCount.ToString();
            blackLabel.Update();
        }

        private void Othello_MouseClick(object sender, MouseEventArgs e)
        {
            if ((turn != human && twoplayer == false) || gameover == true)
            {
                return;
            }

            int xCoordinate = e.X / 100;
            int yCoordinate = e.Y / 100;

            if (yCoordinate > 7 || xCoordinate > 7)
            {
                return;
            }

            if (!isValidMove(pieces,xCoordinate, yCoordinate, turn))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            pieces[xCoordinate, yCoordinate] = turn;

            int value = flipPieces(pieces, xCoordinate, yCoordinate, false);

            updateBoard();

            if (turn == white)
            {
                turn = black;
                turnLabel.Text = "Black";
            }
            else
            {
                turn = white;
                turnLabel.Text = "White";
            }
            turnLabel.Update();

            System.Media.SystemSounds.Exclamation.Play();

            System.Threading.Thread.Sleep(500);

            if (twoplayer == false && level == 1)
            {
                computerMove();
                while (!isPossibleMove(pieces,human))
                {
                    turn = computer;
                    if (!computerMove())
                    {
                        break;
                    }
                }
            }
            else if (twoplayer == false && level == 2)
            {
                lookAheadComputerMove();
                while (!isPossibleMove(pieces, human))
                {
                    turn = computer;
                    if (!lookAheadComputerMove())
                    {
                        break;
                    }
                }
            }

            if (gameOver())
            {
                return;
            }

            if (turn == black)
            {
                turnLabel.Text = "Black";        
            }
            else
            {
                turnLabel.Text = "White";
            }
            turnLabel.Update();

        }

        private Boolean isValidMove(int[,] board,int xCoor, int yCoor, int Turn)
        {
            int otherColor = 0;
            int sameColor = Turn;

            if (sameColor == white)
            {
                otherColor = black;
            }
            else
            {
                otherColor = white;
            }

            //Look to see if there is already a piece there
            if (board[xCoor, yCoor] != 0)
            {
                return false;
            }

            // Check in all directions to see if there is the same color in line with 
            // new piece. If there is then make sure the one immedately next to the new
            // piece is the opposite color.

            // Check Left
            int i = 2;
            while (!(xCoor - i < 0))
            {
                if (board[xCoor - i, yCoor] == none)
                {
                    break;
                }
                if (board[xCoor - i, yCoor] == sameColor)
                {
                    if (board[xCoor - 1, yCoor] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }

            // Check Right
            i = 2;
            while (!(i + xCoor > 7))
            {
                if (board[xCoor + i, yCoor] == none)
                {
                    break;
                }
                if (board[xCoor + i, yCoor] == sameColor)
                {
                    if (board[xCoor + 1, yCoor] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }

            // Check Down
            i = 2;
            while (!(i + yCoor > 7))
            {
                if (board[xCoor, yCoor +i] == none)
                {
                    break;
                }
                if (board[xCoor, yCoor + i] == sameColor)
                {
                    if (board[xCoor, yCoor + 1] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }

            // Check Up
            i = 2;
            while (!(yCoor - i < 0))
            {
                if (board[xCoor, yCoor - i] == none)
                {
                    break;
                }
                if (board[xCoor, yCoor - i] == sameColor)
                {
                    if (board[xCoor, yCoor - 1] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }

            // Check UpLeft
            i = 2;
            while (!(yCoor - i < 0) && !(xCoor - i < 0))
            {
                if (board[xCoor - i, yCoor -i] == none)
                {
                    break;
                }
                if (board[xCoor - i, yCoor - i] == sameColor)
                {
                    if (board[xCoor - 1, yCoor - 1] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }

            // Check UpRight
            i = 2;
            while (!(yCoor - i < 0) && !(xCoor + i > 7))
            {
                if (board[xCoor + i, yCoor - i] == none)
                {
                    break;
                }
                if (board[xCoor + i, yCoor - i] == sameColor)
                {
                    if (board[xCoor + 1, yCoor - 1] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }

            // Check DownRight
            i = 2;
            while (!(yCoor + i > 7) && !(xCoor + i > 7))
            {
                if (board[xCoor + i, yCoor + i] == none)
                {
                    break;
                }
                if (board[xCoor + i, yCoor + i] == sameColor)
                {
                    if (board[xCoor + 1, yCoor + 1] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }

            // Check DownLeft
            i = 2;
            while (!(yCoor + i > 7) && !(xCoor - i < 0))
            {
                if (board[xCoor - i, yCoor + i] == none)
                {
                    break;
                }
                if (board[xCoor - i, yCoor + i] == sameColor)
                {
                    if (board[xCoor - 1, yCoor + 1] == otherColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
            return false;
        }

        private List<PointValue> findValidMoves(int[,] board, int Turn)
        {
            int value = 0;
            List<PointValue> list = new List<PointValue>(); ;
            if (!isPossibleMove(board, Turn))
            {
                return list;
            }

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (isValidMove(board, x, y, Turn))
                    {
                        value = flipPieces(board, x, y, true);
                        PointValue point = new PointValue(x, y, value);
                        list.Add(point);
                    }
                }
            }
            return list;
        }

        private PointValue findBestMove(List<PointValue> list)
        {
            int highestValue = -9999;
            int highestPoint = -1;
            PointValue point;
            for (int x = 0; x < list.Count; x++)
            {
                point = list[x];
                if (point.value > highestValue)
                {
                    highestValue = point.value;
                    highestPoint = x;
                }
            }
            return list[highestPoint];
        }

        private int flipPieces(int[,] board, int xCoor, int yCoor, bool test)
        {
            int numberFlipped = 0;
            int valueOfMove = 0;
            int otherColor = 0;
            int sameColor = turn;

            if (sameColor == white)
            {
                otherColor = black;
            }
            else
            {
                otherColor = white;
            }

            // Check Left
            int i = 2;
            while (!(xCoor - i < 0))
            {
                if (board[xCoor - i, yCoor] == none)
                {
                    break;
                }
                if (board[xCoor - i, yCoor] == sameColor && board[xCoor - 1, yCoor] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor - i, yCoor];
                        if (!test)
                        {
                            board[xCoor - i, yCoor] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            // Check Right
            i = 2;
            while (!(i + xCoor > 7))
            {
                if (board[xCoor + i, yCoor] == none)
                {
                    break;
                }
                if (board[xCoor + i, yCoor] == sameColor && board[xCoor + 1, yCoor] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor + i, yCoor];
                        if (!test)
                        {
                            board[xCoor + i, yCoor] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            // Check Down
            i = 2;
            while (!(i + yCoor > 7))
            {
                if (board[xCoor, yCoor + i] == none)
                {
                    break;
                }
                if (board[xCoor, yCoor + i] == sameColor && board[xCoor, yCoor + 1] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor, yCoor + i];
                        if (!test)
                        {
                            board[xCoor, yCoor + i] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            // Check Up
            i = 2;
            while (!(yCoor - i < 0))
            {
                if (board[xCoor, yCoor - i] == none)
                {
                    break;
                }
                if (board[xCoor, yCoor - i] == sameColor && board[xCoor, yCoor - 1] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor, yCoor - 1];
                        if (!test)
                        {
                            board[xCoor, yCoor - i] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            // Check UpLeft
            i = 2;
            while (!(yCoor - i < 0) && !(xCoor - i < 0))
            {
                if (board[xCoor - i, yCoor - i] == none)
                {
                    break;
                }
                if (board[xCoor - i, yCoor - i] == sameColor && board[xCoor -1, yCoor - 1] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor - i, yCoor - i];
                        if (!test)
                        {
                            board[xCoor - i, yCoor - i] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            // Check UpRight
            i = 2;
            while (!(yCoor - i < 0) && !(xCoor + i > 7))
            {
                if (board[xCoor + i, yCoor - i] == none)
                {
                    break;
                }
                if (board[xCoor + i, yCoor - i] == sameColor && board[xCoor + 1, yCoor - 1] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor + i, yCoor - i];
                        if (!test)
                        {
                            board[xCoor + i, yCoor - i] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            // Check DownRight
            i = 2;
            while (!(yCoor + i > 7) && !(xCoor + i > 7))
            {
                if (board[xCoor + i, yCoor + i] == none)
                {
                    break;
                }
                if (board[xCoor + i, yCoor + i] == sameColor && board[xCoor + 1, yCoor + 1] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor + i, yCoor + i];
                        if (!test)
                        {
                            board[xCoor + i, yCoor + i] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            // Check DownLeft
            i = 2;
            while (!(yCoor + i > 7) && !(xCoor - i < 0))
            {
                if (board[xCoor - i, yCoor + i] == none)
                {
                    break;
                }
                if (board[xCoor - i, yCoor + i] == sameColor && board[xCoor - 1, yCoor + 1] == otherColor)
                {
                    numberFlipped += i - 1;
                    while (i >= 0)
                    {
                        valueOfMove += weights[xCoor - i, yCoor + i];
                        if (!test)
                        {
                            board[xCoor - i, yCoor + i] = sameColor;
                        }
                        i--;
                    }
                    break;
                }
                i++;
            }

            return (numberFlipped + valueOfMove);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private int countBoard(int[,] board)
        {
            int humanCount = 0;
            int computerCount = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (board[x, y] == computer)
                    {
                        computerCount += weights[x,y] + 1;
                    }

                    if (board[x, y] == human)
                    {
                        humanCount += weights[x, y] + 1; ;
                    }
                }
            }

            return computerCount - humanCount;
        }

        private bool computerMove()
        {
            // If the computer cannot move return false
            if (!isPossibleMove(pieces, computer))
            {
                turn = human;
                return false;
            }

            List<PointValue> list = findValidMoves(pieces, computer);
            PointValue point = findBestMove(list);
            pieces[point.x, point.y] = computer;
            flipPieces(pieces, point.x, point.y, false);
            updateBoard();
            turn = human;
            return true;
        }

        private bool lookAheadComputerMove()
        {

            // If the computer cannot move return false
            if (!isPossibleMove(pieces, computer))
            {
                turn = human;
                return false;
            }

            // Make a new list to hold all possible boards(states) of the game
            List<BoardValue> boards = new List<BoardValue>();

            // Find all possible moves for the current board.
            List<PointValue> list = findValidMoves(pieces, computer);

            // For each current move look and see how well the human player
            // can respond. We will then pick the move that the results.
            // in the higest score after the human has placed their best 
            // piece.
            for (int i = 0; i < list.Count; i++)
            {
                int[,] board = new int[8, 8];
                Array.Copy(pieces, board, pieces.Length);
                flipPieces(board, list[i].x, list[i].y, false);
                List<PointValue> humanlist = findValidMoves(board, human);
                PointValue bestHumanMove = findBestMove(list);
                flipPieces(board, bestHumanMove.x, bestHumanMove.y, false);
                BoardValue bv = new BoardValue(board, countBoard(board));
                boards.Add(bv);
            }

            // Look to see which human move ended up with the computer
            // in the best position.
            int best_board_value = -999999;
            int best_board = -1;
            for (int i = 0; i < boards.Count; i++)
            {
                if (boards[i].value > best_board_value)
                {
                    best_board_value = boards[i].value;
                    best_board = i;
                }
            }

            pieces[list[best_board].x, list[best_board].y] = computer;
            flipPieces(pieces, list[best_board].x, list[best_board].y, false);
            updateBoard();
            turn = human;
            return true;

        }

        private void boardStart()
        {
            turn = black;
            drawBoard();
            //Set all pieces to none
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    pieces[x, y] = none;
                }
            }
            pieces[4, 3] = white;
            pieces[3, 4] = white;
            pieces[3, 3] = black;
            pieces[4, 4] = black;
            turnLabel.Text = "Black";
            turnLabel.Update();
            initalizeWeights();
            gameover = false;
            updateBoard();
        }

        private void initalizeWeights()
        {
            weights[0, 0] = 500; weights[0, 1] = -10; weights[0, 2] = 4; weights[0, 3] = 4; weights[0, 4] = 4; weights[0, 5] = 4; weights[0, 6] = -10; weights[0, 7] = 500;
            weights[1, 0] = -10; weights[1, 1] = -10; weights[1, 2] = -2; weights[1, 3] = -2; weights[1, 4] = -2; weights[1, 5] = -2; weights[1, 6] = -10; weights[1, 7] = -10;
            weights[2, 0] = 5; weights[2, 1] = -2; weights[2, 2] = 0; weights[2, 3] = 0; weights[2, 4] = 0; weights[2, 5] = 0; weights[2, 6] = -5; weights[2, 7] = 4;
            weights[3, 0] = 5; weights[3, 1] = -2; weights[3, 2] = 0; weights[3, 3] = 0; weights[3, 4] = 0; weights[3, 5] = 0; weights[3, 6] = -5; weights[3, 7] = 4;
            weights[4, 0] = 5; weights[4, 1] = -2; weights[4, 2] = 0; weights[4, 3] = 0; weights[4, 4] = 0; weights[4, 5] = 0; weights[4, 6] = -5; weights[4, 7] = 4;
            weights[5, 0] = 5; weights[5, 1] = -2; weights[5, 2] = 0; weights[5, 3] = 0; weights[5, 4] = 0; weights[5, 5] = 0; weights[5, 6] = -5; weights[5, 7] = 4;
            weights[6, 0] = -10; weights[6, 1] = -10; weights[6, 2] = -2; weights[6, 3] = -2; weights[6, 4] = -2; weights[6, 5] = -2; weights[6, 6] = -10; weights[6, 7] = -10;
            weights[7, 0] = 500; weights[7, 1] = -10; weights[7, 2] = 4; weights[7, 3] = 4; weights[7, 4] = 4; weights[7, 5] = 4; weights[7, 6] = -10; weights[7, 7] = 500;
        }

        private bool gameOver()
        {

            if ((isPossibleMove(pieces, human) || isPossibleMove(pieces, computer)))
            {
                return false;
            }


            System.Media.SystemSounds.Asterisk.Play();
            if (Convert.ToInt32(blackLabel.Text) > Convert.ToInt32(whiteLabel.Text))
            {

                MessageBox.Show("BLACK WINS!!!");
            }
            else if (Convert.ToInt32(blackLabel.Text) < Convert.ToInt32(whiteLabel.Text))
            {
                MessageBox.Show("WHITE WINS!!!");
            }
            else
            {
                MessageBox.Show("TIE!!!");
            }

            gameover = true;
            return true;
        }

        private void twoPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoplayer = true;
            boardStart();
        }

        private void Othello_Load(object sender, EventArgs e)
        {

        }

        private void easyBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 1;
            human = black;
            computer = white;
            twoplayer = false;
            boardStart();
        }

        private void mediumBlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 2;
            human = black;
            computer = white;
            twoplayer = false;
            boardStart();
        }

        private void easyWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 1;
            computer = black;
            human = white;
            twoplayer = false;
            boardStart();
            computerMove();
        }

        private void mediumWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 2;
            computer = black;
            human = white;
            twoplayer = false;
            boardStart();
            lookAheadComputerMove();
        }

        private void Othello_Load_1(object sender, EventArgs e)
        {

        }
    }
}
