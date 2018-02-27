﻿using System.Runtime.InteropServices;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using PewBibleKjv.Services;
using PewBibleKjv.Text;
using Debug = System.Diagnostics.Debug;

namespace PewBibleKjv
{
    [Activity(Label = "PewBibleKjv", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(new TestAdapter(TextService.Instance));
            recyclerView.AddOnScrollListener(new ScrollListener(layoutManager));
            recyclerView.ScrollToPosition(1000);
        }

        public class ScrollListener : RecyclerView.OnScrollListener
        {
            private readonly LinearLayoutManager _layoutManager;

            public ScrollListener(LinearLayoutManager layoutManager)
            {
                _layoutManager = layoutManager;
            }

            public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
            {
                var firstIndex = _layoutManager.FindFirstVisibleItemPosition();
                Debug.WriteLine("Scrolled to position: " + firstIndex);
                var view = (TestViewHolder)recyclerView.FindViewHolderForLayoutPosition(firstIndex);
                Debug.WriteLine("Scrolled to verse: " + view.Location);
            }
        }

        public class TestViewHolder : RecyclerView.ViewHolder
        {
            public TextView View { get; }
            public Location Location { get; set; }

            public TestViewHolder(TextView view) : base(view)
            {
                View = view;
            }
        }

        public class TestAdapter : RecyclerView.Adapter
        {
            private readonly TextService _data;

            public TestAdapter(TextService data)
            {
                _data = data;
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var vh = (TestViewHolder)holder;
                vh.Location = _data[position];
                vh.View.Text = Bible.FormattedVerse(vh.Location.AbsoluteVerseNumber).Text;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                return new TestViewHolder(new TextView(parent.Context));
            }

            public override int ItemCount => _data.Count;
        }
    }
}

