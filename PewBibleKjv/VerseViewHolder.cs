using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PewBibleKjv
{
    public class VerseViewHolder : RecyclerView.ViewHolder
    {
        public TextView View { get; }

        public VerseViewHolder(View view) : base(view)
        {
            View = view.FindViewById<TextView>(Resource.Id.verseText);
        }
    }
}

