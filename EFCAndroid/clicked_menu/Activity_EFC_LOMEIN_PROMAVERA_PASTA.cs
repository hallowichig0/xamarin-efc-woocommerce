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
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Java.Lang;
using Android.Support.V4.App;
using Android.Content.PM;
using MySql.Data.MySqlClient;
using Android.Preferences;
using EFCAndroid.Description_Review;

namespace EFCAndroid.clicked_menu
{
    [Activity(Label = "Activity_EFC_LOMEIN_PROMAVERA_PASTA", /*MainLauncher = true,*/ Theme = "@style/Theme.DesignDemo")]
    public class Activity_EFC_LOMEIN_PROMAVERA_PASTA : AppCompatActivity
    {
        int[] imgview =
        {
            Resource.Drawable.cheese_1, Resource.Drawable.cheese_2, Resource.Drawable.cheese_3
        };
        private SupportToolbar mToolbar;
        private BottomNavigationView bottomNavView;
        private ProgressBar progressbar;
        int progressValue = 0;
        private string session_user = "";

        //ViewPager viewPager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_efc_lomein_primavera_pasta);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);

            SetSupportActionBar(mToolbar);
            SupportActionBar.Title = "LO MEIN PRIMAVERA PASTA";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            // TabLayout with viewPager calling
            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);
            ViewPager viewpager_tablayout = FindViewById<ViewPager>(Resource.Id.viewpager_tablayout);

            SetUpViewPager(viewpager_tablayout);
            tabs.SetupWithViewPager(viewpager_tablayout);
            // end tablayout calling

            //bottom tab layout view

            bottomNavView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavView.NavigationItemSelected += BottomNavView_NavigationItemSelected;

            //end bottom tab layout view

