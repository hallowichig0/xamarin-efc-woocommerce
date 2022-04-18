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
    public class Fragment_beef : SupportFragment
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


            string[] get_id_name = new string[] { "ARROZ ALA CUBANA WITH GARLIC MUSHROOM SPINACH", "BALSAMIC BEEF WITH ONION CONFIT SERVED WITH MIX GREENS", "BEEF WITH CAPSICUM PESTO SERVED WITH MASHED KUMARA", "EFC BEEF TERIYAKI", "EFC BEEF CURRY",
            "MINT BEEF WITH SALSA", "MUSTARD BEEF CUTLETS WITH BASIL CREAM SERVED WITH MASHED POTATO" };
            string[] get_img = new string[] { "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/beef/ARROZ-ALA-CUBANA-WITH-GARLIC.png", "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/beef/BALSAMIC-BEEF-WITH-ONION-CONFIT.png",
            "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/beef/BEEF-WITH-CAPSICUM-PESTO.png", "http://earthfashioncafe.com/wp-content/uploads/2018/01/beefteriyaki-180x180.png", "http://earthfashioncafe.com/wp-content/uploads/2018/01/beefcurry-180x180.png", "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/beef/MINT_BEEF_WITH_SALSA.png",
                "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/beef/MUSTARD-BEEF-CUTLETS-WITH-BASIL.png" };

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
                    myIntent = new Intent(Activity, typeof(Activity_EFC_ARROZ_CUBANA_GARLIC_MUSHROOM_SPINACH));
                    StartActivity(myIntent);
                    break;
                case 1:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BALSAMIC_BEEF_ONION_CONFIT_SERVED));
                    StartActivity(myIntent);
                    break;
                case 2:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BEEF_CAPSICUM_PESTO_MASHED_KUMARA));
                    StartActivity(myIntent);
                    break;
                case 3:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BEEF_CURRY));
                    StartActivity(myIntent);
                    break;
                case 4:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_BEEF_TERIYAKI));
                    StartActivity(myIntent);
                    break;
                case 5:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_MINT_BEEF_SALSA));
                    StartActivity(myIntent);
                    break;
                case 6:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_MUSTARD_BEEF_CUTLETS_BASIL_MASHED));
                    StartActivity(myIntent);
                    break;
            }
        }
    }
}