# Xamarin bug repro #1

In some cases, an `OnTouchListener` used for swipe detection can cause an `ObjectDisposedException`	for a `GestureDetector` instance.

This problem only shows up when using the Tarjan GC, both with and without concurrent GC. [Setting `MONO_GC_PARAMS=bridge-implementation=new` prevents the exception](https://github.com/StephenClearyApps/PewBible/commit/652a5d7138e0e1f8e0015fe755fbeb7848c3822c).

This seems similar to several other bugs ([this one](https://bugzilla.xamarin.com/show_bug.cgi?id=56902) in particular). However:

- This repro is occurring on Xamarin.Android, not Xamarin.Forms.
- This repro is using a `RecyclerView` of text views, not images and not `ListView` like many similar bugs.
- This repro [uses explicit GCs](https://github.com/StephenClearyExamples/XamarinRepro1/commit/26ba3ec2311161c6738749658185f7d1457b9339) to encourage the bug to manifest quickly. Hundreds of swipes are not necessary to repro.

To repro:

1. Start the project (on a device or emulator). You should see a list of numbers.
1. Scroll the list.
