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
using System.Threading.Tasks;
using Android.Preferences;
using Android.Text;
using Android.Text.Method;

namespace EFCAndroid
{
    public class Fragment1 : SupportFragment
    {
        //Thread myThread;
        //CircleProgressBar circleprogressbar;
        private ProgressBar progressbar;
        int progressValue = 0;
        private Button btnSubmit;
        private EditText txtUsername;
        private EditText txtPassword;
        private TextView LostPassword;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            
            View view = inflater.Inflate(Resource.Layout.fragment1, container, false);

            //circleprogressbar = view.FindViewById<CircleProgressBar>(Resource.Id.circleprogressbar);
            //circleprogressbar.SetColorSchemeColors(Android.Resource.Color.HoloBlueBright);
            progressbar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);
            btnSubmit = view.FindViewById<Button>(Resource.Id.btnLogin);
            txtUsername = view.FindViewById<EditText>(Resource.Id.textBoxUsername);
            txtPassword = view.FindViewById<EditText>(Resource.Id.textBoxPassword);
            LostPassword = view.FindViewById<TextView>(Resource.Id.txtLostPassword);

            LostPassword.TextFormatted = Html.FromHtml("<a href=\"http://earthfashioncafe.com/my-account/lost-password\"> Lost Password?</a>");
            
            LostPassword.MovementMethod = LinkMovementMethod.Instance;

            txtUsername.Focusable = true;


            btnSubmit.Click += BtnSubmit_Click;

