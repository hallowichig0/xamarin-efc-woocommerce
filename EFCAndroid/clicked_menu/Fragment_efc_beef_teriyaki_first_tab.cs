﻿using System;
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
    public class Fragment_efc_beef_teriyaki_first_tab : SupportFragment
    {
        private RelativeLayout visibility_viewpager;
        private ScrollView scrolllayout_main_view;
        private LinearLayout visibility_content;
        //private LinearLayout visibility_gridview_viewpager;
        private GridView gridview;
        private ViewPager viewpager_main;
        private TextView txtprice, txtproduct_title, txtcontent;

        // my custom viewpager slider variable
        string[] imgview_slider_main =
        {
            "http://earthfashioncafe.com/wp-content/uploads/2018/01/beefteriyaki-600x600.png",
            "http://earthfashioncafe.com/wp-content/uploads/2017/09/beefteriyakiedited1-600x397.jpg",
            "http://earthfashioncafe.com/wp-content/uploads/2017/09/beefteriyakisideview-600x397.jpg"
        };
        // end custom viewpager slider variable

        // my custom gridview variable
        string[] imgview_gridview =
        {
            "http://earthfashioncafe.com/wp-content/uploads/2017/09/beefteriyakiFullRiceMeal.jpg",
            "http://earthfashioncafe.com/wp-content/uploads/2017/09/TeriyakiSauce.jpg",
            "http://earthfashioncafe.com/wp-content/uploads/2017/09/Extrarice.jpg"
        };
        // end custom gridview variable

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.fragment_efc_beef_teriyaki_first_tab, container, false);

            // My Custom ViewPager Slider
            viewpager_main = view.FindViewById<ViewPager>(Resource.Id.viewPager_Main);
            SlidingImage_Adapter_Main slideimageadapter_main = new SlidingImage_Adapter_Main(Activity, imgview_slider_main);
            viewpager_main.Adapter = slideimageadapter_main;

            CirclePageIndicator circlePageIndicator_main = view.FindViewById<CirclePageIndicator>(Resource.Id.indicator_main);
            circlePageIndicator_main.SetViewPager(viewpager_main);
            circlePageIndicator_main.SetFillColor(Android.Graphics.Color.Azure);
            circlePageIndicator_main.SetPageColor(Android.Graphics.Color.White);
            // End My Custom ViewPager Slider

            // custom gridview
            CustomGridViewAdapter_clicked_menu adapter = new CustomGridViewAdapter_clicked_menu(Activity, imgview_gridview);

            gridview = view.FindViewById<GridView>(Resource.Id.grid_view_image_text);
            gridview.Adapter = adapter;
            // end custom gridview

            // ViewPager Zoom Image when clicked
            ViewPager viewpager_zoom_image = view.FindViewById<ViewPager>(Resource.Id.viewPager_Zoom);

            visibility_viewpager = view.FindViewById<RelativeLayout>(Resource.Id.zoom_relative_viewpager);
            visibility_content = view.FindViewById<LinearLayout>(Resource.Id.frame_main);
            scrolllayout_main_view = view.FindViewById<ScrollView>(Resource.Id.scroll_main);
            // end viewpager zoom image variable



            Button btnZoomImg = view.FindViewById<Button>(Resource.Id.buttonZoomImage);
            btnZoomImg.Click += BtnZoomImg_Click;

            txtproduct_title = view.FindViewById<TextView>(Resource.Id.txtProductTitle);
            txtprice = view.FindViewById<TextView>(Resource.Id.txtPrice);
            txtcontent = view.FindViewById<TextView>(Resource.Id.textcontent);

            txtproduct_title.Text = "EFC BEEF TERIYAKI";
            txtprice.Text = "\n₱189.00";
            txtcontent.Text = "\nThe Premium EFC Teriyaki has NO ADDED sugar, combined with the freshest ingredients to achieve it’s wonderful taste without the extra fats in your belly." +
"\n\nBlended well with the tenderest meat, the sweet taste of mirin, seasoned with kikoman soy sauce, the fresh spicy and pungent taste of ginger, the fragrant and nutty sesame oil, savoured by the  citrusy tinge of pineapple." +
  "\n\nWe have also added garden-fresh bean sprouts as well as the sweet and crisp carrots, perfect for your healthy lifestyle without sabotaging the delicious taste in it.";

            //When gridview item selected
            gridview.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {

                string[] zoom_imgview = new string[3];
                switch (e.Position)
                {

                    case 0:
                        zoom_imgview[0] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/beefteriyakiFullRiceMeal.jpg";
                        zoom_imgview[1] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/TeriyakiSauce.jpg";
                        zoom_imgview[2] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/Extrarice.jpg";

                        visibility_viewpager.Visibility = ViewStates.Visible;
                        visibility_content.Visibility = ViewStates.Gone;
                        scrolllayout_main_view.Visibility = ViewStates.Gone;
                        break;
                    case 1:
                        zoom_imgview[0] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/TeriyakiSauce.jpg";
                        zoom_imgview[1] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/Extrarice.jpg";
                        zoom_imgview[2] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/beefteriyakiFullRiceMeal.jpg";

                        visibility_viewpager.Visibility = ViewStates.Visible;
                        visibility_content.Visibility = ViewStates.Gone;
                        scrolllayout_main_view.Visibility = ViewStates.Gone;
                        break;
                    case 2:
                        zoom_imgview[0] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/Extrarice.jpg";
                        zoom_imgview[1] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/beefteriyakiFullRiceMeal.jpg";
                        zoom_imgview[2] = "http://earthfashioncafe.com/wp-content/uploads/2017/09/TeriyakiSauce.jpg";

                        visibility_viewpager.Visibility = ViewStates.Visible;
                        visibility_content.Visibility = ViewStates.Gone;
                        scrolllayout_main_view.Visibility = ViewStates.Gone;
                        break;
                    default:
                        break;

                }
                SlidingImage_Adapter slideimageadapter = new SlidingImage_Adapter(Activity, zoom_imgview);
                viewpager_zoom_image.Adapter = slideimageadapter;

                CirclePageIndicator circlePageIndicator = view.FindViewById<CirclePageIndicator>(Resource.Id.indicator);
                circlePageIndicator.SetViewPager(viewpager_zoom_image);
                circlePageIndicator.SetFillColor(Android.Graphics.Color.Azure);
                circlePageIndicator.SetPageColor(Android.Graphics.Color.White);
            };
            //end gridview item selected

            return view;
        }

        private void BtnZoomImg_Click(object sender, EventArgs e)
        {
            visibility_viewpager.Visibility = ViewStates.Gone;
            visibility_content.Visibility = ViewStates.Visible;
            scrolllayout_main_view.Visibility = ViewStates.Visible;
        }
    }
}