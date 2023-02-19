using Android.Graphics;
using System;
using System.Timers;

public class Dice
{

    private Bitmap _diceFace1;
    private Bitmap _diceFace2;

    private readonly int[] _dicePositions;
    private readonly Random _random;
    private int _currentDice1Face;
    private int _currentDice2Face;
    private bool isRolling;
    private int dice1;
    private int dice2;
    private Timer _animationTimer;
    private Bitmap[] diceFaces;
    public Dice(Bitmap[] diceFaces)
    {
        _random = new Random();

        this.diceFaces = diceFaces;
        _dicePositions = new int[] { 1700, 340, 1500, 340, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000 };
        _animationTimer = new Timer();
        _animationTimer.Interval = 50;
        _animationTimer.Elapsed += AnimationTimer_Elapsed;
    }

    public int[] Roll()
    {
        dice1 = RollDice();
        dice2 = RollDice();
        _diceFace1 = this.diceFaces[dice1 - 1];
        _diceFace2 = this.diceFaces[dice2 - 1];
        isRolling = true;
        _animationTimer.Start();
        return new int[] { dice1, dice2 };
    }

    private void AnimationTimer_Elapsed(object sender, ElapsedEventArgs e)
    {

        if (isRolling)
        {
            _dicePositions[0] -= 10;
            _dicePositions[2] -= 10;
            _currentDice1Face = (_currentDice1Face + 1) % 6;
            _currentDice2Face = (_currentDice2Face + 1) % 6;

            if (_dicePositions[0] < 1500)
            {

                isRolling = false;
                _animationTimer.Stop();
                _dicePositions[0] = 1700;
                _dicePositions[1] = 340;
                _dicePositions[2] = 1500;
                _dicePositions[3] = 340;
            }

        }

    }

    private int RollDice()
    {
        return _random.Next(1, 7);
    }

    public Bitmap GetDice1Face()
    {
        return _diceFace1;
    }

    public Bitmap GetDice2Face()
    {
        return _diceFace2;
    }

    public bool IsRolling()
    {
        return isRolling;
    }

    public int Dice1
    {
        get { return dice1; }
    }

    public int Dice2
    {
        get { return dice2; }
    }
    public int[] DicePositions
    {
        get { return _dicePositions; }
    }

    public int CurrentDice1Face
    {
        get { return _currentDice1Face; }
    }

    public int CurrentDice2Face
    {
        get { return _currentDice2Face; }
    }
}
