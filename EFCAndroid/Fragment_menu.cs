using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using MySql.Data.MySqlClient;
using Android.Support.V4.App;
using Android.Views.Animations;
using System.Data;
using EFCAndroid.clicked_menu;
using Android.Support.V4.View;
using Com.ViewPagerIndicator;

namespace EFCAndroid
{
    public class Fragment_menu : SupportFragment, View.IOnTouchListener
    {
        MySqlConnection conn = new MySqlConnection();

        string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";

        GridView gridview;
        List<string> gridviewstring = new List<string>();

        List<string> imgview = new List<string>();
        string[] GridViewStringArray;
        //public string setFragment1User;

       

        // my custom viewpager slider
        private ViewPager viewpager_main;
        string[] imgview_slider_main =
        {
            //"http://earthfashioncafe.com/wp-content/uploads/2017/09/RevisedBannerEFC2-2-3-1.jpg",
            //"http://earthfashioncafe.com/wp-content/uploads/2018/02/efcbannerNEWMENU2.jpg",
            //"http://earthfashioncafe.com/wp-content/uploads/2017/09/RevisedBannerEFC2-2-3-1.jpg"
            "http://earthfashioncafe.com/wp-content/uploads/2018/07/efc_banner_1.jpg",
            "http://earthfashioncafe.com/wp-content/uploads/2018/07/efc_banner_2.jpg",
            "http://earthfashioncafe.com/wp-content/uploads/2018/07/efc_banner_3.jpg"
        };
        // end custom

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_menu, container, false);

            // My Custom ViewPager Slider
            viewpager_main = view.FindViewById<ViewPager>(Resource.Id.viewPager_Main);
            SlidingImage_Adapter_Main slideimageadapter_main = new SlidingImage_Adapter_Main(Activity, imgview_slider_main);
            viewpager_main.Adapter = slideimageadapter_main;

            CirclePageIndicator circlePageIndicator_main = view.FindViewById<CirclePageIndicator>(Resource.Id.indicator_main);
            circlePageIndicator_main.SetViewPager(viewpager_main);
            circlePageIndicator_main.SetFillColor(Android.Graphics.Color.Azure);
            circlePageIndicator_main.SetPageColor(Android.Graphics.Color.White);
            // End My Custom ViewPager Slider

            // Set The Auto-Slide for viewpager
            var timer = new System.Timers.Timer();
            timer.Interval = 4000;
            timer.Enabled = true;
            int page = 0;
            timer.Elapsed += (sender, args) =>
            {
                Activity.RunOnUiThread(() =>
                {
                    if (page <= viewpager_main.Adapter.Count)
                    {
                        page++;
                    }
                    else
                    {
                        page = 0;
                    }
                    viewpager_main.SetCurrentItem(page, true);
                });
            };
            // End Auto-Slide for viewpager

            //// ViewFlipper Animation
            //viewflipper = view.FindViewById<ViewFlipper>(Resource.Id.viewFlipper);
            //viewflipper.SetInAnimation(Activity, Resource.Animation.fade_in);
            //viewflipper.SetOutAnimation(Activity, Resource.Animation.fade_out);
            //viewflipper.SetFlipInterval(5000);
            //viewflipper.StartFlipping();
            //// End ViewFlipper Animation

