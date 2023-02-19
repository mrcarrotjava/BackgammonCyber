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

namespace Backgammon4
{
    public class Black : View
    {
        public Context context;
        public int x { set; get; }
        public int y { set; get; }
        Bitmap bitmap;
        public Black(int x, int y, Context c) : base(c)
        {
            this.context = c;
            this.x = x;
            this.y = y;
            this.bitmap = Android.Graphics.BitmapFactory.DecodeResource(
            Application.Context.Resources, Resource.Drawable.Black);


        }

        public void draw(Canvas canvas)
        {
            Drawable w;
            w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
            w.SetBounds((int)(x - 20), (int)((y - 20)), (int)(x + 20), (int)(y + 20));
            w.Draw(canvas);
        }
        // draw_loc => a function that takes the location of the given part of the array,
        // and printing it on the canvas also takes count to see how much zitonim it should take

        public void draw_loc(Canvas canvas, int i, int j, int count)
        {
            Drawable w;

            if (i == 0)
            {
                if (j == 0)
                {
                    x = 1992;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                    //x = 1810;
                    //y = 32;

                }
                // diff == 1992-1810 = 182 POG
                if (j == 1)
                {
                    x = 1850;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }

                }
                if (j == 2)
                {
                    x = 1710;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 3)
                {
                    x = 1570;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 4)
                {
                    x = 1430;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 5)
                {
                    x = 1290;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 6)
                {
                    x = 1030;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 7)
                {
                    x = 890;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 8)
                {
                    x = 750;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 9)
                {
                    x = 610;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 10)
                {
                    x = 470;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                }
                if (j == 11)
                {
                    x = 330;
                    y = 50;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y += 70;

                    }
                    //if (j == 11)
                    //{
                    //    x = 190;
                    //    y = 50;
                    //    for (int k = 0; k < count; k++)
                    //    {
                    //        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                    //        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                    //        w.Draw(canvas);
                    //        y += 70;

                    //    }
                    //}
                }
            }
            if (i == 1)
            {
                if (j == 0)
                {
                    x = 1992;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 1)
                {
                    x = 1850;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }

                }
                if (j == 2)
                {
                    x = 1710;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 3)
                {
                    x = 1570;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 4)
                {
                    x = 1430;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 5)
                {
                    x = 1290;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 6)
                {
                    x = 1030;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 7)
                {
                    x = 890;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 8)
                {
                    x = 750;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 9)
                {
                    x = 610;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 10)
                {
                    x = 470;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }
                }
                if (j == 11)
                {
                    x = 330;
                    y = 880;
                    for (int k = 0; k < count; k++)
                    {
                        w = ContextCompat.GetDrawable(context, Resource.Drawable.Black);
                        w.SetBounds((int)(x - 50), (int)((y - 50)), (int)(x + 50), (int)(y + 50));
                        w.Draw(canvas);
                        y -= 70;

                    }


                }
            }


        }



    }
}
