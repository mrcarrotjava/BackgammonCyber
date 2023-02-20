using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics.Drawables;
using Android.Animation;
using Android.Icu.Text;
namespace Backgammon4
{
    public class PaintView : View
    {

        public Stack<bool>[,] board;
        int turn = 0;
        Point lastClick = new Point();
        Paint paint = new Paint();
        Context context;
        White white;
        Black black;
        //check circle

        /// <TurnCommit>
        int circleCenterX = 2270;
        int circleCenterY = 541;
        int circleRadius = 139;
        bool isTouched = false;
        /// </TurnCommit>
        private Dice dice;
        private Bitmap[] diceFaces; // bitmaps for each dice face
        private int selectedRow = -1;
        private int selectedCol = -1;
        private bool sourceSelected = false;
        private bool currentTurn = true;
      
        private float[] dicePositions = new float[] { 1700, 340, 1500, 340, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000 };
        // x and y positions of each dice
        private float _touchX;
        private float _touchY;
        private bool Turn_Start_Rolldice = true;
        private int dice1 = -1;
        private int dice2 = -1;
        private Timer animationTimer;
        int _previousJ = -1;
        int j_click_two;
        int _previousI = -1;
        int i_click_two;
        bool _isFirstClick;
        int click_one;
        int click_two;
        bool isWhite;
        private bool _currentTurn = true; // true for white, false for black
        private bool animationRunning = false;
        private int currentDice1Face = 0;
        private int currentDice2Face = 0;
   
        private bool gameOver = false;

        private int[] TurnArray = new int[4]; // this array represent have four parameters that represent parts of the turn.
        //the first two represent the x and y of the new touched location and last two represet the second touch x and y
        public int[] dicearray = new int[2];

        private void Initialize()
        {
            diceFaces = new Bitmap[] {
            BitmapFactory.DecodeResource(Resources, Resource.Drawable.Dice_1),
            BitmapFactory.DecodeResource(Resources, Resource.Drawable.Dice_2),
            BitmapFactory.DecodeResource(Resources, Resource.Drawable.Dice_3),
            BitmapFactory.DecodeResource(Resources, Resource.Drawable.Dice_4),
            BitmapFactory.DecodeResource(Resources, Resource.Drawable.Dice_5),
            BitmapFactory.DecodeResource(Resources, Resource.Drawable.Dice_6)
        };
            dice = new Dice(diceFaces);

        }        



        public PaintView(Context context)
       : base(context)
        {
            this.context = context;
            Initialize();
            Random random = new Random();


            white = new White(20, 20, Context);
            black = new Black(200, 200, Context);
            board = new Stack<bool>[2, 12];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    board[i, j] = new Stack<bool>();
                }
            }

            // dicePositions = new float[] { 200, 200, 400, 400, 1000, 1000};

            board = Board_Init(board);
            // StartDiceAnimation();

            //ThreadStart ts = new ThreadStart(run);
            //Thread t = new Thread(ts);

