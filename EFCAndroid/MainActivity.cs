using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Java.Lang;
using MySql.Data.MySqlClient;
namespace EFCAndroid
{
    [Activity(Label = "EarthFashionCafe", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        private SupportToolbar mToolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            SupportActionBar.Title = "Login/Sign up";
            //ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            //ab.SetDisplayHomeAsUpEnabled(true);



            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewpager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewpager);

            tabs.SetupWithViewPager(viewpager);

            // SnackBar
            //FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            //fab.Click += (o, e) =>
            //{
            //    View anchor = o as View;

            //    Snackbar.Make(anchor, "Yay Snackbar!!", Snackbar.LengthLong)
            //    .SetAction("Action", v =>
            //    {
            //        //Do something here
            //        //Intent intent new Intent();
            //    })
            //    .Show();
            //};



        }

        // DrawerLayout Navigation Menu
        //private void SetUpDrawerContent(NavigationView navigationview)
        //{
        //    navigationview.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
        //    {
        //        Intent myIntent;
        //        switch(e.MenuItem.ItemId)
        //        {
        //            case Resource.Id.nav_menu:
        //                myIntent = new Intent(this, typeof(Activity_menu));
        //                StartActivity(myIntent);
        //                break;
        //            case Resource.Id.nav_checkout:
        //                myIntent = new Intent(this, typeof(Activity_checkout));
        //                StartActivity(myIntent);
        //                break;
        //            case Resource.Id.nav_cart:
        //                myIntent = new Intent(this, typeof(Activity_cart));
        //                StartActivity(myIntent);
        //                break;
        //            case Resource.Id.nav_myaccount:
        //                myIntent = new Intent(this, typeof(Activity_myaccount));
        //                StartActivity(myIntent);
        //                break;
        //        }
        //        //mDrawerLayout.CloseDrawers();
        //    };
        //}


        //// DrawerLayout Hamburger Open
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Android.Resource.Id.Home:
        //            mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
        //            return true;

        //        default:
        //            return base.OnOptionsItemSelected(item);
        //    }
        //}

        private void SetUpViewPager(ViewPager viewpager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment1(), "Login");
            adapter.AddFragment(new Fragment2(), "Sign Up");


            viewpager.Adapter = adapter;
        }




        public class TabAdapter : FragmentPagerAdapter
        {
            public List<SupportFragment> Fragments { get; set; }
            public List<string> FragmentNames { get; set; }

            public TabAdapter(SupportFragmentManager sfm) : base(sfm)
            {
                Fragments = new List<Android.Support.V4.App.Fragment>();
                FragmentNames = new List<string>();
            }

            public void AddFragment(SupportFragment fragment, string name)
            {
                Fragments.Add(fragment);
                FragmentNames.Add(name);
            }
            public override int Count
            {
                get
                {
                    return Fragments.Count;
                }
            }
            public override SupportFragment GetItem(int position)
            {
                return Fragments[position];
            }
            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(FragmentNames[position]);
            }
        }

    }
}

