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
using System.Security.Cryptography;
using DevOne.Security.Cryptography.BCrypt;
using System.Threading;
using Android.Preferences;
using Android.Animation;

namespace EFCAndroid.Description_Review
{
    public class Fragment_description_chicken_teriyaki : SupportFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_description_chicken_teriyaki, container, false);

            return view;
        }
    }
}