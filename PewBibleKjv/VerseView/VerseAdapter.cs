using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using PewBibleKjv.Logic;
using PewBibleKjv.Text;

namespace PewBibleKjv.VerseView
{
    public class VerseAdapter : RecyclerView.Adapter
    {
        private readonly TextService _data;
        private readonly LayoutInflater _layoutInflater;

        public VerseAdapter(TextService data, LayoutInflater layoutInflater)
        {
            _data = data;
            _layoutInflater = layoutInflater;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (VerseViewHolder)holder;
            vh.Location = _data[position];
            vh.View.Text = position.ToString();
            GC.Collect();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var verseView = _layoutInflater.Inflate(Resource.Layout.VerseLayout, parent, attachToRoot: false);
            return new VerseViewHolder(verseView);
        }

        public override int ItemCount => _data.Count;
    }
}