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
            verseView.OnScroll += UpdateCurrentLocation;
            verseView.OnSwipeLeft += MoveNextChapter;
            verseView.OnSwipeRight += MovePreviousChapter;
        }

        public void Dispose()
        {
            _verseView.OnScroll -= UpdateCurrentLocation;
            _verseView.OnSwipeLeft -= MoveNextChapter;
            _verseView.OnSwipeRight -= MovePreviousChapter;
        }

        private void MovePreviousChapter()
        {
            _verseView.Jump(_verseView.CurrentVerseLocation.PreviousChapter().AbsoluteVerseNumber);
        }

        private void MoveNextChapter()
        {
            _verseView.Jump(_verseView.CurrentVerseLocation.NextChapter().AbsoluteVerseNumber);
        }

        private void UpdateCurrentLocation()
        {
        }
    }
}
