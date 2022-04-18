using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Preferences;

namespace EFCAndroid
{
    [Activity(Label = "index", Theme = "@style/Theme.DesignDemo")]
    public class index : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        private BottomNavigationView bottomNavView;
        private DrawerLayout mDrawerLayout;
        private TextView myUser1;
        public string setFragment1User;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.index);
            // Create your application here

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);

            SetSupportActionBar(mToolbar);

            SupportActionBar ab = SupportActionBar;
            ab.Title = "Earth Fashion Cafe";
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            ab.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Navigation Menu
            NavigationView navigationview = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationview != null)
            {
                SetUpDrawerContent(navigationview);
            }

            //username variable from fragment1 --> this was stored the data value from user_login database
            //setFragment1User = Intent.GetStringExtra("myItem_user") ?? "data not available";

            
            //nav_header-->header_layout
            var headerView = navigationview.GetHeaderView(0);

            myUser1 = headerView.FindViewById<TextView>(Resource.Id.navUser);
            //myUser1.Text = setFragment1User;

            // CALLED SESSION VARIABLE
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            myUser1.Text = prefs.GetString("myItem_User_ID", null);
            // CALLED SESSION VARIABLE

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
                .Replace(Resource.Id.content_frame_main, fragment)
                .Commit();
        }

        private void BottomNavView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        // DrawerLayout Hamburger Open
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void SetUpDrawerContent(NavigationView navigationview)
        {
            
            navigationview.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                //mDrawerLayout.CloseDrawers();

                Intent myIntent;
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_checkout:
                        myIntent = new Intent(this, typeof(Activity_checkout));
                        StartActivity(myIntent);
                        break;
                    case Resource.Id.nav_cart:
                        myIntent = new Intent(this, typeof(Activity_cart));
                        StartActivity(myIntent);
                        break;
                    case Resource.Id.nav_myaccount:
                        myIntent = new Intent(this, typeof(Activity_myaccount));
                        StartActivity(myIntent);
                        break;
                    case Resource.Id.nav_logout:
                        mDrawerLayout.CloseDrawers();
                        Finish();
                        break;

                }
                
                
            };
        }

    }
}