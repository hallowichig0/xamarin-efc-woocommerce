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
    public class Fragment_chicken : SupportFragment
    {

        //MySqlConnection conn = new MySqlConnection();

        //string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";

        GridView gridview;

        //string[] gridviewstring = {
        //        "location", "sound", "note"
        //};

        //int[] imgview =
        //{
        //    Resource.Drawable.ic_dashboard, Resource.Drawable.ic_headset, Resource.Drawable.ic_dashboard
        //};

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


            //conn.ConnectionString = query;

            //// 
            //MySqlCommand cmd = new MySqlCommand("Select * from wp_kdskli23jkposts where ID in (794)", conn);

            //try
            //{
            //    conn.Open();
            //    MySqlDataReader reader = cmd.ExecuteReader();

            //    //Read, get and loop the data value from the database
            //    while (reader.Read())
            //    {
            //        // variable for getting the value of column ID and GUID in wpwp_kdskli23jkposts
            //        string get_id = reader["ID"].ToString();
            //        string get_img = reader["guid"].ToString();


            //        gridviewstring.Add(get_id);
            //        imgview.Add(get_img);
            //    }
            //}
            //catch (MySqlException ex)
            //{
            //    Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
            //    except.SetTitle("Please report this to our website(error server timeout)");
            //    except.SetMessage(ex.ToString());
            //    except.SetPositiveButton("Ok", (senderAlert, args) =>
            //    {
            //        except.Dispose();
            //    });
            //    except.Show();
            //}
            //finally
            //{
            //    conn.Close();
            //}

            string[] get_id_name = new string[] { "EFC CHICKEN TERIYAKI", "EFC CHICKEN CURRY", "CHICKEN GRATIN WITH MIX VEGETABLES", "CHICKEN TIKKA WITH PAN GRILL BANANA WITH MIX GREENS", "CHICKEN WITH CARAMELIZED APPLE WITH POTATO WEDGES",
            "ROSEMARY CHICKEN BREAST WITH SIMPLE PASTA OR MIX", "ROASTED CHICKEN WITH FUNKY SALAD" };
            string[] get_img = new string[] { "http://earthfashioncafe.com/wp-content/uploads/2018/01/chickenteriyaki-180x180.png", "http://earthfashioncafe.com/wp-content/uploads/2018/01/chickencurry-180x180.png", "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/chicken/CHICKEN_GRATIN_WITH_MIX_VEGETABLES.png", "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/chicken/CHICKEN_TIKKA_WITH_PAN_GRILL_BANANA_WITH_MIX_GREENS.png",
            "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/chicken/CHICKEN_WITH_CARAMELIZED_APPLE_WITH_POTATO_WEDGES.png", "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/chicken/ROASTED_CHICKEN_WITH_FUNKY_SALAD.png",
                "http://soleimer.com/EFC_IMAGES_MOBILE/CATEGORY/chicken/ROSEMARY_CHICKEN_BREAST_WITH_SIMPLE_PASTA_OR_MIX.png" };

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
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_GRATIN_VEGETABLES));
                    StartActivity(myIntent);
                    break;
                case 1:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_TIKKA_PAN_GRILL_BANANA));
                    StartActivity(myIntent);
                    break;
                case 2:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_CARAMELIZED_APPLE_POTATO_WEDGES));
                    StartActivity(myIntent);
                    break;
                case 3:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_CURRY));
                    StartActivity(myIntent);
                    break;
                case 4:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_CHICKEN_TERIYAKI));
                    StartActivity(myIntent);
                    break;
                case 5:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD));
                    StartActivity(myIntent);
                    break;
                case 6:
                    myIntent = new Intent(Activity, typeof(Activity_EFC_ROSEMARY_CHICKEN_BREAST_PASTA_MIX));
                    StartActivity(myIntent);
                    break;
            }

        }
    }
}