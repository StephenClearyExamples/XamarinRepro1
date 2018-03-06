using System;

namespace PewBibleKjv.Logic.Adapters.UI
{
    /// <summary>
    /// The UI that displays a scrollable list of verses.
    /// </summary>
    public interface IVerseView
    {
        /// <summary>
        /// Notification that the user (or <see cref="Jump"/>) has scrolled the view. <see cref="CurrentAbsoluteVerseNumber"/> should already be updated before this event is raised.
        /// </summary>
        event Action OnScroll;

        /// <summary>
        /// Notification that the user has swiped left. <see cref="CurrentAbsoluteVerseNumber"/> has not been updated yet.
        /// </summary>
        event Action OnSwipeLeft;

        /// <summary>
        /// Notification that the user has swiped left. <see cref="CurrentAbsoluteVerseNumber"/> has not been updated yet.
        /// </summary>
        event Action OnSwipeRight;

        /// <summary>
        /// Returns the current verse number at the top of the view.
        /// </summary>
        int CurrentAbsoluteVerseNumber { get; }
    }
}
