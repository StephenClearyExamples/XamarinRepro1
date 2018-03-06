using System;
using System.Collections.Generic;
using System.Text;
using PewBibleKjv.Logic.Adapters.UI;
using PewBibleKjv.Text;

namespace PewBibleKjv.Logic
{
    public sealed class App : IDisposable
    {
        private readonly IVerseView _verseView;

        public App(IVerseView verseView)
        {
            _verseView = verseView;

            // Keep track of changes to the verse view.
            verseView.OnSwipeLeft += MoveNextChapter;
        }

        public void Dispose()
        {
            _verseView.OnSwipeLeft -= MoveNextChapter;
        }

        private void MoveNextChapter()
        {
        }
    }
}
