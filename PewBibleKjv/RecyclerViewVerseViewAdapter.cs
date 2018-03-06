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

namespace PewBibleKjv
{
    public sealed class RecyclerViewVerseViewAdapter
    {
        private readonly RecyclerView _recyclerView;
        public SwipeTouchListener SwipeTouchListener { get; }

        public RecyclerViewVerseViewAdapter(Context context, RecyclerView recyclerView)
        {
            _recyclerView = recyclerView;

            SwipeTouchListener = new SwipeTouchListener(context);
            _recyclerView.SetOnTouchListener(SwipeTouchListener);
        }
    }
}