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
using Java.Util;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using MySql.Data.MySqlClient;
using Android.Support.V4.App;

namespace EFCAndroid
{
    public class Fragment_category : SupportFragment
    {
      
        private List<string> mleftdata;
        private ListView list1;
        private ArrayAdapter<string> madapter;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_category, container, false);

            list1 = view.FindViewById<ListView>(Resource.Id.listview1);
            string[] mleftdata_Array = new string[] {"Chicken", "Beef", "Fish", "Vegan", "Pasta", "Sandwich", "Salad"};
            mleftdata = new List<string>();

            mleftdata.AddRange(mleftdata_Array);
           
            madapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, mleftdata.ToArray());

            list1.Adapter = madapter;

            list1.ItemClick += List1_ItemClick;

            // may slow the first load of category fragment
            LoadFragment(0);

            return view;
        }

        void LoadFragment(int id)
        {
            SupportFragment fragment = null;
            switch (id)
            {
                case 0:
                    fragment = new Fragment_Category.Fragment_chicken();
                    break;
                case 1:
                    fragment = new Fragment_Category.Fragment_beef();
                    break;
                case 2:
                    fragment = new Fragment_Category.Fragment_fish();
                    break;
                case 3:
                    fragment = new Fragment_Category.Fragment_vegan();
                    break;
                case 4:
                    fragment = new Fragment_Category.Fragment_pasta();
                    break;
                case 5:
                    fragment = new Fragment_Category.Fragment_sandwich();
                    break;
                    case 6:
                    fragment = new Fragment_Category.Fragment1_salad();
                    break;
            }

            if (fragment == null)
                return;
            
            
            Activity.SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame_category, fragment)
                .Commit();
        }

        private void List1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Intent myIntent;
            //switch (e.Position)
            //{
            //    case 0:
            //        myIntent = new Intent(this, typeof(Activity1));
            //        StartActivity(myIntent);
            //        break;
            //}

            LoadFragment(e.Position);

        }
    }
}