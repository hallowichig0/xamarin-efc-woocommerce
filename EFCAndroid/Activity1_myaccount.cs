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
using EFCAndroid.Fragment_Account;

namespace EFCAndroid
{
    [Activity(Label = "Activity_myaccount", Theme = "@style/Theme.DesignDemo")]
    public class Activity_myaccount : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        //private ProgressBar progressbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_myaccount);
            // Create your application here

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);

            SetSupportActionBar(mToolbar);
            SupportActionBar.Title = "MY ACCOUNT";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            // TabLayout with viewPager calling
            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);
            ViewPager viewpager_tablayout = FindViewById<ViewPager>(Resource.Id.viewpager_tablayout);

            SetUpViewPager(viewpager_tablayout);
            tabs.SetupWithViewPager(viewpager_tablayout);
            // end tablayout calling

        }

        //TabLayout with viewPager Class

        private void SetUpViewPager(ViewPager viewpager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment_myAccount1(), "Account Details");
            adapter.AddFragment(new Fragment_myAccount2(), "Orders");
            adapter.AddFragment(new Fragment_myAccount3(), "Change Password");
            //adapter.AddFragment(new f)


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

        // end tablayout class

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);

            }
        }


    }
}