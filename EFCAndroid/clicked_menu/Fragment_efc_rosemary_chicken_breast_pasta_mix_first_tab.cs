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
using System.Threading;
using Android.Support.V4.View;
using Com.ViewPagerIndicator;

namespace EFCAndroid.clicked_menu
{
    public class Fragment_efc_rosemary_chicken_breast_pasta_mix_first_tab : SupportFragment
    {
        private RelativeLayout visibility_viewpager;
        private ScrollView scrolllayout_main_view;
        private LinearLayout visibility_content;
        //private LinearLayout visibility_gridview_viewpager;
        private GridView gridview;
        private ViewPager viewpager_main;
        private TextView txtprice, txtproduct_title, txtcontent;

        string[] imgview_slider_main =
         {
            "http://earthfashioncafe.com/wp-content/uploads/2018/01/RosemaryChickenPackaging-600x600.png",
            "http://earthfashioncafe.com/wp-content/uploads/2018/01/RosemaryChickenPackagingSideView-600x600.png",
            "http://earthfashioncafe.com/wp-content/uploads/2018/01/RosemaryChicken-600x600.png"
        };

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.fragment_efc_rosemary_chicken_breast_pasta_mix_first_tab, container, false);

            // My Custom ViewPager Slider
            viewpager_main = view.FindViewById<ViewPager>(Resource.Id.viewPager_Main);
            SlidingImage_Adapter_Main slideimageadapter_main = new SlidingImage_Adapter_Main(Activity, imgview_slider_main);
            viewpager_main.Adapter = slideimageadapter_main;

            CirclePageIndicator circlePageIndicator_main = view.FindViewById<CirclePageIndicator>(Resource.Id.indicator_main);
            circlePageIndicator_main.SetViewPager(viewpager_main);
            circlePageIndicator_main.SetFillColor(Android.Graphics.Color.Azure);
            circlePageIndicator_main.SetPageColor(Android.Graphics.Color.White);
            // End My Custom ViewPager Slider



            txtproduct_title = view.FindViewById<TextView>(Resource.Id.txtProductTitle);
            txtprice = view.FindViewById<TextView>(Resource.Id.txtPrice);
            txtcontent = view.FindViewById<TextView>(Resource.Id.textcontent);

            txtproduct_title.Text = "ROSEMARY CHICKEN BREAST WITH SIMPLE PASTA OR MIX";
            txtprice.Text = "\n₱295.00";
            txtcontent.Text = "\nThe EFC Rosemary Chicken is one of the most savory dishes that you would want to be part of your daily meal! Cooked with fresh chicken breast that is marinated to perfection with a kiss of the finest red wine and a pinch of salt and pepper. Best served with fresh pasta cooked to al dente, tossed with crisp mixed greens and balanced with the succulent taste tomatoes. The best dish that you will crave for without the additional calorie! Best for those who are health conscious and want to stay fit. Every day is cheat day with this dish!";


            return view;
        }

    }
}