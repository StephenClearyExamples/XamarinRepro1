using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PewBibleKjv.VerseView
{
    public sealed class SwipeTouchListener: Java.Lang.Object, View.IOnTouchListener
    {
        private readonly GestureDetector _gestureDetector;

        public SwipeTouchListener(Context context)
        {
            _gestureDetector = new GestureDetector(context, new GestureDetector.SimpleOnGestureListener());
        }

        public event Action OnSwipeLeft;
        public event Action OnSwipeRight;

        public bool OnTouch(View v, MotionEvent e) => _gestureDetector.OnTouchEvent(e);
    }
}