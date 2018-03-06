using System;
using System.Diagnostics;
using Android.Content;
using Android.Views;

namespace PewBibleKjv
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

        public bool OnTouch(View v, MotionEvent e)
        {
            try
            {
                return _gestureDetector.OnTouchEvent(e);
            }
            catch (ObjectDisposedException exception)
            {
                Debugger.Break();
                throw;
            }
        }
    }
}