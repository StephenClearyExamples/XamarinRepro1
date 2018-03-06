using System;
using System.Collections.Generic;
using System.Text;

namespace PewBibleKjv
{
    public sealed class App
    {
        private readonly RecyclerViewVerseViewAdapter _verseView;

        public App(RecyclerViewVerseViewAdapter verseView)
        {
            _verseView = verseView;
            verseView.OnSwipeLeft += MoveNextChapter;
        }

        private void MoveNextChapter()
        {
        }
    }
}
