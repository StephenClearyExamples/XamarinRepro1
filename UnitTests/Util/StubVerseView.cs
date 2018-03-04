﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PewBibleKjv.Logic;
using PewBibleKjv.Logic.Adapters.UI;

namespace UnitTests.Util
{
    public sealed class StubVerseView: IVerseView
    {
        public event Action<Location> OnScroll;
        public void RaiseOnScroll(Location location) => OnScroll?.Invoke(location);
        public int CurrentAbsoluteVerseNumber { get; set; }

        public void Jump(int absoluteVerseNumber)
        {
            CurrentAbsoluteVerseNumber = absoluteVerseNumber;
            RaiseOnScroll(Location.Create(absoluteVerseNumber));
        }
    }
}