            return view;

        }

       
        // this is md5 encryption for login 

        //string salt = "$P$B55D6LjfHDkINU5wF.v2BuuzO0/XPk/";
        //public string GetMD5(string password)
        //{
        //    //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    //md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
        //    //byte[] result = md5.Hash;
        //    //StringBuilder str = new StringBuilder();
        //    //for (int i = 1; i < result.Length; i++)
        //    //{
        //    //    str.Append(result[i].ToString("x1"));
        //    //}
        //    //return str.ToString();

        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] encrypt;
        //    UTF8Encoding encode = new UTF8Encoding();
        //    encrypt = md5.ComputeHash(encode.GetBytes(password+salt));
        //    StringBuilder str = new StringBuilder();
        //    for (int i = 0; i < encrypt.Length; i++)
        //    {
        //        str.Append(encrypt[i].ToString("x2"));
        //    }
        //    return str.ToString();
        //}

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

            
            //ThreadStart myThreadDelegate = new ThreadStart(UpgradeProgress);
            //Thread myThread = new Thread(myThreadDelegate);
            //myThread.Start();



            //myThread =  new Thread(new ThreadStart(delegate
            //{
            //    while (progressValue < 100)
            //    {
            //        progressValue += 10;
            //        circleprogressbar.Progress = progressValue;
            //        //Thread.Sleep(300);
            //    }
            //    Activity.RunOnUiThread(() => { circleprogressbar.Visibility = ViewStates.Invisible; });

            //}));


            //myThread = new Thread(new ThreadStart(delegate
            //{
            //    try
            //    {
            //        Thread.Sleep(3000);
            //    }catch (Exception f)
            //    {
            //        f.ToString();
            //    }


            //    while (progressValue < 100)
            //    {
            //        progressValue += 10;
            //        circleprogressbar.Progress = progressValue;
            //        //Thread.Sleep(300);
            //    }
            //    Activity.RunOnUiThread(() => { circleprogressbar.Visibility = ViewStates.Invisible; });

           


            if (txtUsername.Text == "")
            {
                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                alert.SetMessage("Please input your username");
                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    alert.Dispose();
                });
                alert.Show();

            }
            else if (txtPassword.Text == "")
            {
                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                alert.SetMessage("Please inout your password");
                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                {
                    alert.Dispose();
                });
                alert.Show();

            }
            
            else {
                MySqlConnection conn = new MySqlConnection();

                string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";
                conn.ConnectionString = query;

                string mytxt = txtPassword.Text;

                // Threadpool -> synchronize the sql query before it execute.
                btnSubmit.Enabled = false;
                progressbar.Visibility = ViewStates.Visible;
                //circleprogressbar.Visibility = ViewStates.Visible;
                new Thread(new ThreadStart(delegate
                {
                    while (progressValue < 100)
                    {
                        progressValue += 10;
                        //circleprogressbar.Progress = progressValue;
                        progressbar.Progress = progressValue;
                        Thread.Sleep(100);
                    }
                    try
                    {

                       
                        
                        conn.Open();

                    MySqlCommand cmd = new MySqlCommand("select ID, user_login, user_pass from wp_kdskli23jkusers where user_login = @username", conn);
                    //MySqlCommand cmd = new MySqlCommand("select * from wp_kdskli23jkusers", conn);

                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    //cmd.Parameters.AddWithValue("@userpass", txtPassword.Text);

                    MySqlDataReader myReader = cmd.ExecuteReader();

                    string my_ID = "";
                    string user1 = "";
                    string pass1 = "";
                   

                    if (myReader.HasRows)
                    {
                       
                        //bool stopLoop = false; // stop looping for false value;
                        while (myReader.Read())
                        {
                            my_ID = myReader["ID"].ToString();
                            user1 = myReader["user_login"].ToString(); //datacolumn -> user_login
                            pass1 = myReader["user_pass"].ToString(); //datacolumn -> user_pass

                            if ((user1 == txtUsername.Text) && (BCryptHelper.CheckPassword(txtPassword.Text, pass1/*pass1 == GetMD5(txtPassword.Text)*/)))
                            {

                                    Activity.RunOnUiThread(() => {
                                        progressbar.Visibility = ViewStates.Invisible;
                                        //circleprogressbar.Visibility = ViewStates.Invisible;
                                        btnSubmit.Enabled = true;
                                        progressValue = 0;
                                    });


                                    Intent myIntent;
                                    myIntent = new Intent(Activity, typeof(index));

                                    string session_variable = my_ID;
                                    //global variable
                                    //myIntent.PutExtra("myItem_user", session_variable);

                                    // SESSION VARIABLE
                                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Activity);
                                    ISharedPreferencesEditor editor = prefs.Edit();
                                    editor.PutString("myItem_User_ID", session_variable);
                                    editor.Apply();
                                    //prefs.GetString("myItem_User_ID", session_variable);
                                    // SESSION VARIABLE

                                    //StartActivityForResult(myIntent, 101);
                                    StartActivity(myIntent);
                                }
                            else
                            {

                                    Activity.RunOnUiThread(() =>
                                    {
                                        progressbar.Visibility = ViewStates.Invisible;
                                        //circleprogressbar.Visibility = ViewStates.Invisible;
                                        btnSubmit.Enabled = true;
                                        progressValue = 0;
                                    });


                                    Looper.Prepare();
                                    Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                                    alert.SetMessage("Incorrect password");
                                    alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                    {
                                        alert.Dispose();
                                    });
                                    alert.Show();
                                    Looper.Loop();

                            }

                            // if you decrypt the password in the database, then i will congrats to you ./. by --> jayson

                        }
                        myReader.Close();
                    }
                    else
                    {

                            Activity.RunOnUiThread(() => {
                                progressbar.Visibility = ViewStates.Invisible;
                                //circleprogressbar.Visibility = ViewStates.Invisible;
                                btnSubmit.Enabled = true;
                                progressValue = 0;
                            });

                            Looper.Prepare();
                            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            alert.SetMessage("Invalid username");
                            alert.SetPositiveButton("Ok", (senderAlert, args) =>
                            {
                                alert.Dispose();
                            });
                            alert.Show();
                            Looper.Loop();
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


                   

                })).Start();
               // myThread.Start();
            }
            
           
        }

        

        //private void UpgradeProgress()
        //{
        //    while (progressValue < 100)
        //    {

        //        progressValue += 10;
        //        circleprogressbar.Progress = progressValue;
        //        Thread.Sleep(1000);
        //    }

        //    Activity.RunOnUiThread(() =>
        //    {
        //        circleprogressbar.Visibility = ViewStates.Invisible;
        //    });
        //}
    }
}