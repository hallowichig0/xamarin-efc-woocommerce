using System;
using System.Data;
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
using DevOne.Security.Cryptography.BCrypt;
using System.Threading;

namespace EFCAndroid
{

    public class Fragment2 : SupportFragment
    {
        private Button BtnSubmit;
        private EditText txtboxuser;
        private EditText txtboxemail;
        private EditText txtboxpass;
        private EditText txtboxfname;
        private EditText txtboxlname;

        private ProgressBar progressbar;
        int progressValue = 0;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment2, container, false);
            BtnSubmit = view.FindViewById<Button>(Resource.Id.regSubmit);
            txtboxuser = view.FindViewById<EditText>(Resource.Id.regUser);
            txtboxemail = view.FindViewById<EditText>(Resource.Id.regEmail);
            txtboxpass = view.FindViewById<EditText>(Resource.Id.regPass);
            txtboxfname = view.FindViewById<EditText>(Resource.Id.regFname);
            txtboxlname = view.FindViewById<EditText>(Resource.Id.regLname);

            progressbar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);

            txtboxuser.Focusable = true;

            BtnSubmit.Click += BtnSubmit_Click;


            return view;
        }
        
        

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

            
            MySqlConnection conn = new MySqlConnection();

            string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";
            conn.ConnectionString = query;

            
            
                try
            {


                if (conn.State == ConnectionState.Closed)
                {
                    if (txtboxuser.Text == "")
                    {
                        txtboxuser.Error = "Enter username";
                        txtboxuser.RequestFocus();
                    }
                    else if (txtboxpass.Text == "")
                    {
                        txtboxpass.Error = "Enter password";
                        txtboxpass.RequestFocus();
                    }
                    else if(txtboxfname.Text == "")
                    {
                        txtboxfname.Error = "Enter firstname";
                        txtboxfname.RequestFocus();
                    }
                    else if(txtboxlname.Text == "")
                    {
                        txtboxlname.Error = "Enter lastname";
                        txtboxlname.RequestFocus();
                    }
                    else if(txtboxemail.Text == "")
                    {
                        txtboxemail.Error = "Enter your email address";
                        txtboxemail.RequestFocus();
                    }
                    else
                    {
                        BtnSubmit.Enabled = false;
                        progressbar.Visibility = ViewStates.Visible;
                        new Thread(new ThreadStart(delegate
                        {
                            while (progressValue < 100)
                            {
                                progressValue += 10;
                                //circleprogressbar.Progress = progressValue;
                                progressbar.Progress = progressValue;
                                Thread.Sleep(100);
                            }

                            conn.Open();

                        MySqlCommand cmd1 = new MySqlCommand("select count(*) from wp_kdskli23jkusers where user_login = @user_login", conn);
                        cmd1.Parameters.AddWithValue("@user_login", txtboxuser.Text);
                        int count = Convert.ToInt32(cmd1.ExecuteScalar());

                            if (count > 0)
                            {
                                Activity.RunOnUiThread(() => {
                                    progressbar.Visibility = ViewStates.Invisible;
                                    //circleprogressbar.Visibility = ViewStates.Invisible;
                                    BtnSubmit.Enabled = true;
                                    progressValue = 0;
                                    txtboxuser.Error = "Username Exists";
                                    txtboxuser.RequestFocus();
                                });
                                
                            }
                            else
                            {
                                Activity.RunOnUiThread(() => {
                                    progressbar.Visibility = ViewStates.Invisible;
                                    //circleprogressbar.Visibility = ViewStates.Invisible;
                                    BtnSubmit.Enabled = true;
                                    progressValue = 0;
                                
                                // Bcrypt hash + salt
                                string salt = BCryptHelper.GenerateSalt();
                                var hash = BCryptHelper.HashPassword(txtboxpass.Text, salt);
                                txtboxpass.Text = hash;

                                // date registered
                                String myDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); // value of date time in user_registered column in the database of efc

                                // insert register form
                                string insertSignUp = "INSERT INTO wp_kdskli23jkusers(user_login, user_pass, user_nicename, user_email, user_registered, display_name) values(@user_login," +
                                   "@user_pass, @user_nicename, @user_email, @user_registered, @display_name);" +
                                //insert capabilities ->user-role && user_level
                                "INSERT INTO wp_kdskli23jkusermeta(user_id, meta_key, meta_value)" +
                                "VALUES(LAST_INSERT_ID(), @capabilities, @user_role), (LAST_INSERT_ID(), @user_level, @user_level_value)," +
                                "(LAST_INSERT_ID(), @first_name, @fname_value), (LAST_INSERT_ID(), @last_name, @lname_value)," +
                                "(LAST_INSERT_ID(), @nickname, @nickname_value), (LAST_INSERT_ID(), 'description', '')," +
                                "(LAST_INSERT_ID(), 'rich_editing', 'true'), (LAST_INSERT_ID(), 'comment_shortcuts', 'false')," +
                                "(LAST_INSERT_ID(), 'admin_color', 'fresh'), (LAST_INSERT_ID(), 'use_ssl', '0')," +
                                "(LAST_INSERT_ID(), 'show_admin_bar_front', 'true'), (LAST_INSERT_ID(), 'billing_first_name', @bill_fname), " +
                                "(LAST_INSERT_ID(), 'billing_last_name', @bill_lname), (LAST_INSERT_ID(), 'billing_company', ''), (LAST_INSERT_ID(), 'billing_address_1', ''), " +
                                "(LAST_INSERT_ID(), 'billing_city', ''), (LAST_INSERT_ID(), 'billing_postcode', ''), (LAST_INSERT_ID(), 'billing_payment', ''), " +
                                "(LAST_INSERT_ID(), 'billing_phone', ''), (LAST_INSERT_ID(), 'billing_email', @bill_email);";
                                //"SET @reglast = LAST_INSERT_ID();" +
                                //"INSERT INTO wp_kdskli23jkusermeta(user_id, meta_key, meta_value)" +
                                //"VALUES(@last, @user_level, @user_level_value);";


                                MySqlCommand cmd = new MySqlCommand(insertSignUp, conn);
                                //long imageId = cmd.LastInsertedId;
                                cmd.Parameters.AddWithValue("@user_login", txtboxuser.Text);
                                cmd.Parameters.AddWithValue("@user_pass", txtboxpass.Text);
                                cmd.Parameters.AddWithValue("@user_email", txtboxemail.Text);
                                cmd.Parameters.AddWithValue("@user_nicename", txtboxuser.Text);
                                cmd.Parameters.AddWithValue("@user_registered", myDate);
                                cmd.Parameters.AddWithValue("@display_name", txtboxuser.Text);

                                //insert wp_capabilities -> user_role for wp_users;
                                cmd.Parameters.Add("@capabilities", MySqlDbType.VarChar).Value = "wp_kdskli23jkcapabilities";
                                cmd.Parameters.Add("@user_role", MySqlDbType.VarChar).Value = "a:1:{s:8:\"customer\";b:1;}";

                                //insert wp_user_role -> default value is equal to 0 for customer
                                cmd.Parameters.Add("@user_level", MySqlDbType.VarChar).Value = "wp_kdskli23jkuser_level";
                                cmd.Parameters.Add("@user_level_value", MySqlDbType.VarChar).Value = "0";

                                //insert wp_usermeta -> firstname
                                cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = "first_name";
                                cmd.Parameters.AddWithValue("@fname_value", txtboxfname.Text);

                                //insert wp_usermeta -> lastname
                                cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = "last_name";
                                cmd.Parameters.AddWithValue("@lname_value", txtboxlname.Text);

                                //insert wp_usermeta -> nickname
                                cmd.Parameters.Add("@nickname", MySqlDbType.VarChar).Value = "nickname";
                                cmd.Parameters.Add("nickname_value", MySqlDbType.VarChar).Value = txtboxfname.Text + " " + txtboxlname.Text;

                                    //insert wp_usermeta -> billing fname, lname, email
                                    cmd.Parameters.AddWithValue("@bill_fname", txtboxfname.Text);
                                    cmd.Parameters.AddWithValue("@bill_lname", txtboxlname.Text);
                                    cmd.Parameters.AddWithValue("@bill_email", txtboxemail.Text);

                                    cmd.ExecuteNonQuery();

                                
                                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                                alert.SetTitle("Successfully");
                                alert.SetMessage("Your account has been registered!");
                                alert.SetPositiveButton("Ok", (senderAlert, args) =>
                                {
                                    alert.Dispose();
                                });
                                alert.Show();
                                txtboxuser.Text = "";
                                txtboxpass.Text = "";
                                txtboxemail.Text = "";
                                txtboxfname.Text = "";
                                txtboxlname.Text = "";
                                txtboxuser.Focusable = true;
                                });
                            }
                        })).Start();
                    }
                }


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

            

        }
    }
}