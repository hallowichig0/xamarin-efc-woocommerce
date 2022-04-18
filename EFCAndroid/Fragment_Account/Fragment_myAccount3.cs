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

namespace EFCAndroid.Fragment_Account
{
    public class Fragment_myAccount3 : SupportFragment
    {
        private Button BtnSubmit;
        private EditText txtboxpass;
        private EditText txtboxNewpass;

        private ProgressBar progressbar;
        int progressValue = 0;

        // SESSION VARIABLE
        string session_user = "";
        // SESSION VARIABLE

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.Fragment_myAccount3, container, false);

            // CALLED SESSION VARIABLE
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Activity);
            session_user = prefs.GetString("myItem_User_ID", null);
            // CALLED SESSION VARIABLE

            BtnSubmit = view.FindViewById<Button>(Resource.Id.regSubmit);

            txtboxpass = view.FindViewById<EditText>(Resource.Id.currentPass);
            txtboxNewpass = view.FindViewById<EditText>(Resource.Id.newPass);

            progressbar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);


            BtnSubmit.Click += BtnSubmit_Click;

            return view;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

            // Bcrypt hash + salt
            string salt = BCryptHelper.GenerateSalt();
            
            var hash3 = BCryptHelper.HashPassword(txtboxNewpass.Text, salt);
            
            txtboxNewpass.Text = hash3;

            progressbar.Visibility = ViewStates.Visible;
            BtnSubmit.Enabled = false;
            //Activity.Window.SetFlags(WindowManagerFlags.NotTouchable, WindowManagerFlags.NotTouchable);

            if (txtboxpass.Text == "")
            {
                txtboxpass.Error = "Please enter your current password";
                txtboxpass.RequestFocus();
            }
            else if (txtboxNewpass.Text == "")
            {
                txtboxNewpass.Error = "Please enter your new password";
                txtboxNewpass.RequestFocus();
            }
            else
            {
                MySqlConnection conn = new MySqlConnection();

                string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";
                conn.ConnectionString = query;

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

                        MySqlCommand cmd_update = conn.CreateCommand();

                        cmd_update.Connection = conn;

                        cmd_update.CommandText = "select * from wp_kdskli23jkusers where ID = @username;";
                        //MySqlCommand cmd = new MySqlCommand("select * from wp_kdskli23jkusers", conn);

                        cmd_update.Parameters.AddWithValue("@username", session_user);
                        //cmd.Parameters.AddWithValue("@userpass", txtPassword.Text);
                        MySqlDataReader myReader = cmd_update.ExecuteReader();



                        

                        string pass1 = "";


                        if (myReader.HasRows)
                        {

                            //bool stopLoop = false; // stop looping for false value;
                            while (myReader.Read())
                            {
                                pass1 = myReader["user_pass"].ToString();

                            }
                            myReader.Close();

                        }

                        if ((BCryptHelper.CheckPassword(txtboxpass.Text, pass1)))
                        {
                            cmd_update.CommandText = "update wp_kdskli23jkusers " +
                            "SET user_pass = @cmd_new_password " +
                            "WHERE ID = " + session_user + ";";

                            cmd_update.Parameters.AddWithValue("@cmd_new_password", txtboxNewpass.Text);

                            cmd_update.ExecuteNonQuery();

                            Activity.RunOnUiThread(() =>
                            {
                                BtnSubmit.Enabled = true;
                                progressbar.Visibility = ViewStates.Invisible;
                                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                                alert.SetMessage("Successfully Updated!");
                                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                {
                                    alert.Dispose();
                                });
                                alert.Show();
                            });
                        }
                        else
                        {
                            Activity.RunOnUiThread(() =>
                            {
                                BtnSubmit.Enabled = true;
                                txtboxpass.Text = "";
                                txtboxNewpass.Text = "";
                                progressbar.Visibility = ViewStates.Invisible;
                                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                                alert.SetMessage("Incorrect password");
                                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                {
                                    alert.Dispose();
                                    txtboxpass.RequestFocus();
                                });
                                alert.Show();
                            });
                        }


                        //Activity.RunOnUiThread(() =>
                        //{
                        //    //Window.ClearFlags(WindowManagerFlags.NotTouchable);
                        //    BtnSubmit.Enabled = true;
                        //    progressbar.Visibility = ViewStates.Invisible;
                        //    //circleprogressbar.Visibility = ViewStates.Invisible;
                        //    progressValue = 0;

                        //    Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                        //    except.SetMessage("Successfully Updated!");
                        //    except.SetPositiveButton("Ok", (senderAlert, args) =>
                        //    {
                        //        except.Dispose();
                        //    });
                        //    except.Show();

                        //});

                        conn.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Activity.RunOnUiThread(() =>
                        {
                            progressbar.Visibility = ViewStates.Invisible;
                            Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            except.SetTitle("Connection Timeout");
                            except.SetMessage(ex.ToString());
                            except.SetPositiveButton("Ok", (senderAlert, args) =>
                            {
                                except.Dispose();
                            });
                            except.Show();
                        });
                    }
                    finally
                    {
                        conn.Close();
                    }

                })).Start();

            }
        }
    }
}