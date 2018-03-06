using System;
using System.Collections.Generic;
using System.Text;
using PewBibleKjv.Logic.Adapters.UI;
using PewBibleKjv.Text;

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
