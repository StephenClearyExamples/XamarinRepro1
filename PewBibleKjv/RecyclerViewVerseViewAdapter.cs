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
using PewBibleKjv.VerseView;

namespace PewBibleKjv
{
    public sealed class RecyclerViewVerseViewAdapter
    {
        private readonly RecyclerView _recyclerView;
        private readonly SwipeTouchListener _swipeTouchListener;

        public RecyclerViewVerseViewAdapter(Context context, RecyclerView recyclerView)
        {
            _recyclerView = recyclerView;

            _swipeTouchListener = new SwipeTouchListener(context);
            _recyclerView.SetOnTouchListener(_swipeTouchListener);
        }

        public event Action OnSwipeLeft
        {
            add => _swipeTouchListener.OnSwipeLeft += value;
            remove => _swipeTouchListener.OnSwipeLeft -= value;
        }
    }
}