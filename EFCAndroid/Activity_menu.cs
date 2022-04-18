using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;

namespace EFCAndroid
{
    [Activity(Label = "Activity_menu", Theme = "@style/Theme.DesignDemo")]
    public class Activity_menu : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        private BottomNavigationView bottomNavView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_menu);
            // Create your application here

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);

            SetSupportActionBar(mToolbar);
            SupportActionBar.Title = "MENU";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            bottomNavView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            bottomNavView.NavigationItemSelected += BottomNavView_NavigationItemSelected;

            LoadFragment(Resource.Id.menu_home);

        }

        void LoadFragment(int id)
        {
            SupportFragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = new Fragment_menu();
                    break;
                case Resource.Id.menu_category:
                    fragment = new Fragment_category();
                    break;
            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }
        private void BottomNavView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

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