            conn.ConnectionString = query;
            //MySqlCommand cmd = new MySqlCommand("Select * from wp_kdskli23jkposts where ID in (794)", conn);
            MySqlCommand cmd = new MySqlCommand("Select * from wp_mobile_product order by category asc;", conn);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read, get and loop the data value from the database
                while (reader.Read())
                {
                    // variable for getting the value of column ID and GUID in wp_kdskli23jkposts
                    string get_title = reader["product_title"].ToString();
                    string get_img = reader["product_image"].ToString();


                    gridviewstring.Add(get_title);
                    imgview.Add(get_img);
                }
            }
            catch (MySqlException ex)
            {
                Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                except.SetTitle("Please report this to our website(error server timeout)");
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

            GridViewStringArray = gridviewstring.ToArray();
            //int[] GridImgViewArray = imgview.ToArray();
            string[] GridImgViewArray = imgview.ToArray();
            CustomGridViewAdapter_for_Menu adapter = new CustomGridViewAdapter_for_Menu(Activity, GridViewStringArray, GridImgViewArray);
            gridview = view.FindViewById<GridView>(Resource.Id.grid_view_image_text);


            gridview.Adapter = adapter;

            int index = gridview.FirstVisiblePosition;

            gridview.SmoothScrollToPosition(index);


            gridview.SetOnTouchListener(this);


            gridview.ItemClick += Gridview_ItemClick;

            return view;

        }

        private void Gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            Intent myIntent;
            switch (e.Position)
            {
                case 0:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_ARROZ_CUBANA_GARLIC_MUSHROOM_SPINACH));
                    StartActivity(myIntent);
                    break;
                case 1:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_MINT_BEEF_SALSA));
                    StartActivity(myIntent);
                    break;
                case 2:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BALSAMIC_BEEF_ONION_CONFIT_SERVED));
                    StartActivity(myIntent);
                    break;
                case 3:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_MUSTARD_BEEF_CUTLETS_BASIL_MASHED));
                    StartActivity(myIntent);
                    break;
                case 4:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BEEF_CAPSICUM_PESTO_MASHED_KUMARA));
                    StartActivity(myIntent);
                    break;
                case 5:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BEEF_TERIYAKI));
                    StartActivity(myIntent);
                    break;
                case 6:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BEEF_CURRY));
                    StartActivity(myIntent);
                    break;
                case 7:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_GRATIN_VEGETABLES));
                    StartActivity(myIntent);
                    break;
                case 8:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD));
                    StartActivity(myIntent);
                    break;
                case 9:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_CARAMELIZED_APPLE_POTATO_WEDGES));
                    StartActivity(myIntent);
                    break;
                case 10:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_ROSEMARY_CHICKEN_BREAST_PASTA_MIX));
                    StartActivity(myIntent);
                    break;
                case 11:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_TIKKA_PAN_GRILL_BANANA));
                    StartActivity(myIntent);
                    break;
                case 12:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_TERIYAKI));
                    StartActivity(myIntent);
                    break;
                case 13:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_CURRY));
                    StartActivity(myIntent);
                    break;
                case 14:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHIMICHURRI_FISH_RICE_MIX_GREENS));
                    StartActivity(myIntent);
                    break;
                case 15:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_GINGER_FISH_DRIZZLED_WASABI_BROWN));
                    StartActivity(myIntent);
                    break;
                case 16:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_DILL_PESTO_TUNA));
                    StartActivity(myIntent);
                    break;
                case 17:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_YOGURT_SALMON_SUNDRIED_TOMATO));
                    StartActivity(myIntent);
                    break;
                case 18:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHEESY_COLD_PASTA));
                    StartActivity(myIntent);
                    break;
                case 19:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_PESTO_PASTA_CHICKEN_BREAST));
                    StartActivity(myIntent);
                    break;
                case 20:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_SEAFOOD_MARINA));
                    StartActivity(myIntent);
                    break;
                case 21:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_FUNKY_FRUIT_SALAD));
                    StartActivity(myIntent);
                    break;
                case 22:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_MEDITERESIAN_CHICKEN_SALAD));
                    StartActivity(myIntent);
                    break;
                case 23:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_SALAD_NICOISE));
                    StartActivity(myIntent);
                    break;
                case 24:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_PITA));
                    StartActivity(myIntent);
                    break;
                case 25:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_GRILLED_VEGGIE_SANDWICH));
                    StartActivity(myIntent);
                    break;
                case 26:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_GRILLED_BEEF_MOZZARELLA_CHEESE));
                    StartActivity(myIntent);
                    break;
                case 27:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BARBECUE_CAULIFLOWER_MASHED_POTATO));
                    StartActivity(myIntent);
                    break;
                case 28:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_ROASTED_SQUASH_TOFU_PUMPKIN_PUREE));
                    StartActivity(myIntent);
                    break;
                case 29:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CREAMY_VEGAN_PENNE));
                    StartActivity(myIntent);
                    break;
                case 30:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_TOFU_STEAK_MUSHROOM));
                    StartActivity(myIntent);
                    break;
                case 31:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_LOMEIN_PROMAVERA_PASTA));
                    StartActivity(myIntent);
                    break;
            }
            
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    v.Parent.RequestDisallowInterceptTouchEvent(true);
                    break;
                case MotionEventActions.Up:
                    v.Parent.RequestDisallowInterceptTouchEvent(false);
                    break;
            }
            v.OnTouchEvent(e);
            return true;
        }

        //public bool OnTouchEvent(MotionEvent ontouch)
        //{

        //    //switch (ontouch.Action)
        //    switch (ontouch.Action)
        //    {
        //        case MotionEventActions.Down:
        //            initialX = ontouch.GetX();
        //            break;
        //        case MotionEventActions.Up:
        //            float finalX = ontouch.GetX();
        //            if (initialX > finalX)
        //            {
        //                if (viewflipper.DisplayedChild == 1)
        //                    break;
        //                //viewflipper.SetInAnimation(this, Resource.Animation.fade_in);
        //                //viewflipper.SetInAnimation(this, Resource.Animation.fade_out);
        //                viewflipper.ShowNext();
        //            }
        //            else
        //            {
        //                if (viewflipper.DisplayedChild == 0)
        //                    break;
        //                //viewflipper.SetInAnimation(this, Resource.Animation.fade_in);
        //                //viewflipper.SetInAnimation(this, Resource.Animation.fade_out);
        //                viewflipper.ShowPrevious();
        //            }
        //            break;
        //    }
        //    return false;
        //}

    }
}