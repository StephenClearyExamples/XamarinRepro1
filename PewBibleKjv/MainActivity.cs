using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using PewBibleKjv.Logic;
using PewBibleKjv.Text;
using PewBibleKjv.VerseView;

namespace PewBibleKjv
{
    [Activity(Label = "PewBibleKjv", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        private App _app;
        private RecyclerViewVerseViewAdapter _verseViewAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set up our view
            SetContentView(Resource.Layout.Main);
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(new VerseAdapter(new TextService(), LayoutInflater));

            // Initialize the app
            _verseViewAdapter = new RecyclerViewVerseViewAdapter(this, recyclerView, layoutManager);

            CreateApp();
        }

        private void CreateApp()
        {
            if (_app != null)
                return;
            _app = new App(_verseViewAdapter);
        }
    }
}