            //viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            //SlidingImage_Adapter slideimageadapter = new SlidingImage_Adapter(this, imgview);
            //viewPager.Adapter = slideimageadapter;


        }


        //TabLayout with viewPager Class

        private void SetUpViewPager(ViewPager viewpager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment_efc_lomein_primavera_pasta_first_tab(), "Product");
            adapter.AddFragment(new Fragment_reviews(), "Reviews");


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

        // When BottomNavView clicked
        private void BottomNavView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {

            // CALLED SESSION VARIABLE
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            session_user = prefs.GetString("myItem_User_ID", null);
            // CALLED SESSION VARIABLE

            // SQL Connection
            MySqlConnection conn = new MySqlConnection();

            string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";
            conn.ConnectionString = query;

            progressbar = FindViewById<ProgressBar>(Resource.Id.progressBar);


            // Threadpool -> synchronize the sql query before it execute.
            Window.SetFlags(WindowManagerFlags.NotTouchable, WindowManagerFlags.NotTouchable);
            progressbar.Visibility = ViewStates.Gone;
            //circleprogressbar.Visibility = ViewStates.Visible;
            new System.Threading.Thread(new System.Threading.ThreadStart(delegate
            {
                while (progressValue < 100)
                {
                    progressValue += 10;
                    //circleprogressbar.Progress = progressValue;
                    progressbar.Progress = progressValue;
                    System.Threading.Thread.Sleep(100);
                }

                try
                {
                    conn.Open();

                    // select if the value have the same result in database
                    MySqlCommand cmd_select = new MySqlCommand("select count(*) from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart.product_name = 'LO MEIN PRIMAVERA PASTA' AND wp_product_cart_add_ons.key_same_result = '1' AND wp_product_cart.customer_name = '" + session_user + "';", conn);

                    int count = Convert.ToInt32(cmd_select.ExecuteScalar());

                    if (count > 0)
                    {
                        // Update the quantity in auto_increment strategy for the same result
                        string UpdateProductCart = "UPDATE wp_product_cart JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id " +
                       "SET wp_product_cart.quantity = wp_product_cart.quantity + 1, wp_product_cart.compute_qty_price = wp_product_cart.compute_qty_price + wp_product_cart.price " +
                       "WHERE wp_product_cart_add_ons.key_same_result = '1' AND wp_product_cart.product_name = 'LO MEIN PRIMAVERA PASTA' AND wp_product_cart.customer_name = '" + session_user + "';";

                        MySqlCommand cmd_update = new MySqlCommand(UpdateProductCart, conn);

                        cmd_update.ExecuteNonQuery();

                        this.RunOnUiThread(() =>
                        {
                            Window.ClearFlags(WindowManagerFlags.NotTouchable);
                            progressbar.Visibility = ViewStates.Invisible;
                            //circleprogressbar.Visibility = ViewStates.Invisible;
                            progressValue = 0;
                        });


                        Looper.Prepare();
                        Toast.MakeText(this, "This item has been added to your cart", ToastLength.Short).Show();
                        Looper.Loop();
                    }
                    else
                    {

                        string insertProductCart = "INSERT INTO wp_product_cart(customer_name, product_name, price, quantity, image, compute_qty_price) values(@customer_name," +
                           "@product_name, @price, @quantity, @image, @compute_qty_price);" +

                        "INSERT INTO wp_product_cart_add_ons(session_order_id, add_ons, add_ons_price, customer_name, key_same_result)" +
                        "VALUES(LAST_INSERT_ID(), @add_ons, @add_ons_price, @customer_name2, @key_same_result);";

                        MySqlCommand cmd_insert = new MySqlCommand(insertProductCart, conn);
                        cmd_insert.Parameters.AddWithValue("@customer_name", session_user);
                        cmd_insert.Parameters.Add("@product_name", MySqlDbType.VarChar).Value = "LO MEIN PRIMAVERA PASTA";
                        cmd_insert.Parameters.Add("@price", MySqlDbType.Double).Value = 215.00;
                        cmd_insert.Parameters.AddWithValue("@quantity", 1);
                        cmd_insert.Parameters.Add("@compute_qty_price", MySqlDbType.Double).Value = 215.00;
                        cmd_insert.Parameters.Add("@image", MySqlDbType.VarChar).Value = "http://earthfashioncafe.com/wp-content/uploads/2018/01/LoMeinPrimeveraPastaPackaging-180x180.png";

                        cmd_insert.Parameters.Add("@add_ons", MySqlDbType.VarChar).Value = "";
                        cmd_insert.Parameters.AddWithValue("@add_ons_price", 0);
                        cmd_insert.Parameters.AddWithValue("@customer_name2", session_user);
                        cmd_insert.Parameters.Add("@key_same_result", MySqlDbType.VarChar).Value = "1";

                        cmd_insert.ExecuteNonQuery();

                        this.RunOnUiThread(() =>
                        {
                            Window.ClearFlags(WindowManagerFlags.NotTouchable);
                            progressbar.Visibility = ViewStates.Invisible;
                            //circleprogressbar.Visibility = ViewStates.Invisible;
                            progressValue = 0;
                        });


                        Looper.Prepare();
                        Toast.MakeText(this, "This item has been added to your cart", ToastLength.Short).Show();
                        Looper.Loop();

                    }

                }
                catch (MySqlException ex)
                {
                    Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(this);
                    except.SetTitle("Connection Timeout");
                    except.SetMessage(ex.ToString());
                    except.SetPositiveButton("Ok", (senderAlert, args) =>
                    {

                        except.Dispose();
                    });
                    except.Show();
                }
                finally
                {
                    conn.Close();
                }

            })).Start();
            // myThread.Start();


            //Intent myintent;
            //switch (e.Item.ItemId)
            //{
            //    case Resource.Id.addCart:
            //        //fragment = new Fragment_menu();
            //        myintent = new Intent(this, typeof(Activity_cart));
            //        StartActivity(myintent);
            //        break;
            //    case Resource.Id.menu_category:
            //        //fragment = new Fragment_category();
            //        break;
            //}
        }
        // end BottomNavView parameter

        // Back navigation button
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
        // end back nav button parameter
    }
}