using System;
using System.Collections.Generic;
using System.Text;
using PewBibleKjv.Logic.Adapters.UI;
using PewBibleKjv.Text;

namespace PewBibleKjv.Logic
{
    public sealed class App
    {
        private readonly IVerseView _verseView;

        public App(IVerseView verseView)
        {
            _verseView = verseView;
            verseView.OnSwipeLeft += MoveNextChapter;
        }

        private void MoveNextChapter()
        {
        }
    }
}
