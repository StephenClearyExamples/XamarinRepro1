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

You should see an exception:

```
System.ObjectDisposedException: Cannot access a disposed object.
Object name: 'Android.Views.GestureDetector'.
  at Java.Interop.JniPeerMembers.AssertSelf (Java.Interop.IJavaPeerable self) [0x00029] in <e8c0e16a54534fa885244f0ad837c79e>:0 
  at Java.Interop.JniPeerMembers+JniInstanceMethods.InvokeVirtualBooleanMethod (System.String encodedMember, Java.Interop.IJavaPeerable self, Java.Interop.JniArgumentValue* parameters) [0x00000] in <e8c0e16a54534fa885244f0ad837c79e>:0 
  at Android.Views.GestureDetector.OnTouchEvent (Android.Views.MotionEvent ev) [0x00031] in <848bbd7c681a4975918c72f17d2f5144>:0 
  at PewBibleKjv.SwipeTouchListener.OnTouch (Android.Views.View v, Android.Views.MotionEvent e) [0x00002] in C:\\Work\\XamarinRepro1\\PewBibleKjv\\SwipeTouchListener.cs:24
```
