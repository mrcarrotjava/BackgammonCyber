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

        private Dice dice;
        private Bitmap[] diceFaces; // bitmaps for each dice face

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
        private int _currentTurn = 1; // 1 for white, 2 for black
        private bool animationRunning = false;
        private int currentDice1Face = 0;
        private int currentDice2Face = 0;

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
        public override bool OnTouchEvent(MotionEvent e)
        {
            _touchX = e.GetX();
            _touchY = e.GetY();
            int i = 0, j = 0;
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    // Determine the location on the board that was touched
                    if (_touchY >= 16 && _touchY <= 438) // top!!!
                    {
                        i = 0;
                        if ((_touchX <= 2045 && _touchX >= 1907)) // [0,0]
                        {
                            j = 0;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1906 && _touchX >= 1770) //[0,1]
                        {
                            j = 1;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1769 && _touchX >= 1632) //[0,2]
                        {
                            j = 2;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1631 && _touchX >= 1494) //[0,3]
                        {
                            j = 3;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1493 && _touchX >= 1356) //[0,4]
                        {
                            j = 4;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1355 && _touchX >= 1218) //[0,5]
                        {
                            j = 5;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1091 && _touchX >= 956) //[0,6]
                        {
                            j = 6;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 954 && _touchX >= 817) //[0,7]
                        {
                            j = 7;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 815 && _touchX >= 679) //[0,8]
                        {
                            j = 8;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 678 && _touchX >= 544) //[0,9]
                        {
                            j = 9;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 543 && _touchX >= 403) //[0,10]
                        {
                            j = 10;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 401 && _touchX >= 265) //[0,10]
                        {
                            j = 11;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                    }
                    else if (_touchY >= 577 && _touchY <= 999)
                    {
                        i = 1;
                        if ((_touchX <= 2045 && _touchX >= 1907)) // [0,0]
                        {
                            j = 0;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1906 && _touchX >= 1770) //[0,1]
                        {
                            j = 1;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1769 && _touchX >= 1632) //[0,2]
                        {
                            j = 2;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1631 && _touchX >= 1494) //[0,3]
                        {
                            j = 3;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1493 && _touchX >= 1356) //[0,4]
                        {
                            j = 4;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1355 && _touchX >= 1218) //[0,5]
                        {
                            j = 5;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 1091 && _touchX >= 956) //[0,6]
                        {
                            j = 6;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 954 && _touchX >= 817) //[0,7]
                        {
                            j = 7;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 815 && _touchX >= 679) //[0,8]
                        {
                            j = 8;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 678 && _touchX >= 544) //[0,9]
                        {
                            j = 9;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 543 && _touchX >= 403) //[0,10]
                        {
                            j = 10;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                        if (_touchX <= 401 && _touchX >= 265) //[0,10]
                        {
                            j = 11;
                            Toast.MakeText(this.context, j.ToString(), ToastLength.Short).Show();
                        }
                    }

                    TurnHandler(i, j);
                    break;
            }
            return true;
        }
        private int RealNumbers(int i, int j)
        {
            if (i == 0)
            {
                return j + 1; // to make it without zero i added 1 
            }
            if (i == 1)
            {
                return j + 13;
            }
            else
            {
                return 0;
            }
        }
        private void TurnHandler(int i, int j)
        {
            //Roll();
            RollDice();
            if (_previousI == -1 && _previousJ == -1)
            {
                // this is the first click of the turn
                if (board[i, j].Count > 0)
                {
                    if (_currentTurn == 1)
                    {
                        // If it is player 1's turn
                        if (board[i, j].Peek() == true)
                        {
                            TurnArray[0] = i;
                            TurnArray[1] = j;

                            _previousI = i;
                            _previousJ = j;
                        }
                    }
                    else
                    {
                        // If it is player 2's turn
                        if (board[i, j].Peek() == false)
                        {
                            _previousI = i;
                            _previousJ = j;
                            TurnArray[2] = i;
                            TurnArray[3] = j;
                        }
                    }
                }
            }
            else
            {
                // this is the second click of the turn
                if (board[i, j].Count == 0)
                {
                    // If the destination is empty
                    //    if (IsValidMove(i,j,_previousI,_previousJ, _currentTurn)
                    var piece = board[_previousI, _previousJ].Pop();
                    board[i, j].Push(piece);
                    _currentTurn = _currentTurn == 1 ? 2 : 1;
                    _previousI = -1;
                    _previousJ = -1;
                    Invalidate();
                }
            }
        }
        public bool canPress(int i, int j, bool player)
        {
            if (board[i, j].Peek() == player)
            {
                return true;
            }
            if (board[i, j].Count < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsValidMove(int i1, int j1, int i2, int j2, int turn)
        {
            int dicesum = dicearray[0] + dicearray[1];
            int direction;
            if (turn == 1)
            {
                direction = 1;
            }
            else if (turn == 2)
            {
                direction = 2;

            }// there is a problem with j2 and j1 in this case. the seloutin is to give it a nukber from 1 - 24
            int real1 = RealNumbers(i1, j1); int real2 = RealNumbers(i2, j2);
            int diff = Math.Abs(real2 - real1);
            if (diff > dicesum)
            {
                return false;
            }
            return true;
        }

        private bool IsValidMoved(int i1, int j1, int i2, int j2, int diceResult)
        {
            // check if the starting point is within the board boundaries
            if (i1 < 0 || i1 > 1 || j1 < 0 || j1 > 11)
            {
                return false;
            }

            // check if the destination point is within the board boundaries
            if (i2 < 0 || i2 > 1 || j2 < 0 || j2 > 11)
            {
                return false;
            }
            int direction = i1 == 0 ? 1 : -1;
            if (i1 == i2)
            {
                int diff = Math.Abs(j2 - j1);
                // check if the difference between the starting and ending coordinates is less than the dice roll result
                if (diff > diceResult)
                {
                    return false;
                }
                // check if the move is diagonal
                for (int j = j1 + direction; j != j2; j += direction)
                {
                    if (board[i1, j].Count > 0)
                    {
                        return false;
                    }
                }
            }
            else if (i1 == 0 && i2 == 1 && j1 + diceResult == 11)
            {
                return true;
            }
            else if (i1 == 1 && i2 == 0 && j1 - diceResult == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            return true;
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
        private void DrawDice(Canvas canvas, int x, int y, Bitmap diceface)
        {
            if (diceface != null && !diceface.IsRecycled)
            {

                canvas.DrawBitmap(diceface, x, y, null);
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


