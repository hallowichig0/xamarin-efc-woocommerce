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
    public class Fragment_myAccount1 : SupportFragment
    {
  
        private Button BtnSubmit;
        private EditText txtboxemail;
        private EditText txtboxfname;
        private EditText txtboxlname;      

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
            View view = inflater.Inflate(Resource.Layout.Fragment_myAccount1, container, false);

            // CALLED SESSION VARIABLE
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Activity);
            session_user = prefs.GetString("myItem_User_ID", null);
            // CALLED SESSION VARIABLE



            BtnSubmit = view.FindViewById<Button>(Resource.Id.regSubmit);
            
            txtboxemail = view.FindViewById<EditText>(Resource.Id.regEmail);
            txtboxfname = view.FindViewById<EditText>(Resource.Id.regFname);
            txtboxlname = view.FindViewById<EditText>(Resource.Id.regLname);

            progressbar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);

            // Starting querying
            MySqlConnection conn = new MySqlConnection();

            string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";
            conn.ConnectionString = query;

            try
            {

                conn.Open();

                using (MySqlCommand cmd_select1 = new MySqlCommand("select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + "; " +
                    // GETTING USER INFORMATION FROM THE DATABASE --> wp_kdskli23jkusers
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_first_name';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_last_name';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_email';", conn))
                    
                {   
                    //cmd_select1.Parameters.AddWithValue("@key_id1", 1);
                    //cmd_select1.Parameters.AddWithValue("@cust_name1", session_user);
                   

                    using (MySqlDataReader myReader = cmd_select1.ExecuteReader())
                    {

                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                //user1 = myReader["quantity"].ToString();

                            }

                            // My Account
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    // txtboxemail, txtboxfname, txtboxlname, txtboxpass, txtboxNewpass, txtboxConfirmpass

                                    txtboxfname.Text = myReader["meta_value"].ToString();

                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    // txtboxemail, txtboxfname, txtboxlname, txtboxpass, txtboxNewpass, txtboxConfirmpass
                                    
                                    txtboxlname.Text = myReader["meta_value"].ToString();

                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    // txtboxemail, txtboxfname, txtboxlname, txtboxpass, txtboxNewpass, txtboxConfirmpass

                                    txtboxemail.Text = myReader["meta_value"].ToString();

                                }
                            }


                        }
                        else
                        {
                            Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            except.SetTitle("WARNING!");
                            except.SetMessage("There's no information found");
                            except.SetPositiveButton("Ok", (senderAlert, args) =>
                            {
                                except.Dispose();
                                Activity.Finish();
                            });
                            except.Show();
                        }

                    }
                }

                conn.Close();
            }
            catch (MySqlException ex)
            {
                Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                except.SetTitle("Connection Timeout");
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
            // End querying

            BtnSubmit.Click += BtnSubmit_Click;

            return view;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {



            //fName, lName, company_Name, address1, city1, zip_code, billing_payment, phone1, email1;
            if (txtboxfname.Text == "")
            {
                txtboxfname.Error = "Please enter your first name";
                txtboxfname.RequestFocus();

            }
            else if (txtboxlname.Text == "")
            {
                txtboxlname.Error = "Please enter your last name";
                txtboxlname.RequestFocus();

            }
            else if (txtboxemail.Text == "")
            {
                txtboxemail.Error = "Please enter your address";
                txtboxemail.RequestFocus();
            }
            else
            {
                //int last_insert_id_value = 0;


                progressbar.Visibility = ViewStates.Visible;
                BtnSubmit.Enabled = false;
                //Activity.Window.SetFlags(WindowManagerFlags.NotTouchable, WindowManagerFlags.NotTouchable);

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

                        cmd_update.CommandText = "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_fname " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_first_name';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_lname " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_last_name';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_email " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_email';";

                        cmd_update.Parameters.AddWithValue("@cmd_bill_fname", txtboxfname.Text);
                        cmd_update.Parameters.AddWithValue("@cmd_bill_lname", txtboxlname.Text);
                        cmd_update.Parameters.AddWithValue("@cmd_bill_email", txtboxemail.Text);

                        cmd_update.ExecuteNonQuery();


                        Activity.RunOnUiThread(() =>
                        {
                            //Window.ClearFlags(WindowManagerFlags.NotTouchable);
                            BtnSubmit.Enabled = true;
                            progressbar.Visibility = ViewStates.Invisible;
                            //circleprogressbar.Visibility = ViewStates.Invisible;
                            progressValue = 0;

                            Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            except.SetTitle("");
                            except.SetMessage("Successfully Updated!");
                            except.SetPositiveButton("Ok", (senderAlert, args) =>
                            {
                                except.Dispose();
                            });
                            except.Show();

                        });

                        conn.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Looper.Prepare();
                        progressbar.Visibility = ViewStates.Invisible;
                        Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                        except.SetTitle("Connection Timeout");
                        except.SetMessage(ex.ToString());
                        except.SetPositiveButton("Ok", (senderAlert, args) =>
                        {
                            except.Dispose();
                        });
                        except.Show();
                        Looper.Loop();
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