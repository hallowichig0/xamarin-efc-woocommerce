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
using MySql.Data.MySqlClient;

namespace EFCAndroid.Fragment_Account
{
    public class Fragment_myAccount2 : SupportFragment
    {
       
        private ListView mListView;

        private List<Person> mItems;

        private ProgressBar progressbar;
        int progressValue = 0;

        // SESSION VARIABLE
        string session_user = "";
        // SESSION VARIABLE

        MySqlConnection conn = new MySqlConnection();

        string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.Fragment_myAccount2, container, false);

            // CALLED SESSION VARIABLE
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Activity);
            session_user = prefs.GetString("myItem_User_ID", null);
            // CALLED SESSION VARIABLE

            mListView = view.FindViewById<ListView>(Resource.Id.listView1);

            mItems = new List<Person>();

            
            mItems.Add(new Person() { Order = "ORDER", Date = "DATE", Status = "STATUS", Actions = "ACTIONS" });

            

            // QUERY DATABASE
            conn.ConnectionString = query;
            MySqlCommand cmd = new MySqlCommand("Select * from wp_kdskli23jkposts INNER JOIN wp_kdskli23jkpostmeta ON wp_kdskli23jkposts.ID = wp_kdskli23jkpostmeta.post_id where wp_kdskli23jkpostmeta.meta_key = '_customer_user' AND wp_kdskli23jkpostmeta.meta_value = @param_id ORDER BY wp_kdskli23jkposts.ID ASC;", conn);
            cmd.Parameters.AddWithValue("@param_id", session_user);

            string str_order = "", str_date = "", str_status = "";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                //Read, get and loop the data value from the database
                while (reader.Read())
                {
                    // variable for getting the value of column ID and GUID in wp_kdskli23jkposts
                    str_order = reader["ID"].ToString();
                    str_date = reader["post_date"].ToString();
                    str_status = reader["post_status"].ToString();

                    mItems.Add(new Person() { Order = str_order, Date = str_date, Status = str_status, Actions = "View" });
                    //gridviewstring.Add(get_title);
                    //imgview.Add(get_img);
                }
                reader.Close();
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
            // END QUERY DATABASE


            MyListViewAdapter adapter = new MyListViewAdapter(Activity, mItems);
            mListView.Adapter = adapter;

            mListView.ItemClick += MListView_ItemClick;

            return view;
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var uri = Android.Net.Uri.Parse("http://earthfashioncafe.com/my-account/orders/");
            var i = new Intent(Intent.ActionView, uri);
            StartActivity(i);

            // To get the id of specific row
            //Console.WriteLine(mItems[e.Position].Order);
        }
    }
}