            //t.Start();
            Invalidate();


        }
        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                float touchX = e.GetX();
                float touchY = e.GetY();

                if (IsWithinCircle(touchX, touchY))
                {
                    if (sourceSelected && IsValidMove(selectedRow, selectedCol, GetRowFromTouch(touchY), GetColFromTouch(touchX), _currentTurn))
                    {
                        TurnHandler(GetRowFromTouch(touchY), GetColFromTouch(touchX));
                        sourceSelected = false;
                    }
                }
                else
                {
                    int i = GetRowFromTouch(touchY);
                    int j = GetColFromTouch(touchX);
                    if (i != -1 && j != -1 && board[i, j].Count > 0 && board[i, j].Peek() == _currentTurn)
                    {
                        sourceSelected = true;
                        selectedRow = i;
                        selectedCol = j;
                    }
                }
            }
            return true;
        }

        private int GetRowFromTouch(float touchY)
        {
            int row = -1;
            if (touchY >= 16 && touchY <= 438) // top row
            {
                row = 0;
            }
            else if (touchY >= 577 && touchY <= 999) // bottom row
            {
                row = 1;
            }
            return row;
        }

        private int GetColFromTouch(float touchX)
        {
            int col = -1;
            if (touchX >= 2400 && touchX <= 2263) // rightmost column
            {
                col = 0;
            }
            else if (touchX >= 2262 && touchX <= 2125)
            {
                col = 1;
            }
            else if (touchX >= 2124 && touchX <= 1987)
            {
                col = 2;
            }
            else if (touchX >= 1986 && touchX <= 1849)
            {
                col = 3;
            }
            else if (touchX >= 1848 && touchX <= 1711)
            {
                col = 4;
            }
            else if (touchX >= 1710 && touchX <= 1573)
            {
                col = 5;
            }
            else if (touchX >= 1572 && touchX <= 1437)
            {
                col = 6;
            }
            else if (touchX >= 1436 && touchX <= 1299)
            {
                col = 7;
            }
            else if (touchX >= 1298 && touchX <= 1161)
            {
                col = 8;
            }
            else if (touchX >= 1160 && touchX <= 1023)
            {
                col = 9;
            }
            else if (touchX >= 1022 && touchX <= 887)
            {
                col = 10;
            }
            else if (touchX >= 886 && touchX <= 749) // leftmost column
            {
                col = 11;
            }
            return col;
        }

        private bool IsWithinCircle(float touchX, float touchY)
        {
            double distanceSquared = Math.Pow(touchX - circleCenterX, 2) + Math.Pow(touchY - circleCenterY, 2);
            bool isWithinCircle = distanceSquared <= Math.Pow(circleRadius, 2);
            return isWithinCircle;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            Draw_Board(canvas, board);
            if (dice.IsRolling())
            {
                DrawDice(canvas, dice.DicePositions[0], dice.DicePositions[1], diceFaces[dice.CurrentDice1Face]);
                DrawDice(canvas, dice.DicePositions[2], dice.DicePositions[3], diceFaces[dice.CurrentDice2Face]);
                Invalidate();
            }
            else
            {
                DrawDice(canvas, dice.DicePositions[0], dice.DicePositions[1], dice.GetDice1Face());
                DrawDice(canvas, dice.DicePositions[2], dice.DicePositions[3], dice.GetDice2Face());
            }
        }
        private bool HasWhiteCheckersOnBar()
        {
            return board[0, 6].Count > 0;
        }

        private bool HasBlackCheckersOnBar()
        {
            return board[1, 6].Count > 0;
        }

        private bool IsWinner(bool player)
        {
            int checkersOff = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (board[i, j].Count > 0 && board[i, j].Peek() == player)
                    {
                        if (player == true && i == 0)
                        {
                            checkersOff += board[i, j].Count;
                        }
                        else if (player == false && i == 1)
                        {
                            checkersOff += board[i, j].Count;
                        }
                    }
                }
            }
            return checkersOff == 15;
        }

        private void ShowBarMessage()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(Context);
            alert.SetTitle("Bar message");
            alert.SetMessage("You have a checker on the bar.");
            alert.SetPositiveButton("OK", (senderAlert, args) => {
                // continue game
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

    

        private void DrawDice(Canvas canvas, int x, int y, Bitmap diceface)
        {
            if (diceface != null && !diceface.IsRecycled)
            {

                canvas.DrawBitmap(diceface, x, y, null);
            }
        }
        private bool IsValidMove(int sourceI, int sourceJ, int destI, int destJ, bool currentTurn)
        {
            if (board[destI, destJ].Count > 1)
            {
                return false; // cannot move to a point with two or more checkers
            }

            if (board[destI, destJ].Count == 1 && board[destI, destJ].Peek() != currentTurn)
            {
                return false; // cannot move to a point with opponent's checker
            }

            if (sourceI == destI && sourceJ == destJ)
            {
                return false; // source and destination must be different
            }

            if (Math.Abs(destI - sourceI) != 1)
            {
                return false; // must move one step
            }

            if (board[destI, destJ].Count > 0 && board[destI, destJ].Peek() != currentTurn)
            {
                return false; // cannot move to a point with opponent's checker
            }

            if (board[destI, destJ].Count == 0 || board[destI, destJ].Peek() == currentTurn)
            {
                return true; // can move to an empty point or a point with the player's own checker
            }

            return false; // otherwise, invalid move
        }

        private void TurnHandler(int i, int j)
        {
            if (_previousI == -1 && _previousJ == -1) // source selection
            {
                if (_currentTurn == true && board[i, j].Count > 0)
                {
                    _previousI = i;
                    _previousJ = j;
                }
                else if (_currentTurn == false && board[i, j].Count > 0 && !HasWhiteCheckersOnBar() && board[i, j].Peek() == false)
                {
                    _previousI = i;
                    _previousJ = j;
                }
            }
            else // destination selection
            {
                if (IsValidMove(_previousI, _previousJ, i, j, _currentTurn))
                {
                    if (board[_previousI, _previousJ].Count > 1) // if move is a capture
                    {
                        board[(i + _previousI) / 2, (j + _previousJ) / 2].Pop();
                    }
                    board[i, j].Push(_currentTurn);
                    board[_previousI, _previousJ].Pop();
                    if (IsWinner(_currentTurn))
                    {
                        // TODO: display winner message and end game
                    }
                    else
                    {
                        if (_currentTurn == true)
                        {
                            _currentTurn = false;
                            if (HasBlackCheckersOnBar())
                            {
                                _previousI = -1;
                                _previousJ = -1;
                                ShowBarMessage();
                            }
                            else
                            {
                                _previousI = -1;
                                _previousJ = -1;
                            }
                        }
                        else
                        {
                            _currentTurn = true;
                            if (HasWhiteCheckersOnBar())
                            {
                                _previousI = -1;
                                _previousJ = -1;
                                ShowBarMessage();
                            }
                            else
                            {
                                _previousI = -1;
                                _previousJ = -1;
                            }
                        }
                    }
                }
            }
        }


        public void RollDice()
        {
            dice.Roll();
            Invalidate();
        }



        public Stack<bool>[,] Board_Init(Stack<bool>[,] board)
        {



            board[0, 0].Push(true);
            board[0, 0].Push(true);

            board[0, 5].Push(false);
            board[0, 5].Push(false);
            board[0, 5].Push(false);
            board[0, 5].Push(false);
            board[0, 5].Push(false);

            board[0, 7].Push(false);
            board[0, 7].Push(false);
            board[0, 7].Push(false);

            board[0, 11].Push(true);
            board[0, 11].Push(true);
            board[0, 11].Push(true);
            board[0, 11].Push(true);
            board[0, 11].Push(true);

            board[1, 0].Push(false);
            board[1, 0].Push(false);

            board[1, 5].Push(true);
            board[1, 5].Push(true);
            board[1, 5].Push(true);
            board[1, 5].Push(true);
            board[1, 5].Push(true);

            board[1, 7].Push(true);
            board[1, 7].Push(true);
            board[1, 7].Push(true);

            board[1, 11].Push(false);
            board[1, 11].Push(false);
            board[1, 11].Push(false);
            board[1, 11].Push(false);
            board[1, 11].Push(false);
            return board;



        }
      
      
        public void Draw_Board(Canvas canvas, Stack<bool>[,] board)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (board[i, j].Count > 0)
                    {
                        if (board[i, j].Peek() == false)
                        {
                            black.draw_loc(canvas, i, j, board[i, j].Count);
                        }
                        if (board[i, j].Peek() == true)
                        {
                            white.draw_loc(canvas, i, j, board[i, j].Count);
                        }
                    }
                }

            }


        }
    }
}

//public override bool OnTouchEvent (MotionEvent e)
//{
//    if (e.Action == MotionEventActions.Down)
//    {
//        int x =(int) e.GetX();
//        int y = (int)e.GetY();

//    }
//}
//}


