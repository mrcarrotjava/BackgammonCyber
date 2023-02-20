using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Bitmap = Android.Graphics.Bitmap;
using Color = Android.Graphics.Color;
using Math = System.Math;
namespace Backgammon4
{
    public class CommitTurn : View
    {
        private Context context;
        private Bitmap bitmap;
        private bool isTouched = false;
        private int circleCenterX = 2271;
        private int circleCenterY =  500 ;
        private int circleRadius =36 ;

        public CommitTurn(int x, int y, int radius, Context c) : base(c)
        {
            this.context = c;
            this.bitmap = Android.Graphics.BitmapFactory.DecodeResource(
                Application.Context.Resources, Resource.Drawable.Black);

            this.circleCenterX = x;
            this.circleCenterY = y;
            this.circleRadius = radius;
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            float touchX = e.GetX();
            float touchY = e.GetY();

            double distanceSquared = Math.Pow(touchX - circleCenterX, 2) + Math.Pow(touchY - circleCenterY, 2);
            bool isWithinCircle = distanceSquared <= Math.Pow(circleRadius, 2);

            if (isWithinCircle)
            {
                isTouched = true;
                return true;
            }
            else
            {
                isTouched = false;
                return false;
            }
        }

        public bool IsTouched()
        {
            bool wasTouched = isTouched;
            isTouched = false;
            return wasTouched;
        }
    }
}