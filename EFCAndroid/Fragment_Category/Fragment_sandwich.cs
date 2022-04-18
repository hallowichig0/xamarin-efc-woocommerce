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
using Android.Support.V4.App;
using MySql.Data.MySqlClient;
using System.Data;
using EFCAndroid.clicked_menu;

namespace EFCAndroid.Fragment_Category
{
    public class Fragment_sandwich : SupportFragment
    {

        GridView gridview;
        List<string> gridviewstring = new List<string>();
        //List<int> imgview = new List<int>();
        List<string> imgview = new List<string>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.fragment_for_category_beef_fish_etc, container, false);


            string[] get_id_name = new string[] { "CHICKEN PITA", "GRILLED BEEF WITH MOZZARELLA CHEESE", "GRILLED VEGGIE SANDWICH", };
            string[] get_img = new string[] { "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/sandwich/CHICKEN-PITA.png", "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/sandwich/GRILLED-BEEF-WITH-MOZZARELLA.png",
            "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/sandwich/GRILLED-VEGGIE-SANDWICH.png" };

            // ASC
            Array.Sort(get_id_name, get_img, Comparer<string>.Create((x, y) => x.CompareTo(y)));

            // DESC --> change x.compareTo(y) into y.compareTo(x)
            //Array.Sort(get_id_name, get_img, Comparer<string>.Create((x, y) => y.CompareTo(x)));

            gridviewstring.AddRange(get_id_name);
            imgview.AddRange(get_img);

            //gridviewstring.Add("location");
            //gridviewstring.Add("music");
            //gridviewstring.Add("book");

            //imgview.Add(Resource.Drawable.ic_dashboard);
            //imgview.Add(Resource.Drawable.ic_headset);
            //imgview.Add(Resource.Drawable.ic_dashboard);

            //imgview.Add("");

            string[] GridViewStringArray = gridviewstring.ToArray();
            //int[] GridImgViewArray = imgview.ToArray();
            string[] GridImgViewArray = imgview.ToArray();
            CustomGridViewAdapter adapter = new CustomGridViewAdapter(Activity, GridViewStringArray, GridImgViewArray);
            gridview = view.FindViewById<GridView>(Resource.Id.grid_view_image_text);
            gridview.Adapter = adapter;
            gridview.ItemClick += Gridview_ItemClick;
            return view;
        }

        private void Gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent myIntent;
            switch (e.Position)
            {
                case 0:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_PITA));
                    StartActivity(myIntent);
                    break;
                case 1:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_GRILLED_BEEF_MOZZARELLA_CHEESE));
                    StartActivity(myIntent);
                    break;
                case 2:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_GRILLED_VEGGIE_SANDWICH));
                    StartActivity(myIntent);
                    break;
            }
        }
    }
}