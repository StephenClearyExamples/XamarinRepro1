﻿using System;
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
using PewBibleKjv.Logic;
using PewBibleKjv.Logic.Adapters.UI;
using PewBibleKjv.Text;
using PewBibleKjv.VerseView;

namespace PewBibleKjv
{
    public sealed class RecyclerViewVerseViewAdapter: IVerseView
    {
        private readonly RecyclerView _recyclerView;
        private readonly LinearLayoutManager _layoutManager;
        private readonly SwipeTouchListener _swipeTouchListener;

        public RecyclerViewVerseViewAdapter(Context context, RecyclerView recyclerView, LinearLayoutManager layoutManager)
        {
            _recyclerView = recyclerView;
            _layoutManager = layoutManager;

            _swipeTouchListener = new SwipeTouchListener(context);
            _recyclerView.SetOnTouchListener(_swipeTouchListener);
        }

        public event Action OnScroll;
        public event Action OnSwipeLeft
        {
            add => _swipeTouchListener.OnSwipeLeft += value;
            remove => _swipeTouchListener.OnSwipeLeft -= value;
        }
        public event Action OnSwipeRight
        {
            add => _swipeTouchListener.OnSwipeRight += value;
            remove => _swipeTouchListener.OnSwipeRight -= value;
        }
        
        public int CurrentAbsoluteVerseNumber => _layoutManager.FindFirstVisibleItemPosition();

        public Location CurrentVerseLocation
        {
            get
            {
                var viewHolder = _recyclerView.FindViewHolderForLayoutPosition(CurrentAbsoluteVerseNumber);
                return ((VerseViewHolder)viewHolder).Location;
            }
        }

        public void Jump(int absoluteVerseNumber)
        {
            _layoutManager.ScrollToPositionWithOffset(absoluteVerseNumber, 0);
        }
    }
}