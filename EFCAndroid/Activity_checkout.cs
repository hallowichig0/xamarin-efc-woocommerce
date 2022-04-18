using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using MySql.Data.MySqlClient;
using System.Threading;
using Android.Animation;
using Android.Preferences;
using Square.Picasso;

namespace EFCAndroid
{
    [Activity(Label = "Activity_checkout", /*MainLauncher = true,*/ Theme = "@style/Theme.DesignDemo")]
    public class Activity_checkout : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        private BottomNavigationView btm_nav;
        private ProgressBar progressbar;

        // SESSION VARIABLE
        string session_user = "";
        // SESSION VARIABLE

        int progressValue = 0;

        // Variable of Subtotal & Total
        int subtotal_db, subtotal_result;
        int total_price, result1_total, final_result_total;
        // End Variable of Subtotal & Total
        
        // TextView of the customer order
        private TextView txtQuantity_1, txtQuantity_2, txtQuantity_3, txtQuantity_4, txtQuantity_5, txtQuantity_6, txtQuantity_7, txtQuantity_8;
        private TextView base_price1, base_price2, base_price3, base_price4, base_price5, base_price6, base_price7, base_price8;

        private TextView txtQuantity_9, txtQuantity_10, txtQuantity_11, txtQuantity_12, txtQuantity_13, txtQuantity_14, txtQuantity_15, txtQuantity_16;
        private TextView base_price9, base_price10, base_price11, base_price12, base_price13, base_price14, base_price15, base_price16;

        private TextView txtQuantity_17, txtQuantity_18, txtQuantity_19, txtQuantity_20, txtQuantity_21, txtQuantity_22, txtQuantity_23, txtQuantity_24;
        private TextView base_price17, base_price18, base_price19, base_price20, base_price21, base_price22, base_price23, base_price24;

        private TextView txtQuantity_25, txtQuantity_26, txtQuantity_27, txtQuantity_28, txtQuantity_29, txtQuantity_30, txtQuantity_31, txtQuantity_32;
        private TextView base_price25, base_price26, base_price27, base_price28, base_price29, base_price30, base_price31, base_price32;

        // The Rest Product
        private TextView txtQuantity_33, txtQuantity_34, txtQuantity_35, txtQuantity_36, txtQuantity_37;
        private TextView base_price33, base_price34, base_price35, base_price36, base_price37;
        // beef
        private TextView txtQuantity_38, txtQuantity_39, txtQuantity_40, txtQuantity_41, txtQuantity_42;
        private TextView base_price38, base_price39, base_price40, base_price41, base_price42;
        // fish
        private TextView txtQuantity_43, txtQuantity_44, txtQuantity_45, txtQuantity_46;
        private TextView base_price43, base_price44, base_price45, base_price46;
        // vegan
        private TextView txtQuantity_47, txtQuantity_48, txtQuantity_49, txtQuantity_50, txtQuantity_51;
        private TextView base_price47, base_price48, base_price49, base_price50, base_price51;
        // pasta
        private TextView txtQuantity_52, txtQuantity_53, txtQuantity_54;
        private TextView base_price52, base_price53, base_price54;
        // sandwich
        private TextView txtQuantity_55, txtQuantity_56, txtQuantity_57;
        private TextView base_price55, base_price56, base_price57;
        // salad
        private TextView txtQuantity_58, txtQuantity_59, txtQuantity_60;
        private TextView base_price58, base_price59, base_price60;

        private ImageView imgview1, imgview2, imgview3, imgview4, imgview5, imgview6, imgview7, imgview8;
        private ImageView imgview9, imgview10, imgview11, imgview12, imgview13, imgview14, imgview15, imgview16;
        private ImageView imgview17, imgview18, imgview19, imgview20, imgview21, imgview22, imgview23, imgview24;
        private ImageView imgview25, imgview26, imgview27, imgview28, imgview29, imgview30, imgview31, imgview32;

        // the rest product
        private ImageView imgview33, imgview34, imgview35, imgview36, imgview37;
        // beef
        private ImageView imgview38, imgview39, imgview40, imgview41, imgview42;
        // fish
        private ImageView imgview43, imgview44, imgview45, imgview46;
        // vegan
        private ImageView imgview47, imgview48, imgview49, imgview50, imgview51;
        // pasta
        private ImageView imgview52, imgview53, imgview54;
        // sandwich
        private ImageView imgview55, imgview56, imgview57;
        // salad
        private ImageView imgview58, imgview59, imgview60;

        private LinearLayout linear1, linear2, linear3, linear4, linear5, linear6, linear7, linear8;
        private LinearLayout linear9, linear10, linear11, linear12, linear13, linear14, linear15, linear16;
        private LinearLayout linear17, linear18, linear19, linear20, linear21, linear22, linear23, linear24;
        private LinearLayout linear25, linear26, linear27, linear28, linear29, linear30, linear31, linear32;

        // the rest product
        private LinearLayout linear33, linear34, linear35, linear36, linear37;
        // beef
        private LinearLayout linear38, linear39, linear40, linear41, linear42;
        // fish
        private LinearLayout linear43, linear44, linear45, linear46;
        // vegan
        private LinearLayout linear47, linear48, linear49, linear50, linear51;
        // pasta
        private LinearLayout linear52, linear53, linear54;
        // sandwich
        private LinearLayout linear55, linear56, linear57;
        // salad
        private LinearLayout linear58, linear59, linear60;


        int price1, price2, price3, price4, price5, price6, price7, price8;
        int price9, price10, price11, price12, price13, price14, price15, price16;
        int price17, price18, price19, price20, price21, price22, price23, price24;
        int price25, price26, price27, price28, price29, price30, price31, price32;

        // the rest product
        int price33, price34, price35, price36, price37;
        // beef
        int price38, price39, price40, price41, price42;
        // fish
        int price43, price44, price45, price46;
        // vegan
        int price47, price48, price49, price50, price51;
        // pasta
        int price52, price53, price54;
        // sandwich
        int price55, price56, price57;
        // salad
        int price58, price59, price60;
        // End

        private TextView subtotal, subtotal_value;

        private LinearLayout mLinearLayout_expandable, mLinearLayout_header, mLinearLayout_expandable2, mLinearLayout_header2;
        private TextView txtShow1, txtShow2;

        // TextView of billing & shipping form
        private TextView fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;
        // End
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_checkout);
            // Create your application here

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);

            SetSupportActionBar(mToolbar);
            SupportActionBar.Title = "CHECK OUT";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            // CALLED SESSION VARIABLE
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            session_user = prefs.GetString("myItem_User_ID", null);
            // CALLED SESSION VARIABLE

            // Set Findview<>() for TextView Billing & Shipping form
            fName = FindViewById<TextView>(Resource.Id.fName);
            lName = FindViewById<TextView>(Resource.Id.lName);
            company_Name = FindViewById<TextView>(Resource.Id.company_Name);
            address1 = FindViewById<TextView>(Resource.Id.address1);
            city1 = FindViewById<TextView>(Resource.Id.city1);
            country1 = FindViewById<TextView>(Resource.Id.country1);
            zip_code = FindViewById<TextView>(Resource.Id.zip_code);
            billing_payment = FindViewById<TextView>(Resource.Id.billing_payment);
            phone1 = FindViewById<TextView>(Resource.Id.phone1);
            email1 = FindViewById<TextView>(Resource.Id.email1);
            add_info = FindViewById<TextView>(Resource.Id.add_info);
            // End TextView Billing & Shipping form

            btm_nav = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            IMenu menu1 = btm_nav.Menu;
            IMenuItem nav_bottom_item = menu1.FindItem(Resource.Id.total_pay);


            // Set Findview<>() for TextView Show & Hide
            mLinearLayout_expandable = FindViewById<LinearLayout>(Resource.Id.Linear_expandable);
            mLinearLayout_header = FindViewById<LinearLayout>(Resource.Id.Linear_header);
            txtShow1 = FindViewById<TextView>(Resource.Id.txtshow);

            mLinearLayout_expandable2 = FindViewById<LinearLayout>(Resource.Id.Linear_expandable2);
            mLinearLayout_header2 = FindViewById<LinearLayout>(Resource.Id.Linear_header2);
            txtShow2 = FindViewById<TextView>(Resource.Id.txtshow2);
            // End TextView Show & Hide

            mLinearLayout_expandable.Visibility = ViewStates.Gone;
            mLinearLayout_expandable2.Visibility = ViewStates.Gone;

            // Start collapse layout
            mLinearLayout_header.Click += (s, e) => 
            {
                if(mLinearLayout_expandable.Visibility.Equals (ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();

                    txtShow1.Text = "HIDE";
                }
                else
                {
                    //collapse();
                    int finalHeight = mLinearLayout_expandable.Height;

                    ValueAnimator mAnimator = SlideAnimator_Form(finalHeight, 0);
                    mAnimator.Start();
                    mAnimator.AnimationEnd += (object IntentSender, EventArgs arg) => {
                        mLinearLayout_expandable.Visibility = ViewStates.Gone;
                    };//mLinearLayout.Visibility = ViewStates.Gone;

                    txtShow1.Text = "SHOW";
                }
            };

            mLinearLayout_header2.Click += (s, e) =>
            {
                if (mLinearLayout_expandable2.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable2.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable2.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Cart(0, mLinearLayout_expandable2.MeasuredHeight);
                    mAnimator.Start();

                    txtShow2.Text = "HIDE";
                }
                else
                {
                    //collapse();
                    int finalHeight = mLinearLayout_expandable2.Height;

                    ValueAnimator mAnimator = SlideAnimator_Cart(finalHeight, 0);
                    mAnimator.Start();
                    mAnimator.AnimationEnd += (object IntentSender, EventArgs arg) => {
                        mLinearLayout_expandable2.Visibility = ViewStates.Gone;
                    };//mLinearLayout.Visibility = ViewStates.Gone;

                    txtShow2.Text = "SHOW";
                }
            };
            // end collapse

            // Bottom Nav Click
            btm_nav.NavigationItemSelected += Btm_nav_NavigationItemSelected;
            // End Bottom Nav Click

            // Set Findview<>() for TextView Customer Order
            txtQuantity_1 = FindViewById<TextView>(Resource.Id.qtyNum1);
            linear1 = FindViewById<LinearLayout>(Resource.Id.Linear1);
            base_price1 = FindViewById<TextView>(Resource.Id.base_price1);
            imgview1 = FindViewById<ImageView>(Resource.Id.imageView1);

            txtQuantity_2 = FindViewById<TextView>(Resource.Id.qtyNum2);
            linear2 = FindViewById<LinearLayout>(Resource.Id.Linear2);
            base_price2 = FindViewById<TextView>(Resource.Id.base_price2);
            imgview2 = FindViewById<ImageView>(Resource.Id.imageView2);

            txtQuantity_3 = FindViewById<TextView>(Resource.Id.qtyNum3);
            linear3 = FindViewById<LinearLayout>(Resource.Id.Linear3);
            base_price3 = FindViewById<TextView>(Resource.Id.base_price3);
            imgview3 = FindViewById<ImageView>(Resource.Id.imageView3);

            txtQuantity_4 = FindViewById<TextView>(Resource.Id.qtyNum4);
            linear4 = FindViewById<LinearLayout>(Resource.Id.Linear4);
            base_price4 = FindViewById<TextView>(Resource.Id.base_price4);
            imgview4 = FindViewById<ImageView>(Resource.Id.imageView4);

            txtQuantity_5 = FindViewById<TextView>(Resource.Id.qtyNum5);
            linear5 = FindViewById<LinearLayout>(Resource.Id.Linear5);
            base_price5 = FindViewById<TextView>(Resource.Id.base_price5);
            imgview5 = FindViewById<ImageView>(Resource.Id.imageView5);

            txtQuantity_6 = FindViewById<TextView>(Resource.Id.qtyNum6);
            linear6 = FindViewById<LinearLayout>(Resource.Id.Linear6);
            base_price6 = FindViewById<TextView>(Resource.Id.base_price6);
            imgview6 = FindViewById<ImageView>(Resource.Id.imageView6);

            txtQuantity_7 = FindViewById<TextView>(Resource.Id.qtyNum7);
            linear7 = FindViewById<LinearLayout>(Resource.Id.Linear7);
            base_price7 = FindViewById<TextView>(Resource.Id.base_price7);
            imgview7 = FindViewById<ImageView>(Resource.Id.imageView7);

            txtQuantity_8 = FindViewById<TextView>(Resource.Id.qtyNum8);
            linear8 = FindViewById<LinearLayout>(Resource.Id.Linear8);
            base_price8 = FindViewById<TextView>(Resource.Id.base_price8);
            imgview8 = FindViewById<ImageView>(Resource.Id.imageView8);

            // EFC CHICKEN CURRY
            txtQuantity_9 = FindViewById<TextView>(Resource.Id.qtyNum9);
            linear9 = FindViewById<LinearLayout>(Resource.Id.Linear9);
            base_price9 = FindViewById<TextView>(Resource.Id.base_price9);
            imgview9 = FindViewById<ImageView>(Resource.Id.imageView9);

            txtQuantity_10 = FindViewById<TextView>(Resource.Id.qtyNum10);
            linear10 = FindViewById<LinearLayout>(Resource.Id.Linear10);
            base_price10 = FindViewById<TextView>(Resource.Id.base_price10);
            imgview10 = FindViewById<ImageView>(Resource.Id.imageView10);

            txtQuantity_11 = FindViewById<TextView>(Resource.Id.qtyNum11);
            linear11 = FindViewById<LinearLayout>(Resource.Id.Linear11);
            base_price11 = FindViewById<TextView>(Resource.Id.base_price11);
            imgview11 = FindViewById<ImageView>(Resource.Id.imageView11);

            txtQuantity_12 = FindViewById<TextView>(Resource.Id.qtyNum12);
            linear12 = FindViewById<LinearLayout>(Resource.Id.Linear12);
            base_price12 = FindViewById<TextView>(Resource.Id.base_price12);
            imgview12 = FindViewById<ImageView>(Resource.Id.imageView12);

            txtQuantity_13 = FindViewById<TextView>(Resource.Id.qtyNum13);
            linear13 = FindViewById<LinearLayout>(Resource.Id.Linear13);
            base_price13 = FindViewById<TextView>(Resource.Id.base_price13);
            imgview13 = FindViewById<ImageView>(Resource.Id.imageView13);

            txtQuantity_14 = FindViewById<TextView>(Resource.Id.qtyNum14);
            linear14 = FindViewById<LinearLayout>(Resource.Id.Linear14);
            base_price14 = FindViewById<TextView>(Resource.Id.base_price14);
            imgview14 = FindViewById<ImageView>(Resource.Id.imageView14);

            txtQuantity_15 = FindViewById<TextView>(Resource.Id.qtyNum15);
            linear15 = FindViewById<LinearLayout>(Resource.Id.Linear15);
            base_price15 = FindViewById<TextView>(Resource.Id.base_price15);
            imgview15 = FindViewById<ImageView>(Resource.Id.imageView15);

            txtQuantity_16 = FindViewById<TextView>(Resource.Id.qtyNum16);
            linear16 = FindViewById<LinearLayout>(Resource.Id.Linear16);
            base_price16 = FindViewById<TextView>(Resource.Id.base_price16);
            imgview16 = FindViewById<ImageView>(Resource.Id.imageView16);

            // EFC BEEF TERIYAKI
            txtQuantity_17 = FindViewById<TextView>(Resource.Id.qtyNum17);
            linear17 = FindViewById<LinearLayout>(Resource.Id.Linear17);
            base_price17 = FindViewById<TextView>(Resource.Id.base_price17);
            imgview17 = FindViewById<ImageView>(Resource.Id.imageView17);

            txtQuantity_18 = FindViewById<TextView>(Resource.Id.qtyNum18);
            linear18 = FindViewById<LinearLayout>(Resource.Id.Linear18);
            base_price18 = FindViewById<TextView>(Resource.Id.base_price18);
            imgview18 = FindViewById<ImageView>(Resource.Id.imageView18);

            txtQuantity_19 = FindViewById<TextView>(Resource.Id.qtyNum19);
            linear19 = FindViewById<LinearLayout>(Resource.Id.Linear19);
            base_price19 = FindViewById<TextView>(Resource.Id.base_price19);
            imgview19 = FindViewById<ImageView>(Resource.Id.imageView19);

            txtQuantity_20 = FindViewById<TextView>(Resource.Id.qtyNum20);
            linear20 = FindViewById<LinearLayout>(Resource.Id.Linear20);
            base_price20 = FindViewById<TextView>(Resource.Id.base_price20);
            imgview20 = FindViewById<ImageView>(Resource.Id.imageView20);

            txtQuantity_21 = FindViewById<TextView>(Resource.Id.qtyNum21);
            linear21 = FindViewById<LinearLayout>(Resource.Id.Linear21);
            base_price21 = FindViewById<TextView>(Resource.Id.base_price21);
            imgview21 = FindViewById<ImageView>(Resource.Id.imageView21);

            txtQuantity_22 = FindViewById<TextView>(Resource.Id.qtyNum22);
            linear22 = FindViewById<LinearLayout>(Resource.Id.Linear22);
            base_price22 = FindViewById<TextView>(Resource.Id.base_price22);
            imgview22 = FindViewById<ImageView>(Resource.Id.imageView22);

            txtQuantity_23 = FindViewById<TextView>(Resource.Id.qtyNum23);
            linear23 = FindViewById<LinearLayout>(Resource.Id.Linear23);
            base_price23 = FindViewById<TextView>(Resource.Id.base_price23);
            imgview23 = FindViewById<ImageView>(Resource.Id.imageView23);

            txtQuantity_24 = FindViewById<TextView>(Resource.Id.qtyNum24);
            linear24 = FindViewById<LinearLayout>(Resource.Id.Linear24);
            base_price24 = FindViewById<TextView>(Resource.Id.base_price24);
            imgview24 = FindViewById<ImageView>(Resource.Id.imageView24);

            // EFC BEEF CURRY
            txtQuantity_25 = FindViewById<TextView>(Resource.Id.qtyNum25);
            linear25 = FindViewById<LinearLayout>(Resource.Id.Linear25);
            base_price25 = FindViewById<TextView>(Resource.Id.base_price25);
            imgview25 = FindViewById<ImageView>(Resource.Id.imageView25);

            txtQuantity_26 = FindViewById<TextView>(Resource.Id.qtyNum26);
            linear26 = FindViewById<LinearLayout>(Resource.Id.Linear26);
            base_price26 = FindViewById<TextView>(Resource.Id.base_price26);
            imgview26 = FindViewById<ImageView>(Resource.Id.imageView26);

            txtQuantity_27 = FindViewById<TextView>(Resource.Id.qtyNum27);
            linear27 = FindViewById<LinearLayout>(Resource.Id.Linear27);
            base_price27 = FindViewById<TextView>(Resource.Id.base_price27);
            imgview27 = FindViewById<ImageView>(Resource.Id.imageView27);

            txtQuantity_28 = FindViewById<TextView>(Resource.Id.qtyNum28);
            linear28 = FindViewById<LinearLayout>(Resource.Id.Linear28);
            base_price28 = FindViewById<TextView>(Resource.Id.base_price28);
            imgview28 = FindViewById<ImageView>(Resource.Id.imageView28);

            txtQuantity_29 = FindViewById<TextView>(Resource.Id.qtyNum29);
            linear29 = FindViewById<LinearLayout>(Resource.Id.Linear29);
            base_price29 = FindViewById<TextView>(Resource.Id.base_price29);
            imgview29 = FindViewById<ImageView>(Resource.Id.imageView29);

            txtQuantity_30 = FindViewById<TextView>(Resource.Id.qtyNum30);
            linear30 = FindViewById<LinearLayout>(Resource.Id.Linear30);
            base_price30 = FindViewById<TextView>(Resource.Id.base_price30);
            imgview30 = FindViewById<ImageView>(Resource.Id.imageView30);

            txtQuantity_31 = FindViewById<TextView>(Resource.Id.qtyNum31);
            linear31 = FindViewById<LinearLayout>(Resource.Id.Linear31);
            base_price31 = FindViewById<TextView>(Resource.Id.base_price31);
            imgview31 = FindViewById<ImageView>(Resource.Id.imageView31);

            txtQuantity_32 = FindViewById<TextView>(Resource.Id.qtyNum32);
            linear32 = FindViewById<LinearLayout>(Resource.Id.Linear32);
            base_price32 = FindViewById<TextView>(Resource.Id.base_price32);
            imgview32 = FindViewById<ImageView>(Resource.Id.imageView32);

            // The Rest Product

            // CHICKEN
            txtQuantity_33 = FindViewById<TextView>(Resource.Id.qtyNum33);
            linear33 = FindViewById<LinearLayout>(Resource.Id.Linear33);
            base_price33 = FindViewById<TextView>(Resource.Id.base_price33);
            imgview33 = FindViewById<ImageView>(Resource.Id.imageView33);

            txtQuantity_34 = FindViewById<TextView>(Resource.Id.qtyNum34);
            linear34 = FindViewById<LinearLayout>(Resource.Id.Linear34);
            base_price34 = FindViewById<TextView>(Resource.Id.base_price34);
            imgview34 = FindViewById<ImageView>(Resource.Id.imageView34);

            txtQuantity_35 = FindViewById<TextView>(Resource.Id.qtyNum35);
            linear35 = FindViewById<LinearLayout>(Resource.Id.Linear35);
            base_price35 = FindViewById<TextView>(Resource.Id.base_price35);
            imgview35 = FindViewById<ImageView>(Resource.Id.imageView35);

            txtQuantity_36 = FindViewById<TextView>(Resource.Id.qtyNum36);
            linear36 = FindViewById<LinearLayout>(Resource.Id.Linear36);
            base_price36 = FindViewById<TextView>(Resource.Id.base_price36);
            imgview36 = FindViewById<ImageView>(Resource.Id.imageView36);

            txtQuantity_37 = FindViewById<TextView>(Resource.Id.qtyNum37);
            linear37 = FindViewById<LinearLayout>(Resource.Id.Linear37);
            base_price37 = FindViewById<TextView>(Resource.Id.base_price37);
            imgview37 = FindViewById<ImageView>(Resource.Id.imageView37);

            // BEEF
            txtQuantity_38 = FindViewById<TextView>(Resource.Id.qtyNum38);
            linear38 = FindViewById<LinearLayout>(Resource.Id.Linear38);
            base_price38 = FindViewById<TextView>(Resource.Id.base_price38);
            imgview38 = FindViewById<ImageView>(Resource.Id.imageView38);

            txtQuantity_39 = FindViewById<TextView>(Resource.Id.qtyNum39);
            linear39 = FindViewById<LinearLayout>(Resource.Id.Linear39);
            base_price39 = FindViewById<TextView>(Resource.Id.base_price39);
            imgview39 = FindViewById<ImageView>(Resource.Id.imageView39);

            txtQuantity_40 = FindViewById<TextView>(Resource.Id.qtyNum40);
            linear40 = FindViewById<LinearLayout>(Resource.Id.Linear40);
            base_price40 = FindViewById<TextView>(Resource.Id.base_price40);
            imgview40 = FindViewById<ImageView>(Resource.Id.imageView40);

            txtQuantity_41 = FindViewById<TextView>(Resource.Id.qtyNum41);
            linear41 = FindViewById<LinearLayout>(Resource.Id.Linear41);
            base_price41 = FindViewById<TextView>(Resource.Id.base_price41);
            imgview41 = FindViewById<ImageView>(Resource.Id.imageView41);

            txtQuantity_42 = FindViewById<TextView>(Resource.Id.qtyNum42);
            linear42 = FindViewById<LinearLayout>(Resource.Id.Linear42);
            base_price42 = FindViewById<TextView>(Resource.Id.base_price42);
            imgview42 = FindViewById<ImageView>(Resource.Id.imageView42);

            // FISH
            txtQuantity_43 = FindViewById<TextView>(Resource.Id.qtyNum43);
            linear43 = FindViewById<LinearLayout>(Resource.Id.Linear43);
            base_price43 = FindViewById<TextView>(Resource.Id.base_price43);
            imgview43 = FindViewById<ImageView>(Resource.Id.imageView43);

            txtQuantity_44 = FindViewById<TextView>(Resource.Id.qtyNum44);
            linear44 = FindViewById<LinearLayout>(Resource.Id.Linear44);
            base_price44 = FindViewById<TextView>(Resource.Id.base_price44);
            imgview44 = FindViewById<ImageView>(Resource.Id.imageView44);

            txtQuantity_45 = FindViewById<TextView>(Resource.Id.qtyNum45);
            linear45 = FindViewById<LinearLayout>(Resource.Id.Linear45);
            base_price45 = FindViewById<TextView>(Resource.Id.base_price45);
            imgview45 = FindViewById<ImageView>(Resource.Id.imageView45);

            txtQuantity_46 = FindViewById<TextView>(Resource.Id.qtyNum46);
            linear46 = FindViewById<LinearLayout>(Resource.Id.Linear46);
            base_price46 = FindViewById<TextView>(Resource.Id.base_price46);
            imgview46 = FindViewById<ImageView>(Resource.Id.imageView46);

            // VEGAN
            txtQuantity_47 = FindViewById<TextView>(Resource.Id.qtyNum47);
            linear47 = FindViewById<LinearLayout>(Resource.Id.Linear47);
            base_price47 = FindViewById<TextView>(Resource.Id.base_price47);
            imgview47 = FindViewById<ImageView>(Resource.Id.imageView47);

            txtQuantity_48 = FindViewById<TextView>(Resource.Id.qtyNum48);
            linear48 = FindViewById<LinearLayout>(Resource.Id.Linear48);
            base_price48 = FindViewById<TextView>(Resource.Id.base_price48);
            imgview48 = FindViewById<ImageView>(Resource.Id.imageView48);

            txtQuantity_49 = FindViewById<TextView>(Resource.Id.qtyNum49);
            linear49 = FindViewById<LinearLayout>(Resource.Id.Linear49);
            base_price49 = FindViewById<TextView>(Resource.Id.base_price49);
            imgview49 = FindViewById<ImageView>(Resource.Id.imageView49);

            txtQuantity_50 = FindViewById<TextView>(Resource.Id.qtyNum50);
            linear50 = FindViewById<LinearLayout>(Resource.Id.Linear50);
            base_price50 = FindViewById<TextView>(Resource.Id.base_price50);
            imgview50 = FindViewById<ImageView>(Resource.Id.imageView50);

            txtQuantity_51 = FindViewById<TextView>(Resource.Id.qtyNum51);
            linear51 = FindViewById<LinearLayout>(Resource.Id.Linear51);
            base_price51 = FindViewById<TextView>(Resource.Id.base_price51);
            imgview51 = FindViewById<ImageView>(Resource.Id.imageView51);

            // PASTA
            txtQuantity_52 = FindViewById<TextView>(Resource.Id.qtyNum52);
            linear52 = FindViewById<LinearLayout>(Resource.Id.Linear52);
            base_price52 = FindViewById<TextView>(Resource.Id.base_price52);
            imgview52 = FindViewById<ImageView>(Resource.Id.imageView52);

            txtQuantity_53 = FindViewById<TextView>(Resource.Id.qtyNum53);
            linear53 = FindViewById<LinearLayout>(Resource.Id.Linear53);
            base_price53 = FindViewById<TextView>(Resource.Id.base_price53);
            imgview53 = FindViewById<ImageView>(Resource.Id.imageView53);

            txtQuantity_54 = FindViewById<TextView>(Resource.Id.qtyNum54);
            linear54 = FindViewById<LinearLayout>(Resource.Id.Linear54);
            base_price54 = FindViewById<TextView>(Resource.Id.base_price54);
            imgview54 = FindViewById<ImageView>(Resource.Id.imageView54);

            // SANDWICH
            txtQuantity_55 = FindViewById<TextView>(Resource.Id.qtyNum55);
            linear55 = FindViewById<LinearLayout>(Resource.Id.Linear55);
            base_price55 = FindViewById<TextView>(Resource.Id.base_price55);
            imgview55 = FindViewById<ImageView>(Resource.Id.imageView55);

            txtQuantity_56 = FindViewById<TextView>(Resource.Id.qtyNum56);
            linear56 = FindViewById<LinearLayout>(Resource.Id.Linear56);
            base_price56 = FindViewById<TextView>(Resource.Id.base_price56);
            imgview56 = FindViewById<ImageView>(Resource.Id.imageView56);

            txtQuantity_57 = FindViewById<TextView>(Resource.Id.qtyNum57);
            linear57 = FindViewById<LinearLayout>(Resource.Id.Linear57);
            base_price57 = FindViewById<TextView>(Resource.Id.base_price57);
            imgview57 = FindViewById<ImageView>(Resource.Id.imageView57);

            // SALAD
            txtQuantity_58 = FindViewById<TextView>(Resource.Id.qtyNum58);
            linear58 = FindViewById<LinearLayout>(Resource.Id.Linear58);
            base_price58 = FindViewById<TextView>(Resource.Id.base_price58);
            imgview58 = FindViewById<ImageView>(Resource.Id.imageView58);

            txtQuantity_59 = FindViewById<TextView>(Resource.Id.qtyNum59);
            linear59 = FindViewById<LinearLayout>(Resource.Id.Linear59);
            base_price59 = FindViewById<TextView>(Resource.Id.base_price59);
            imgview59 = FindViewById<ImageView>(Resource.Id.imageView59);

            txtQuantity_60 = FindViewById<TextView>(Resource.Id.qtyNum60);
            linear60 = FindViewById<LinearLayout>(Resource.Id.Linear60);
            base_price60 = FindViewById<TextView>(Resource.Id.base_price60);
            imgview60 = FindViewById<ImageView>(Resource.Id.imageView60);

            subtotal = FindViewById<TextView>(Resource.Id.subTotal);
            subtotal_value = FindViewById<TextView>(Resource.Id.subTotal_Value);
            // End TextView Customer Order

            country1.Focusable = false;
            country1.Clickable = false;

            // Starting querying
            MySqlConnection conn = new MySqlConnection();

            string query = "server=localhost;port=3306;database=mydb;user id=mydbuser;password=123;";
            conn.ConnectionString = query;

            try
            {

                conn.Open();

                using (MySqlCommand cmd_select1 = new MySqlCommand("select * from wp_product_cart where customer_name = " + session_user + "; " +

                    // EFC CHICKEN TERIYAKI
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id1 AND wp_product_cart.customer_name = @cust_name1 AND wp_product_cart.product_name = @prod_efc1;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id2 AND wp_product_cart.customer_name = @cust_name2 AND wp_product_cart.product_name = @prod_efc2;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id3 AND wp_product_cart.customer_name = @cust_name3 AND wp_product_cart.product_name = @prod_efc3;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id4 AND wp_product_cart.customer_name = @cust_name4 AND wp_product_cart.product_name = @prod_efc4;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id5 AND wp_product_cart.customer_name = @cust_name5 AND wp_product_cart.product_name = @prod_efc5;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id6 AND wp_product_cart.customer_name = @cust_name6 AND wp_product_cart.product_name = @prod_efc6;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id7 AND wp_product_cart.customer_name = @cust_name7 AND wp_product_cart.product_name = @prod_efc7;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id8 AND wp_product_cart.customer_name = @cust_name8 AND wp_product_cart.product_name = @prod_efc8;" +

                    // EFC CHICKEN CURRY
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id9 AND wp_product_cart.customer_name = @cust_name9 AND wp_product_cart.product_name = @prod_efc9;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id10 AND wp_product_cart.customer_name = @cust_name10 AND wp_product_cart.product_name = @prod_efc10;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id11 AND wp_product_cart.customer_name = @cust_name11 AND wp_product_cart.product_name = @prod_efc11;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id12 AND wp_product_cart.customer_name = @cust_name12 AND wp_product_cart.product_name = @prod_efc12;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id13 AND wp_product_cart.customer_name = @cust_name13 AND wp_product_cart.product_name = @prod_efc13;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id14 AND wp_product_cart.customer_name = @cust_name14 AND wp_product_cart.product_name = @prod_efc14;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id15 AND wp_product_cart.customer_name = @cust_name15 AND wp_product_cart.product_name = @prod_efc15;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id16 AND wp_product_cart.customer_name = @cust_name16 AND wp_product_cart.product_name = @prod_efc16;" +

                    // EFC BEEF TERIYAKI
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id17 AND wp_product_cart.customer_name = @cust_name17 AND wp_product_cart.product_name = @prod_efc17;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id18 AND wp_product_cart.customer_name = @cust_name18 AND wp_product_cart.product_name = @prod_efc18;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id19 AND wp_product_cart.customer_name = @cust_name19 AND wp_product_cart.product_name = @prod_efc19;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id20 AND wp_product_cart.customer_name = @cust_name20 AND wp_product_cart.product_name = @prod_efc20;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id21 AND wp_product_cart.customer_name = @cust_name21 AND wp_product_cart.product_name = @prod_efc21;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id22 AND wp_product_cart.customer_name = @cust_name22 AND wp_product_cart.product_name = @prod_efc22;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id23 AND wp_product_cart.customer_name = @cust_name23 AND wp_product_cart.product_name = @prod_efc23;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id24 AND wp_product_cart.customer_name = @cust_name24 AND wp_product_cart.product_name = @prod_efc24;" +

                    // EFC BEEF CURRY
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id25 AND wp_product_cart.customer_name = @cust_name25 AND wp_product_cart.product_name = @prod_efc25;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id26 AND wp_product_cart.customer_name = @cust_name26 AND wp_product_cart.product_name = @prod_efc26;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id27 AND wp_product_cart.customer_name = @cust_name27 AND wp_product_cart.product_name = @prod_efc27;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id28 AND wp_product_cart.customer_name = @cust_name28 AND wp_product_cart.product_name = @prod_efc28;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id29 AND wp_product_cart.customer_name = @cust_name29 AND wp_product_cart.product_name = @prod_efc29;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id30 AND wp_product_cart.customer_name = @cust_name30 AND wp_product_cart.product_name = @prod_efc30;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id31 AND wp_product_cart.customer_name = @cust_name31 AND wp_product_cart.product_name = @prod_efc31;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id32 AND wp_product_cart.customer_name = @cust_name32 AND wp_product_cart.product_name = @prod_efc32;" +

                    // The Rest Product
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id33 AND wp_product_cart.customer_name = @cust_name33 AND wp_product_cart.product_name = @prod_efc33;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id34 AND wp_product_cart.customer_name = @cust_name34 AND wp_product_cart.product_name = @prod_efc34;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id35 AND wp_product_cart.customer_name = @cust_name35 AND wp_product_cart.product_name = @prod_efc35;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id36 AND wp_product_cart.customer_name = @cust_name36 AND wp_product_cart.product_name = @prod_efc36;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id37 AND wp_product_cart.customer_name = @cust_name37 AND wp_product_cart.product_name = @prod_efc37;" +

                    // BEEF
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id38 AND wp_product_cart.customer_name = @cust_name38 AND wp_product_cart.product_name = @prod_efc38;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id39 AND wp_product_cart.customer_name = @cust_name39 AND wp_product_cart.product_name = @prod_efc39;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id40 AND wp_product_cart.customer_name = @cust_name40 AND wp_product_cart.product_name = @prod_efc40;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id41 AND wp_product_cart.customer_name = @cust_name41 AND wp_product_cart.product_name = @prod_efc41;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id42 AND wp_product_cart.customer_name = @cust_name42 AND wp_product_cart.product_name = @prod_efc42;" +

                    // FISH
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id43 AND wp_product_cart.customer_name = @cust_name43 AND wp_product_cart.product_name = @prod_efc43;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id44 AND wp_product_cart.customer_name = @cust_name44 AND wp_product_cart.product_name = @prod_efc44;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id45 AND wp_product_cart.customer_name = @cust_name45 AND wp_product_cart.product_name = @prod_efc45;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id46 AND wp_product_cart.customer_name = @cust_name46 AND wp_product_cart.product_name = @prod_efc46;" +

                    // VEGAN
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id47 AND wp_product_cart.customer_name = @cust_name47 AND wp_product_cart.product_name = @prod_efc47;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id48 AND wp_product_cart.customer_name = @cust_name48 AND wp_product_cart.product_name = @prod_efc48;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id49 AND wp_product_cart.customer_name = @cust_name49 AND wp_product_cart.product_name = @prod_efc49;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id50 AND wp_product_cart.customer_name = @cust_name50 AND wp_product_cart.product_name = @prod_efc50;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id51 AND wp_product_cart.customer_name = @cust_name51 AND wp_product_cart.product_name = @prod_efc51;" +

                    // PASTA
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id52 AND wp_product_cart.customer_name = @cust_name52 AND wp_product_cart.product_name = @prod_efc52;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id53 AND wp_product_cart.customer_name = @cust_name53 AND wp_product_cart.product_name = @prod_efc53;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id54 AND wp_product_cart.customer_name = @cust_name54 AND wp_product_cart.product_name = @prod_efc54;" +

                    // SANDWICH
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id55 AND wp_product_cart.customer_name = @cust_name55 AND wp_product_cart.product_name = @prod_efc55;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id56 AND wp_product_cart.customer_name = @cust_name56 AND wp_product_cart.product_name = @prod_efc56;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id57 AND wp_product_cart.customer_name = @cust_name57 AND wp_product_cart.product_name = @prod_efc57;" +

                    // SALAD
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id58 AND wp_product_cart.customer_name = @cust_name58 AND wp_product_cart.product_name = @prod_efc58;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id59 AND wp_product_cart.customer_name = @cust_name59 AND wp_product_cart.product_name = @prod_efc59;" +
                    "select * from wp_product_cart INNER JOIN wp_product_cart_add_ons ON wp_product_cart.session_order_id = wp_product_cart_add_ons.session_order_id where wp_product_cart_add_ons.key_same_result = @key_id60 AND wp_product_cart.customer_name = @cust_name60 AND wp_product_cart.product_name = @prod_efc60;" +

                    // GETTING USER INFORMATION FROM THE DATABASE --> wp_kdskli23jkusers
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_first_name';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_last_name';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_company';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_address_1';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_city';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_postcode';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_payment';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_phone';" +
                    "select * from wp_kdskli23jkusers INNER JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id where wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_email';" +

                    // Sum Subtotal
                    "select SUM(compute_qty_price) AS subtotal_price from wp_product_cart where customer_name = @cust_name_subtotal_price;" +
                    // Sum Total
                    // the comment in below is show you how to select multiple row in a single queue ;)
                    //"select (select SUM(price) from wp_product_cart where customer_name = @cust_name_total_price) as total_price," +
                    //"(select SUM(add_ons_price) from wp_product_cart_add_ons where customer_name = @cust_name_total_price2) as total_add_ons;", conn))
                    // end multiple selection
                    "select SUM(compute_qty_price) AS total_price from wp_product_cart where customer_name = @cust_name_total_price;", conn))
                {   

                    // EFC CHICKEN TERIYAKI
                    cmd_select1.Parameters.AddWithValue("@key_id1", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc1", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name1", session_user);
                    cmd_select1.Parameters.AddWithValue("@key_id2", 2);
                    cmd_select1.Parameters.AddWithValue("@prod_efc2", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name2", session_user);
                    cmd_select1.Parameters.AddWithValue("@key_id3", 3);
                    cmd_select1.Parameters.AddWithValue("@prod_efc3", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name3", session_user);
                    cmd_select1.Parameters.AddWithValue("@key_id4", 4);
                    cmd_select1.Parameters.AddWithValue("@prod_efc4", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name4", session_user);
                    cmd_select1.Parameters.AddWithValue("@key_id5", 5);
                    cmd_select1.Parameters.AddWithValue("@prod_efc5", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name5", session_user);
                    cmd_select1.Parameters.AddWithValue("@key_id6", 6);
                    cmd_select1.Parameters.AddWithValue("@prod_efc6", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name6", session_user);
                    cmd_select1.Parameters.AddWithValue("@key_id7", 7);
                    cmd_select1.Parameters.AddWithValue("@prod_efc7", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name7", session_user);
                    cmd_select1.Parameters.AddWithValue("@key_id8", 8);
                    cmd_select1.Parameters.AddWithValue("@prod_efc8", "EFC CHICKEN TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name8", session_user);

                    // EFC CHICKEN CURRY
                    cmd_select1.Parameters.AddWithValue("@key_id9", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc9", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name9", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id10", 2);
                    cmd_select1.Parameters.AddWithValue("@prod_efc10", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name10", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id11", 3);
                    cmd_select1.Parameters.AddWithValue("@prod_efc11", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name11", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id12", 4);
                    cmd_select1.Parameters.AddWithValue("@prod_efc12", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name12", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id13", 5);
                    cmd_select1.Parameters.AddWithValue("@prod_efc13", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name13", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id14", 6);
                    cmd_select1.Parameters.AddWithValue("@prod_efc14", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name14", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id15", 7);
                    cmd_select1.Parameters.AddWithValue("@prod_efc15", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name15", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id16", 8);
                    cmd_select1.Parameters.AddWithValue("@prod_efc16", "EFC CHICKEN CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name16", session_user);

                    // EFC BEEF TERIYAKI
                    cmd_select1.Parameters.AddWithValue("@key_id17", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc17", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name17", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id18", 2);
                    cmd_select1.Parameters.AddWithValue("@prod_efc18", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name18", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id19", 3);
                    cmd_select1.Parameters.AddWithValue("@prod_efc19", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name19", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id20", 4);
                    cmd_select1.Parameters.AddWithValue("@prod_efc20", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name20", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id21", 5);
                    cmd_select1.Parameters.AddWithValue("@prod_efc21", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name21", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id22", 6);
                    cmd_select1.Parameters.AddWithValue("@prod_efc22", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name22", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id23", 7);
                    cmd_select1.Parameters.AddWithValue("@prod_efc23", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name23", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id24", 8);
                    cmd_select1.Parameters.AddWithValue("@prod_efc24", "EFC BEEF TERIYAKI");
                    cmd_select1.Parameters.AddWithValue("@cust_name24", session_user);

                    // EFC BEEF CURRY
                    cmd_select1.Parameters.AddWithValue("@key_id25", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc25", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name25", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id26", 2);
                    cmd_select1.Parameters.AddWithValue("@prod_efc26", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name26", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id27", 3);
                    cmd_select1.Parameters.AddWithValue("@prod_efc27", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name27", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id28", 4);
                    cmd_select1.Parameters.AddWithValue("@prod_efc28", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name28", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id29", 5);
                    cmd_select1.Parameters.AddWithValue("@prod_efc29", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name29", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id30", 6);
                    cmd_select1.Parameters.AddWithValue("@prod_efc30", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name30", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id31", 7);
                    cmd_select1.Parameters.AddWithValue("@prod_efc31", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name31", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id32", 8);
                    cmd_select1.Parameters.AddWithValue("@prod_efc32", "EFC BEEF CURRY");
                    cmd_select1.Parameters.AddWithValue("@cust_name32", session_user);

                    // The Rest Product
                    cmd_select1.Parameters.AddWithValue("@key_id33", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc33", "CHICKEN GRATIN WITH MIX VEGETABLES");
                    cmd_select1.Parameters.AddWithValue("@cust_name33", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id34", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc34", "ROASTED CHICKEN WITH FUNKY SALAD");
                    cmd_select1.Parameters.AddWithValue("@cust_name34", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id35", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc35", "CHICKEN WITH CARAMELIZED APPLE WITH POTATO WEDGES");
                    cmd_select1.Parameters.AddWithValue("@cust_name35", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id36", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc36", "ROSEMARY CHICKEN BREAST WITH SIMPLE PASTA OR MIX");
                    cmd_select1.Parameters.AddWithValue("@cust_name36", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id37", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc37", "CHICKEN TIKKA WITH PAN GRILL BANANA WITH MIX GREENS");
                    cmd_select1.Parameters.AddWithValue("@cust_name37", session_user);

                    // BEEF
                    cmd_select1.Parameters.AddWithValue("@key_id38", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc38", "ARROZ ALA CUBANA WITH GARLIC MUSHROOM SPINACH");
                    cmd_select1.Parameters.AddWithValue("@cust_name38", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id39", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc39", "MINT BEEF WITH SALSA");
                    cmd_select1.Parameters.AddWithValue("@cust_name39", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id40", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc40", "BALSAMIC BEEF WITH ONION CONFIT SERVED WITH MIX GREENS");
                    cmd_select1.Parameters.AddWithValue("@cust_name40", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id41", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc41", "MUSTARD BEEF CUTLETS WITH BASIL CREAM SERVED WITH MASHED POTATO");
                    cmd_select1.Parameters.AddWithValue("@cust_name41", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id42", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc42", "BEEF WITH CAPSICUM PESTO SERVED WITH MASHED KUMARA");
                    cmd_select1.Parameters.AddWithValue("@cust_name42", session_user);

                    // FISH
                    cmd_select1.Parameters.AddWithValue("@key_id43", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc43", "CHIMICHURRI FISH WITH RICE AND MIX GREENS");
                    cmd_select1.Parameters.AddWithValue("@cust_name43", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id44", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc44", "GINGER FISH DRIZZLED WITH WASABI SERVED WITH BROWN RICE");
                    cmd_select1.Parameters.AddWithValue("@cust_name44", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id45", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc45", "DILL PESTO TUNA WITH SIMPLE PASTA");
                    cmd_select1.Parameters.AddWithValue("@cust_name45", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id46", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc46", "YOGURT SALMON WITH SUNDRIED TOMATO SERVED WITH BROWN RICE");
                    cmd_select1.Parameters.AddWithValue("@cust_name46", session_user);

                    // VEGAN
                    cmd_select1.Parameters.AddWithValue("@key_id47", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc47", "BARBECUE CAULIFLOWER WITH MASHED POTATO");
                    cmd_select1.Parameters.AddWithValue("@cust_name47", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id48", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc48", "ROASTED SQUASH AND TOFU WITH PUMPKIN PUREE");
                    cmd_select1.Parameters.AddWithValue("@cust_name48", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id49", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc49", "CREAMY VEGAN PENNE");
                    cmd_select1.Parameters.AddWithValue("@cust_name49", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id50", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc50", "TOFU STEAK WITH MUSHROOM");
                    cmd_select1.Parameters.AddWithValue("@cust_name50", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id51", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc51", "LO MEIN PRIMAVERA PASTA");
                    cmd_select1.Parameters.AddWithValue("@cust_name51", session_user);

                    // PASTA
                    cmd_select1.Parameters.AddWithValue("@key_id52", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc52", "CHEESY COLD PASTA");
                    cmd_select1.Parameters.AddWithValue("@cust_name52", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id53", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc53", "PESTO PASTA WITH CHICKEN BREAST");
                    cmd_select1.Parameters.AddWithValue("@cust_name53", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id54", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc54", "SEAFOOD MARINARA");
                    cmd_select1.Parameters.AddWithValue("@cust_name54", session_user);

                    // SANDWICH
                    cmd_select1.Parameters.AddWithValue("@key_id55", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc55", "CHICKEN PITA");
                    cmd_select1.Parameters.AddWithValue("@cust_name55", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id56", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc56", "GRILLED VEGGIE SANDWICH");
                    cmd_select1.Parameters.AddWithValue("@cust_name56", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id57", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc57", "GRILLED BEEF WITH MOZZARELLA CHEESE");
                    cmd_select1.Parameters.AddWithValue("@cust_name57", session_user);

                    // SALAD
                    cmd_select1.Parameters.AddWithValue("@key_id58", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc58", "FUNKY FRUIT SALAD");
                    cmd_select1.Parameters.AddWithValue("@cust_name58", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id59", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc59", "MEDITERESIAN CHICKEN SALAD");
                    cmd_select1.Parameters.AddWithValue("@cust_name59", session_user);

                    cmd_select1.Parameters.AddWithValue("@key_id60", 1);
                    cmd_select1.Parameters.AddWithValue("@prod_efc60", "SALAD NICOISE");
                    cmd_select1.Parameters.AddWithValue("@cust_name60", session_user);

                    // PARAMETER VALUE OF GETTING INFORMATION OF THE USER FROM THE DATABASE
                    //cmd_select1.Parameters.AddWithValue("@gather_id", session_user);

                    // subtotal parameter
                    cmd_select1.Parameters.AddWithValue("@cust_name_subtotal_price", session_user);
                    // total parameter
                    cmd_select1.Parameters.AddWithValue("@cust_name_total_price", session_user);
                    //cmd_select1.Parameters.AddWithValue("@cust_name_total_price2", session_user);
                    //cmd_select1.Parameters.AddWithValue("@customer_name1", session_user);
                    //cmd_select1.Parameters.AddWithValue("product_name1", "EFC CHICKEN TERIYAKI");

                    using (MySqlDataReader myReader = cmd_select1.ExecuteReader())
                    {

                        int quantity1, quantity2, quantity3, quantity4, quantity5, quantity6, quantity7, quantity8;
                        int quantity9, quantity10, quantity11, quantity12, quantity13, quantity14, quantity15, quantity16;
                        int quantity17, quantity18, quantity19, quantity20, quantity21, quantity22, quantity23, quantity24;
                        int quantity25, quantity26, quantity27, quantity28, quantity29, quantity30, quantity31, quantity32;

                        // the rest product
                        int quantity33, quantity34, quantity35, quantity36, quantity37;
                        // beef
                        int quantity38, quantity39, quantity40, quantity41, quantity42;
                        // fish
                        int quantity43, quantity44, quantity45, quantity46;
                        // vegan
                        int quantity47, quantity48, quantity49, quantity50, quantity51;
                        // pasta
                        int quantity52, quantity53, quantity54;
                        // sandwich
                        int quantity55, quantity56, quantity57;
                        // salad
                        int quantity58, quantity59, quantity60;

                        

                        string img_url1 = "", img_url2 = "", img_url3 = "", img_url4 = "", img_url5 = "", img_url6 = "", img_url7 = "", img_url8 = "";
                        string img_url9 = "", img_url10 = "", img_url11 = "", img_url12 = "", img_url13 = "", img_url14 = "", img_url15 = "", img_url16 = "";
                        string img_url17 = "", img_url18 = "", img_url19 = "", img_url20 = "", img_url21 = "", img_url22 = "", img_url23 = "", img_url24 = "";
                        string img_url25 = "", img_url26 = "", img_url27 = "", img_url28 = "", img_url29 = "", img_url30 = "", img_url31 = "", img_url32 = "";

                        // the rest product
                        string img_url33 = "", img_url34 = "", img_url35 = "", img_url36 = "", img_url37 = "";
                        // beef
                        string img_url38 = "", img_url39 = "", img_url40 = "", img_url41 = "", img_url42 = "";
                        // fish
                        string img_url43 = "", img_url44 = "", img_url45 = "", img_url46 = "";
                        // vegan
                        string img_url47 = "", img_url48 = "", img_url49 = "", img_url50 = "", img_url51 = "";
                        // pasta
                        string img_url52 = "", img_url53 = "", img_url54 = "";
                        // sandwich
                        string img_url55 = "", img_url56 = "", img_url57 = "";
                        // salad
                        string img_url58 = "", img_url59 = "", img_url60 = "";

                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                //nothing to do
                                //...
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    
                                    quantity1 = int.Parse(myReader["quantity"].ToString());
                                    price1 = int.Parse(myReader["compute_qty_price"].ToString());
                                    
                                    txtQuantity_1.Text = quantity1.ToString();
                                    base_price1.Text = "₱" + price1.ToString() + ".00";

                                    img_url1 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url1))
                                            .Into(imgview1);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                   
                                    quantity2 = int.Parse(myReader["quantity"].ToString());
                                    price2 = int.Parse(myReader["compute_qty_price"].ToString());
                                  
                                    txtQuantity_2.Text = quantity2.ToString();
                                    base_price2.Text = "₱" + price2.ToString() + ".00";

                                    img_url2 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url2))
                                            .Into(imgview2);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //user3 = myReader["quantity"].ToString();
                                    quantity3 = int.Parse(myReader["quantity"].ToString());
                                    price3 = int.Parse(myReader["compute_qty_price"].ToString());
                                    //txttitle.Text = user3;
                                    //increment_int = quantity3;
                                    txtQuantity_3.Text = quantity3.ToString();
                                    base_price3.Text = "₱" + price3.ToString() + ".00";

                                    img_url3 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url3))
                                            .Into(imgview3);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //user4 = myReader["quantity"].ToString();
                                    quantity4 = int.Parse(myReader["quantity"].ToString());
                                    price4 = int.Parse(myReader["compute_qty_price"].ToString());
                                    //txttitle.Text = user4;
                                    //increment_int = quantity4;
                                    txtQuantity_4.Text = quantity4.ToString();
                                    base_price4.Text = "₱" + price4.ToString() + ".00";

                                    img_url4 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url4))
                                            .Into(imgview4);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //user5 = myReader["quantity"].ToString();
                                    quantity5 = int.Parse(myReader["quantity"].ToString());
                                    price5 = int.Parse(myReader["compute_qty_price"].ToString());
                                    //txttitle.Text = user5;
                                    //increment_int = quantity5;
                                    txtQuantity_5.Text = quantity5.ToString();
                                    base_price5.Text = "₱" + price5.ToString() + ".00";

                                    img_url5 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url5))
                                            .Into(imgview5);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //user6 = myReader["quantity"].ToString();
                                    quantity6 = int.Parse(myReader["quantity"].ToString());
                                    price6 = int.Parse(myReader["compute_qty_price"].ToString());
                                    //txttitle.Text = user6;
                                    //increment_int = quantity6;
                                    txtQuantity_6.Text = quantity6.ToString();
                                    base_price6.Text = "₱" + price6.ToString() + ".00";

                                    img_url6 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url6))
                                            .Into(imgview6);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //user7 = myReader["quantity"].ToString();
                                    quantity7 = int.Parse(myReader["quantity"].ToString());
                                    price7 = int.Parse(myReader["compute_qty_price"].ToString());
                                    //txttitle.Text = user7;
                                    //increment_int = quantity7;
                                    txtQuantity_7.Text = quantity7.ToString();
                                    base_price7.Text = "₱" + price7.ToString() + ".00";

                                    img_url7 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url7))
                                            .Into(imgview7);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //user8 = myReader["quantity"].ToString();
                                    quantity8 = int.Parse(myReader["quantity"].ToString());
                                    price8 = int.Parse(myReader["compute_qty_price"].ToString());
                                    //txttitle.Text = user8;
                                    //increment_int = quantity8;
                                    txtQuantity_8.Text = quantity8.ToString();
                                    base_price8.Text = "₱" + price8.ToString() + ".00";

                                    img_url8 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url8))
                                            .Into(imgview8);

                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price9 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price9.Text = "₱" + price9.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity9 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_9.Text = quantity9.ToString();

                                    img_url9 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url9))
                                            .Into(imgview9);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price10 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price10.Text = "₱" + price10.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity10 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_10.Text = quantity10.ToString();

                                    img_url10 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url10))
                                            .Into(imgview10);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price11 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price11.Text = "₱" + price11.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity11 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_11.Text = quantity11.ToString();

                                    img_url11 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url11))
                                            .Into(imgview11);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price12 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price12.Text = "₱" + price12.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity12 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_12.Text = quantity12.ToString();

                                    img_url12 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url12))
                                            .Into(imgview12);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price13 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price13.Text = "₱" + price13.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity13 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_13.Text = quantity13.ToString();

                                    img_url13 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url13))
                                            .Into(imgview13);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price14 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price14.Text = "₱" + price14.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity14 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_14.Text = quantity14.ToString();

                                    img_url14 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url14))
                                            .Into(imgview14);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price15 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price15.Text = "₱" + price15.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity15 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_15.Text = quantity15.ToString();

                                    img_url15 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url15))
                                            .Into(imgview15);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price16 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price16.Text = "₱" + price16.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity16 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_16.Text = quantity16.ToString();

                                    img_url16 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url16))
                                            .Into(imgview16);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price17 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price17.Text = "₱" + price17.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity17 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_17.Text = quantity17.ToString();

                                    img_url17 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url17))
                                            .Into(imgview17);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price18 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price18.Text = "₱" + price18.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity18 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_18.Text = quantity18.ToString();

                                    img_url18 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url18))
                                            .Into(imgview18);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price19 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price19.Text = "₱" + price19.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity19 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_19.Text = quantity19.ToString();

                                    img_url19 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url19))
                                            .Into(imgview19);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price20 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price20.Text = "₱" + price20.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity20 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_20.Text = quantity20.ToString();

                                    img_url20 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url20))
                                            .Into(imgview20);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price21 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price21.Text = "₱" + price21.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity21 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_21.Text = quantity21.ToString();

                                    img_url21 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url21))
                                            .Into(imgview21);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price22 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price22.Text = "₱" + price22.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity22 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_22.Text = quantity22.ToString();

                                    img_url22 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url22))
                                            .Into(imgview22);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price23 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price23.Text = "₱" + price23.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity23 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_23.Text = quantity23.ToString();

                                    img_url23 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url23))
                                            .Into(imgview23);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price24 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price24.Text = "₱" + price24.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity24 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_24.Text = quantity24.ToString();

                                    img_url24 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url24))
                                            .Into(imgview24);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price25 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price25.Text = "₱" + price25.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity25 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_25.Text = quantity25.ToString();

                                    img_url25 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url25))
                                            .Into(imgview25);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price26 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price26.Text = "₱" + price26.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity26 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_26.Text = quantity26.ToString();

                                    img_url26 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url26))
                                            .Into(imgview26);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price27 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price27.Text = "₱" + price27.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity27 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_27.Text = quantity27.ToString();

                                    img_url27 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url27))
                                            .Into(imgview27);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price28 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price28.Text = "₱" + price28.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity28 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_28.Text = quantity28.ToString();

                                    img_url28 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url28))
                                            .Into(imgview28);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price29 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price29.Text = "₱" + price29.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity29 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_29.Text = quantity29.ToString();

                                    img_url29 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url29))
                                            .Into(imgview29);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price30 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price30.Text = "₱" + price30.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity30 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_30.Text = quantity30.ToString();

                                    img_url30 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url30))
                                            .Into(imgview30);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price31 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price31.Text = "₱" + price31.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity31 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_31.Text = quantity31.ToString();

                                    img_url31 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url31))
                                            .Into(imgview31);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price32 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price32.Text = "₱" + price32.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity32 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;
                                    

                                    txtQuantity_32.Text = quantity32.ToString();

                                    img_url32 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url32))
                                            .Into(imgview32);
                                }
                            }

                            // The Rest Product
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price33 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price33.Text = "₱" + price33.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity33 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_33.Text = quantity33.ToString();

                                    img_url33 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url33))
                                            .Into(imgview33);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price34 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price34.Text = "₱" + price34.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity34 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_34.Text = quantity34.ToString();

                                    img_url34 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url34))
                                            .Into(imgview34);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price35 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price35.Text = "₱" + price35.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity35 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_35.Text = quantity35.ToString();

                                    img_url35 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url35))
                                            .Into(imgview35);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price36 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price36.Text = "₱" + price36.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity36 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_36.Text = quantity36.ToString();

                                    img_url36 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url36))
                                            .Into(imgview36);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price37 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price37.Text = "₱" + price37.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity37 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_37.Text = quantity37.ToString();

                                    img_url37 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url37))
                                            .Into(imgview37);
                                }
                            }

                            // beef
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price38 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price38.Text = "₱" + price38.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity38 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_38.Text = quantity38.ToString();

                                    img_url38 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url38))
                                            .Into(imgview38);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price39 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price39.Text = "₱" + price39.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity39 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_39.Text = quantity39.ToString();

                                    img_url39 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url39))
                                            .Into(imgview39);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price40 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price40.Text = "₱" + price40.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity40 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_40.Text = quantity40.ToString();

                                    img_url40 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url40))
                                            .Into(imgview40);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price41 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price41.Text = "₱" + price41.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity41 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_41.Text = quantity41.ToString();

                                    img_url41 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url41))
                                            .Into(imgview41);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price42 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price42.Text = "₱" + price42.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity42 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_42.Text = quantity42.ToString();

                                    img_url42 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url42))
                                            .Into(imgview42);
                                }
                            }

                            // FISH
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price43 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price43.Text = "₱" + price43.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity43 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_43.Text = quantity43.ToString();

                                    img_url43 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url43))
                                            .Into(imgview43);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price44 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price44.Text = "₱" + price44.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity44 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                  

                                    txtQuantity_44.Text = quantity44.ToString();

                                    img_url44 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url44))
                                            .Into(imgview44);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price45 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price45.Text = "₱" + price45.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity45 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_45.Text = quantity45.ToString();

                                    img_url45 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url45))
                                            .Into(imgview45);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price46 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price46.Text = "₱" + price46.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity46 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_46.Text = quantity46.ToString();

                                    img_url46 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url46))
                                            .Into(imgview46);
                                }
                            }

                            // VEGAN
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price47 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price47.Text = "₱" + price47.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity47 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_47.Text = quantity47.ToString();

                                    img_url47 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url47))
                                            .Into(imgview47);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price48 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price48.Text = "₱" + price48.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity48 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_48.Text = quantity48.ToString();

                                    img_url48 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url48))
                                            .Into(imgview48);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price49 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price49.Text = "₱" + price49.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity49 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_49.Text = quantity49.ToString();

                                    img_url49 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url49))
                                            .Into(imgview49);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price50 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price50.Text = "₱" + price50.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity50 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_50.Text = quantity50.ToString();

                                    img_url50 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url50))
                                            .Into(imgview50);
                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price51 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price51.Text = "₱" + price51.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity51 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_51.Text = quantity51.ToString();

                                    img_url51 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url51))
                                            .Into(imgview51);
                                }
                            }

                            // pasta
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price52 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price52.Text = "₱" + price52.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity52 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                  

                                    txtQuantity_52.Text = quantity52.ToString();

                                    img_url52 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url52))
                                            .Into(imgview52);
                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price53 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price53.Text = "₱" + price53.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity53 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                               

                                    txtQuantity_53.Text = quantity53.ToString();

                                    img_url53 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url53))
                                            .Into(imgview53);
                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price54 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price54.Text = "₱" + price54.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity54 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_54.Text = quantity54.ToString();

                                    img_url54 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url54))
                                            .Into(imgview54);
                                }
                            }

                            // SANDWICH
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price55 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price55.Text = "₱" + price55.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity55 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_55.Text = quantity55.ToString();

                                    img_url55 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url55))
                                            .Into(imgview55);
                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price56 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price56.Text = "₱" + price56.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity56 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_56.Text = quantity56.ToString();

                                    img_url56 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url56))
                                            .Into(imgview56);
                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price57 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price57.Text = "₱" + price57.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity57 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                   

                                    txtQuantity_57.Text = quantity57.ToString();

                                    img_url57 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url57))
                                            .Into(imgview57);
                                }
                            }

                            // SALAD
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price58 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price58.Text = "₱" + price58.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity58 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                  

                                    txtQuantity_58.Text = quantity58.ToString();

                                    img_url58 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url58))
                                            .Into(imgview58);
                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price59 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price59.Text = "₱" + price59.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity59 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                 

                                    txtQuantity_59.Text = quantity59.ToString();

                                    img_url59 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url59))
                                            .Into(imgview59);
                                }
                            }

                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    price60 = int.Parse(myReader["compute_qty_price"].ToString());
                                    base_price60.Text = "₱" + price60.ToString() + ".00";
                                    //user1 = myReader["quantity"].ToString();
                                    quantity60 = int.Parse(myReader["quantity"].ToString());
                                    //txttitle.Text = user1;

                                    

                                    txtQuantity_60.Text = quantity60.ToString();

                                    img_url60 = myReader["image"].ToString();

                                    Picasso.With(this)
                                            .Load((img_url60))
                                            .Into(imgview60);
                                }
                            }

                            // USER INFORMATION (INCLUDED: SHIPPING & BILLING INFORMATION OF THE USER
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;

                                    fName.Text = myReader["meta_value"].ToString();
                                    


                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;

                                    
                                    lName.Text = myReader["meta_value"].ToString();
                                    


                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;


                                    company_Name.Text = myReader["meta_value"].ToString();



                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;


                                    address1.Text = myReader["meta_value"].ToString();



                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;


                                    city1.Text = myReader["meta_value"].ToString();



                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;


                                    zip_code.Text = myReader["meta_value"].ToString();



                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;


                                    billing_payment.Text = myReader["meta_value"].ToString();



                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;


                                    phone1.Text = myReader["meta_value"].ToString();



                                }
                            }
                            if (myReader.NextResult())
                            {
                                while (myReader.Read())
                                {
                                    //VARIABLE OF THE USER ID FROM THE XML LAYOUT
                                    //fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info;


                                    email1.Text = myReader["meta_value"].ToString();



                                }
                            }

                            //subtotal
                            if (myReader.NextResult())
                            {

                                while (myReader.Read())
                                {
                                    
                                    //user1 = myReader["quantity"].ToString();
                                    subtotal_db = int.Parse(myReader["subtotal_price"].ToString());
                                    //txttitle.Text = user1;


                                    subtotal_result = subtotal_db;

                                    subtotal_value.Text = subtotal_result.ToString() + ".00";


                                }

                            }


                            //total
                            if (myReader.NextResult())
                            {

                                while (myReader.Read())
                                {
                                    
                                    //user1 = myReader["quantity"].ToString();
                                    total_price = int.Parse(myReader["total_price"].ToString());
                                    //txttitle.Text = user1;

                                    result1_total = total_price;

                                    final_result_total = result1_total;

                                    nav_bottom_item.SetTitle(final_result_total.ToString());

                                }

                            }

                        }
                        else
                        {
                            Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(this);
                            except.SetTitle("0 ITEM");
                            except.SetMessage("There's no item in your cart");
                            except.SetPositiveButton("Ok", (senderAlert, args) =>
                            {
                                except.Dispose();
                                Finish();
                            });
                            except.Show();
                        }

                    }
                }

                conn.Close();
            }
            catch (MySqlException ex)
            {
                Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(this);
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


            // Visibility of recycleview layout

            // EFC CHICKEN TERIYAKI
            if (txtQuantity_1.Text != "")
            {
                linear1.Visibility = ViewStates.Visible;
            }
            else
            {
                linear1.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_2.Text != "")
            {
                linear2.Visibility = ViewStates.Visible;
            }
            else
            {
                linear2.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_3.Text != "")
            {
                linear3.Visibility = ViewStates.Visible;
            }
            else
            {
                linear3.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_4.Text != "")
            {
                linear4.Visibility = ViewStates.Visible;
            }
            else
            {
                linear4.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_5.Text != "")
            {
                linear5.Visibility = ViewStates.Visible;
            }
            else
            {
                linear5.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_6.Text != "")
            {
                linear6.Visibility = ViewStates.Visible;
            }
            else
            {
                linear6.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_7.Text != "")
            {
                linear7.Visibility = ViewStates.Visible;
            }
            else
            {
                linear7.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_8.Text != "")
            {
                linear8.Visibility = ViewStates.Visible;
            }
            else
            {
                linear8.Visibility = ViewStates.Gone;
            }

            // EFC CHICKEN CURRY
            if (txtQuantity_9.Text != "")
            {
                linear9.Visibility = ViewStates.Visible;
            }
            else
            {
                linear9.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_10.Text != "")
            {
                linear10.Visibility = ViewStates.Visible;
            }
            else
            {
                linear10.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_11.Text != "")
            {
                linear11.Visibility = ViewStates.Visible;
            }
            else
            {
                linear11.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_12.Text != "")
            {
                linear12.Visibility = ViewStates.Visible;
            }
            else
            {
                linear12.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_13.Text != "")
            {
                linear13.Visibility = ViewStates.Visible;
            }
            else
            {
                linear13.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_14.Text != "")
            {
                linear14.Visibility = ViewStates.Visible;
            }
            else
            {
                linear14.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_15.Text != "")
            {
                linear15.Visibility = ViewStates.Visible;
            }
            else
            {
                linear15.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_16.Text != "")
            {
                linear16.Visibility = ViewStates.Visible;
            }
            else
            {
                linear16.Visibility = ViewStates.Gone;
            }

            // EFC BEEF TERIYAKI
            if (txtQuantity_17.Text != "")
            {
                linear17.Visibility = ViewStates.Visible;
            }
            else
            {
                linear17.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_18.Text != "")
            {
                linear18.Visibility = ViewStates.Visible;
            }
            else
            {
                linear18.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_19.Text != "")
            {
                linear19.Visibility = ViewStates.Visible;
            }
            else
            {
                linear19.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_20.Text != "")
            {
                linear20.Visibility = ViewStates.Visible;
            }
            else
            {
                linear20.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_21.Text != "")
            {
                linear21.Visibility = ViewStates.Visible;
            }
            else
            {
                linear21.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_22.Text != "")
            {
                linear22.Visibility = ViewStates.Visible;
            }
            else
            {
                linear22.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_23.Text != "")
            {
                linear23.Visibility = ViewStates.Visible;
            }
            else
            {
                linear23.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_24.Text != "")
            {
                linear24.Visibility = ViewStates.Visible;
            }
            else
            {
                linear24.Visibility = ViewStates.Gone;
            }

            // EFC BEEF CURRY
            if (txtQuantity_25.Text != "")
            {
                linear25.Visibility = ViewStates.Visible;
            }
            else
            {
                linear25.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_26.Text != "")
            {
                linear26.Visibility = ViewStates.Visible;
            }
            else
            {
                linear26.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_27.Text != "")
            {
                linear27.Visibility = ViewStates.Visible;
            }
            else
            {
                linear27.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_28.Text != "")
            {
                linear28.Visibility = ViewStates.Visible;
            }
            else
            {
                linear28.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_29.Text != "")
            {
                linear29.Visibility = ViewStates.Visible;
            }
            else
            {
                linear29.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_30.Text != "")
            {
                linear30.Visibility = ViewStates.Visible;
            }
            else
            {
                linear30.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_31.Text != "")
            {
                linear31.Visibility = ViewStates.Visible;
            }
            else
            {
                linear31.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_32.Text != "")
            {
                linear32.Visibility = ViewStates.Visible;
            }
            else
            {
                linear32.Visibility = ViewStates.Gone;
            }

            // The Rest Product
            if (txtQuantity_33.Text != "")
            {
                linear33.Visibility = ViewStates.Visible;
            }
            else
            {
                linear33.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_34.Text != "")
            {
                linear34.Visibility = ViewStates.Visible;
            }
            else
            {
                linear34.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_35.Text != "")
            {
                linear35.Visibility = ViewStates.Visible;
            }
            else
            {
                linear35.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_36.Text != "")
            {
                linear36.Visibility = ViewStates.Visible;
            }
            else
            {
                linear36.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_37.Text != "")
            {
                linear37.Visibility = ViewStates.Visible;
            }
            else
            {
                linear37.Visibility = ViewStates.Gone;
            }

            // BEEF
            if (txtQuantity_38.Text != "")
            {
                linear38.Visibility = ViewStates.Visible;
            }
            else
            {
                linear38.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_39.Text != "")
            {
                linear39.Visibility = ViewStates.Visible;
            }
            else
            {
                linear39.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_40.Text != "")
            {
                linear40.Visibility = ViewStates.Visible;
            }
            else
            {
                linear40.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_41.Text != "")
            {
                linear41.Visibility = ViewStates.Visible;
            }
            else
            {
                linear41.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_42.Text != "")
            {
                linear42.Visibility = ViewStates.Visible;
            }
            else
            {
                linear42.Visibility = ViewStates.Gone;
            }

            // FISH
            if (txtQuantity_43.Text != "")
            {
                linear43.Visibility = ViewStates.Visible;
            }
            else
            {
                linear43.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_44.Text != "")
            {
                linear44.Visibility = ViewStates.Visible;
            }
            else
            {
                linear44.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_45.Text != "")
            {
                linear45.Visibility = ViewStates.Visible;
            }
            else
            {
                linear45.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_46.Text != "")
            {
                linear46.Visibility = ViewStates.Visible;
            }
            else
            {
                linear46.Visibility = ViewStates.Gone;
            }

            // VEGAN
            if (txtQuantity_47.Text != "")
            {
                linear47.Visibility = ViewStates.Visible;
            }
            else
            {
                linear47.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_48.Text != "")
            {
                linear48.Visibility = ViewStates.Visible;
            }
            else
            {
                linear48.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_49.Text != "")
            {
                linear49.Visibility = ViewStates.Visible;
            }
            else
            {
                linear49.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_50.Text != "")
            {
                linear50.Visibility = ViewStates.Visible;
            }
            else
            {
                linear50.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_51.Text != "")
            {
                linear51.Visibility = ViewStates.Visible;
            }
            else
            {
                linear51.Visibility = ViewStates.Gone;
            }

            // pasta
            if (txtQuantity_52.Text != "")
            {
                linear52.Visibility = ViewStates.Visible;
            }
            else
            {
                linear52.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_53.Text != "")
            {
                linear53.Visibility = ViewStates.Visible;
            }
            else
            {
                linear53.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_54.Text != "")
            {
                linear54.Visibility = ViewStates.Visible;
            }
            else
            {
                linear54.Visibility = ViewStates.Gone;
            }

            // sandwich
            if (txtQuantity_55.Text != "")
            {
                linear55.Visibility = ViewStates.Visible;
            }
            else
            {
                linear55.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_56.Text != "")
            {
                linear56.Visibility = ViewStates.Visible;
            }
            else
            {
                linear56.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_57.Text != "")
            {
                linear57.Visibility = ViewStates.Visible;
            }
            else
            {
                linear57.Visibility = ViewStates.Gone;
            }

            // salad
            if (txtQuantity_58.Text != "")
            {
                linear58.Visibility = ViewStates.Visible;
            }
            else
            {
                linear58.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_59.Text != "")
            {
                linear59.Visibility = ViewStates.Visible;
            }
            else
            {
                linear59.Visibility = ViewStates.Gone;
            }

            if (txtQuantity_60.Text != "")
            {
                linear60.Visibility = ViewStates.Visible;
            }
            else
            {
                linear60.Visibility = ViewStates.Gone;
            }

            // End Visibility of recycleview layout

        }

        private void Btm_nav_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            progressbar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            //fName, lName, company_Name, address1, city1, zip_code, billing_payment, phone1, email1;
            if (fName.Text == "")
            {
                fName.Error = "Please enter your first name";
                
                if (mLinearLayout_expandable.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();
                    
                    
                    txtShow1.Text = "HIDE";
                }
                //fName.Focusable = true;
                fName.RequestFocus();

            }
            else if (lName.Text == "")
            {
                lName.Error = "Please enter your last name";
                
                if (mLinearLayout_expandable.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();
                    
                    txtShow1.Text = "HIDE";
                }
                lName.RequestFocus();

            }
            else if (address1.Text == "")
            {
                address1.Error = "Please enter your address";

                if (mLinearLayout_expandable.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();

                    txtShow1.Text = "HIDE";
                }

                address1.RequestFocus();
            }
            else if (city1.Text == "")
            {
                city1.Error = "Please enter your city";

                if (mLinearLayout_expandable.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();

                    txtShow1.Text = "HIDE";
                }

                city1.RequestFocus();
            }
            else if (zip_code.Text == "")
            {
                zip_code.Error = "Please enter your zip code";

                if (mLinearLayout_expandable.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();

                    txtShow1.Text = "HIDE";
                }

                zip_code.RequestFocus();
            }
            else if (phone1.Text == "")
            {
                phone1.Error = "Please enter your phone/telephone";

                if (mLinearLayout_expandable.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();

                    txtShow1.Text = "HIDE";
                }

                phone1.RequestFocus();
            }
            else if (email1.Text == "")
            {
                email1.Error = "Please enter your email address";

                if (mLinearLayout_expandable.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout_expandable.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout_expandable.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = SlideAnimator_Form(0, mLinearLayout_expandable.MeasuredHeight);
                    mAnimator.Start();

                    txtShow1.Text = "HIDE";
                }

                email1.RequestFocus();
            }
            else
            {
                //int last_insert_id_value = 0;
                switch (e.Item.ItemId)
                {
                    case Resource.Id.menu_pay:

                        progressbar.Visibility = ViewStates.Visible;
                        Window.SetFlags(WindowManagerFlags.NotTouchable, WindowManagerFlags.NotTouchable);

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

                                MySqlCommand cmd_insert = conn.CreateCommand();

                                cmd_insert.Connection = conn;

                            // UTC
                            String myDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                            // GMT
                            DateTimeOffset local_offset = new DateTimeOffset(DateTime.Now);
                                DateTimeOffset gmt_offset = local_offset.ToUniversalTime();
                                String myDate_GMT = gmt_offset.DateTime.ToString("yyyy-MM-dd hh:mm:ss");

                            // MILITARY TIME
                            String myDate_Military_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            // POST_TITLE TIME
                            String post_title = DateTime.Now.ToString("MMMM dd, yyyy @ hh:mm tt");
                                String post_title_date_time = "Order &ndash; " + post_title;

                            // POST_NAME TIME
                            String post_name = gmt_offset.DateTime.ToString("MMM-dd-yyyy-hhmm-tt");
                                String post_name_date_time = "order-" + post_name.ToLower();

                                cmd_insert.CommandText = "insert into wp_kdskli23jkposts(post_author, post_date, post_date_gmt, post_content, post_title, post_excerpt, post_status, " +
                                    "comment_status, ping_status, post_password, post_name, to_ping, pinged, post_modified, post_modified_gmt, post_content_filtered, " +
                                    "post_parent, guid, menu_order, post_type, post_mime_type, comment_count) " +
                                    //values
                                    "values(@post_author, @post_date, @post_date_gmt, @post_content, @post_title, @post_excerpt, @post_status, @comment_status, @ping_status, @post_password, " +
                                    "@post_name, @to_ping, @pinged, @post_modified, @post_modified_gmt, @post_content_filtered, @post_parent, @guid, " +
                                    "@menu_order, @post_type, @post_mime_type, @comment_count); SELECT LAST_INSERT_ID();";

                                cmd_insert.Parameters.AddWithValue("@post_author", 1);
                                cmd_insert.Parameters.AddWithValue("@post_date", myDate_Military_Time);
                                cmd_insert.Parameters.AddWithValue("@post_date_gmt", myDate_GMT);
                                cmd_insert.Parameters.AddWithValue("@post_content", "");
                                cmd_insert.Parameters.AddWithValue("@post_title", post_title_date_time);
                                cmd_insert.Parameters.AddWithValue("@post_excerpt", add_info.Text); // order notes
                                cmd_insert.Parameters.AddWithValue("@post_status", "wc-processing");
                                cmd_insert.Parameters.AddWithValue("@comment_status", "open");
                                cmd_insert.Parameters.AddWithValue("@ping_status", "closed");
                                cmd_insert.Parameters.AddWithValue("@post_password", "");
                                cmd_insert.Parameters.AddWithValue("@post_name", post_name_date_time);
                                cmd_insert.Parameters.AddWithValue("@to_ping", "");
                                cmd_insert.Parameters.AddWithValue("@pinged", "");
                                cmd_insert.Parameters.AddWithValue("@post_modified", myDate_Military_Time);
                                cmd_insert.Parameters.AddWithValue("@post_modified_gmt", myDate_GMT);
                                cmd_insert.Parameters.AddWithValue("@post_content_filtered", "");
                                cmd_insert.Parameters.AddWithValue("@post_parent", 0);
                                cmd_insert.Parameters.AddWithValue("@guid", "http://earthfashioncafe.com/?post_type=shop_order&#038;p=");
                                cmd_insert.Parameters.AddWithValue("@menu_order", 0);
                                cmd_insert.Parameters.AddWithValue("@post_type", "shop_order");
                                cmd_insert.Parameters.AddWithValue("@post_mime_type", "");
                                cmd_insert.Parameters.AddWithValue("@comment_count", 1);

                            // Get last Inserted ID and Execute it
                            int insertedID = Convert.ToInt32(cmd_insert.ExecuteScalar());
                            // End Last Inserted ID

                                cmd_insert.CommandText = "UPDATE wp_kdskli23jkposts SET guid = @guid_update WHERE ID = " + insertedID + ";";
                                cmd_insert.Parameters.AddWithValue("@guid_update", "http://earthfashioncafe.com/?post_type=shop_order&#038;p=" + insertedID);
                                cmd_insert.ExecuteNonQuery();

                            //// select total query parameter value --> this select is to update the total of cart while clicking this method
                            //cmd_insert.CommandText = "select MAX(ID) from wp_kdskli23jkposts; ";
                            //using (MySqlDataReader myReader = cmd_insert.ExecuteReader())
                            //{
                            //    //reader
                            //    while (myReader.Read())
                            //    {
                            //        last_insert_id_value = int.Parse(myReader["MAX(ID)"].ToString());
                            //    }
                            //    // end reader
                            //}

                            cmd_insert.CommandText = "insert into wp_kdskli23jkpostmeta(post_id, meta_key, meta_value) " +
                                    //values
                                    "values(" + insertedID + ", @meta_key, @meta_value), (" + insertedID + ", @meta_key2, @meta_value2), (" + insertedID + ", @meta_key3, @meta_value3), " +
                                    "(" + insertedID + ", @meta_key4, @meta_value4), (" + insertedID + ", @meta_key5, @meta_value5), (" + insertedID + ", @meta_key6, @meta_value6), " +
                                    "(" + insertedID + ", @meta_key7, @meta_value7), (" + insertedID + ", @meta_key8, @meta_value8), (" + insertedID + ", @meta_key9, @meta_value9), " +
                                    "(" + insertedID + ", @meta_key10, @meta_value10), (" + insertedID + ", @meta_key11, @meta_value11), (" + insertedID + ", @meta_key12, @meta_value12), " +
                                    "(" + insertedID + ", @meta_key13, @meta_value13), (" + insertedID + ", @meta_key14, @meta_value14), (" + insertedID + ", @meta_key15, @meta_value15), " +
                                    "(" + insertedID + ", @meta_key16, @meta_value16), (" + insertedID + ", @meta_key17, @meta_value17), (" + insertedID + ", @meta_key18, @meta_value18), " +
                                    "(" + insertedID + ", @meta_key19, @meta_value19), (" + insertedID + ", @meta_key20, @meta_value20), (" + insertedID + ", @meta_key21, @meta_value21), " +
                                    "(" + insertedID + ", @meta_key22, @meta_value22), (" + insertedID + ", @meta_key23, @meta_value23), (" + insertedID + ", @meta_key24, @meta_value24), " +
                                    "(" + insertedID + ", @meta_key25, @meta_value25), (" + insertedID + ", @meta_key26, @meta_value26), (" + insertedID + ", @meta_key27, @meta_value27), " +
                                    "(" + insertedID + ", @meta_key28, @meta_value28), (" + insertedID + ", @meta_key29, @meta_value29), (" + insertedID + ", @meta_key30, @meta_value30), " +
                                    "(" + insertedID + ", @meta_key31, @meta_value31), (" + insertedID + ", @meta_key32, @meta_value32), (" + insertedID + ", @meta_key33, @meta_value33), " +
                                    "(" + insertedID + ", @meta_key34, @meta_value34), (" + insertedID + ", @meta_key35, @meta_value35), (" + insertedID + ", @meta_key36, @meta_value36), " +
                                    "(" + insertedID + ", @meta_key37, @meta_value37), (" + insertedID + ", @meta_key38, @meta_value38), (" + insertedID + ", @meta_key39, @meta_value39), " +
                                    "(" + insertedID + ", @meta_key40, @meta_value40), (" + insertedID + ", @meta_key41, @meta_value41), (" + insertedID + ", @meta_key42, @meta_value42), " +
                                    "(" + insertedID + ", @meta_key43, @meta_value43), (" + insertedID + ", @meta_key44, @meta_value44), (" + insertedID + ", @meta_key45, @meta_value45), " +
                                    "(" + insertedID + ", @meta_key46, @meta_value46), (" + insertedID + ", @meta_key47, @meta_value47),  (" + insertedID + ", @meta_key48, @meta_value48), " +
                                    "(" + insertedID + ", @meta_key49, @meta_value49), (" + insertedID + ", @meta_key50, @meta_value50);";

                            // If you want to call the TextView of Billing & Shipping Form. Just use this variable --> fName, lName, company_Name, address1, city1, country1, zip_code, billing_payment, phone1, email1, add_info

                            // If you want to call the total and result. Just use this variable --> subtotal_result, final_result

                            // Condition Statement of State Country TextView
                            string state_city = "";
                                if (country1.Text == "Metro Manila")
                                {
                                    state_city = "00";
                                }
                            // End Condition Statement of State Country TextView

                            cmd_insert.Parameters.AddWithValue("@meta_key", "_payment_method_title");
                                cmd_insert.Parameters.AddWithValue("@meta_value", "Cash on delivery");

                                cmd_insert.Parameters.AddWithValue("@meta_key2", "_payment_method");
                                cmd_insert.Parameters.AddWithValue("@meta_value2", "cod");

                                cmd_insert.Parameters.AddWithValue("@meta_key3", "_customer_user");
                                cmd_insert.Parameters.AddWithValue("@meta_value3", session_user);

                                cmd_insert.Parameters.AddWithValue("@meta_key4", "_order_key");
                                cmd_insert.Parameters.AddWithValue("@meta_value4", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key5", "_transaction_id");
                                cmd_insert.Parameters.AddWithValue("@meta_value5", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key6", "_customer_ip_address");
                                cmd_insert.Parameters.AddWithValue("@meta_value6", "Android");

                                cmd_insert.Parameters.AddWithValue("@meta_key7", "_customer_user_agent");
                                cmd_insert.Parameters.AddWithValue("@meta_value7", "mozilla/5.0 (windows nt 10.0; win64; x64) applewebkit/537.36 (khtml, like gecko) chrome/66.0.3359.181 safari/537.36");

                                cmd_insert.Parameters.AddWithValue("@meta_key8", "_created_via");
                                cmd_insert.Parameters.AddWithValue("@meta_value8", "checkout");

                                cmd_insert.Parameters.AddWithValue("@meta_key9", "_date_completed");
                                cmd_insert.Parameters.AddWithValue("@meta_value9", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key10", "_completed_date");
                                cmd_insert.Parameters.AddWithValue("@meta_value10", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key11", "_date_paid");
                                cmd_insert.Parameters.AddWithValue("@meta_value11", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key12", "_paid_date");
                                cmd_insert.Parameters.AddWithValue("@meta_value12", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key13", "_cart_hash");
                                cmd_insert.Parameters.AddWithValue("@meta_value13", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key14", "_billing_first_name");
                                cmd_insert.Parameters.AddWithValue("@meta_value14", fName.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key15", "_billing_last_name");
                                cmd_insert.Parameters.AddWithValue("@meta_value15", lName.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key16", "_billing_company");
                                cmd_insert.Parameters.AddWithValue("@meta_value16", company_Name.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key17", "_billing_address_1");
                                cmd_insert.Parameters.AddWithValue("@meta_value17", address1.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key18", "_billing_address_2");
                                cmd_insert.Parameters.AddWithValue("@meta_value18", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key19", "_billing_city");
                                cmd_insert.Parameters.AddWithValue("@meta_value19", city1.Text);

                            // State Country
                            cmd_insert.Parameters.AddWithValue("@meta_key20", "_billing_state");
                                cmd_insert.Parameters.AddWithValue("@meta_value20", state_city);
                            // End State Country

                            cmd_insert.Parameters.AddWithValue("@meta_key21", "_billing_postcode");
                                cmd_insert.Parameters.AddWithValue("@meta_value21", zip_code.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key22", "_billing_country");
                                cmd_insert.Parameters.AddWithValue("@meta_value22", "PH");

                                cmd_insert.Parameters.AddWithValue("@meta_key23", "_billing_email");
                                cmd_insert.Parameters.AddWithValue("@meta_value23", email1.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key24", "_billing_phone");
                                cmd_insert.Parameters.AddWithValue("@meta_value24", phone1.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key25", "_shipping_first_name");
                                cmd_insert.Parameters.AddWithValue("@meta_value25", fName.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key26", "_shipping_last_name");
                                cmd_insert.Parameters.AddWithValue("@meta_value26", lName.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key27", "_shipping_company");
                                cmd_insert.Parameters.AddWithValue("@meta_value27", company_Name.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key28", "_shipping_address_1");
                                cmd_insert.Parameters.AddWithValue("@meta_value28", address1.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key29", "_shipping_address_2");
                                cmd_insert.Parameters.AddWithValue("@meta_value29", "");

                                cmd_insert.Parameters.AddWithValue("@meta_key30", "_shipping_city");
                                cmd_insert.Parameters.AddWithValue("@meta_value30", city1.Text);


                            // State Country
                            cmd_insert.Parameters.AddWithValue("@meta_key31", "_shipping_state");
                                cmd_insert.Parameters.AddWithValue("@meta_value31", state_city);
                            // End State Country

                            cmd_insert.Parameters.AddWithValue("@meta_key32", "_shipping_postcode");
                                cmd_insert.Parameters.AddWithValue("@meta_value32", zip_code.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key33", "_shipping_country");
                                cmd_insert.Parameters.AddWithValue("@meta_value33", "PH");

                                cmd_insert.Parameters.AddWithValue("@meta_key34", "_order_currency");
                                cmd_insert.Parameters.AddWithValue("@meta_value34", "PHP");
                            // Cart Discount
                            cmd_insert.Parameters.AddWithValue("@meta_key35", "_cart_discount");
                                cmd_insert.Parameters.AddWithValue("@meta_value35", "0");

                                cmd_insert.Parameters.AddWithValue("@meta_key36", "_cart_discount_tax");
                                cmd_insert.Parameters.AddWithValue("@meta_value36", "0");
                            // End Cart Discount

                            // Order Shipping
                            cmd_insert.Parameters.AddWithValue("@meta_key37", "_order_shipping");
                                cmd_insert.Parameters.AddWithValue("@meta_value37", "20");
                            // End Order Shipping

                            cmd_insert.Parameters.AddWithValue("@meta_key38", "_order_shipping_tax");
                                cmd_insert.Parameters.AddWithValue("@meta_value38", "0");

                                cmd_insert.Parameters.AddWithValue("@meta_key39", "_order_tax");
                                cmd_insert.Parameters.AddWithValue("@meta_value39", "0");

                            // Order Total
                            cmd_insert.Parameters.AddWithValue("@meta_key40", "_order_total");
                                cmd_insert.Parameters.AddWithValue("@meta_value40", final_result_total);
                            // End Order Total

                            cmd_insert.Parameters.AddWithValue("@meta_key41", "_order_version");
                                cmd_insert.Parameters.AddWithValue("@meta_value41", "3.0.8");

                                cmd_insert.Parameters.AddWithValue("@meta_key42", "_prices_include_tax");
                                cmd_insert.Parameters.AddWithValue("@meta_value42", "yes");

                                cmd_insert.Parameters.AddWithValue("@meta_key43", "_billing_address_index");
                                cmd_insert.Parameters.AddWithValue("@meta_value43", fName.Text + " " + lName.Text + " " + company_Name.Text + " " + address1.Text + " " +
                                    city1.Text + " " + state_city + " " + zip_code.Text + " " + billing_payment.Text + " " + "PH" + " " + email1.Text + " " + phone1.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key44", "_shipping_address_index");
                                cmd_insert.Parameters.AddWithValue("@meta_value44", fName.Text + " " + lName.Text + " " + company_Name.Text + " " + address1.Text + " " +
                                    city1.Text + " " + state_city + " " + zip_code.Text + " " + billing_payment.Text + " " + "PH");

                                cmd_insert.Parameters.AddWithValue("@meta_key45", "_shipping_method");
                                cmd_insert.Parameters.AddWithValue("@meta_value45", "a:1:{i:0;s:12:\"flat_rate: 22\";}");

                                cmd_insert.Parameters.AddWithValue("@meta_key46", "billing_payment");
                                cmd_insert.Parameters.AddWithValue("@meta_value46", billing_payment.Text);

                                cmd_insert.Parameters.AddWithValue("@meta_key47", "_download_permissions_granted");
                                cmd_insert.Parameters.AddWithValue("@meta_value47", "yes");

                                cmd_insert.Parameters.AddWithValue("@meta_key48", "_recorded_sales");
                                cmd_insert.Parameters.AddWithValue("@meta_value48", "yes");

                                cmd_insert.Parameters.AddWithValue("@meta_key49", "_recorded_coupon_usage_counts");
                                cmd_insert.Parameters.AddWithValue("@meta_value49", "yes");

                                cmd_insert.Parameters.AddWithValue("@meta_key50", "_order_stock_reduced");
                                cmd_insert.Parameters.AddWithValue("@meta_value50", "yes");

                                cmd_insert.ExecuteNonQuery();

                            // Insert Chicken Teriyaki
                            if (txtQuantity_1.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price1 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price1 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_1.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_2.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price2 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price2 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_2.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:0;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal');";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result


                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_3.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price3 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price3 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_3.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_4.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price4 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price4 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_4.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_5.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price5 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price5 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_5.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_6.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price6 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price6 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_6.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_7.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";



                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price7 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price7 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_7.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_8.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price8 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price8 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_8.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                            // End Chicken Curry

                            // Insert Chicken Teriyaki
                            if (txtQuantity_9.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price9 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price9 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_9.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_10.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price10 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price10 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_10.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:0;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal');";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result


                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_11.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price11 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price11 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_11.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_12.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price12 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price12 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_12.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_13.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price13 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price13 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_13.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_14.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price14 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price14 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_14.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_15.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";



                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price15 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price15 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_15.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_16.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC CHICKEN CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price16 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price16 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_16.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                            // END CHICKEN CURRY

                            // Insert BEEF Teriyaki
                            if (txtQuantity_17.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price17 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price17 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_17.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_18.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price18 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price18 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_18.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:0;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal');";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result


                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_19.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price19 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price19 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_19.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_20.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price20 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price20 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_20.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_21.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price21 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price21 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_21.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_22.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price22 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price22 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_22.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_23.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";



                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price23 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price23 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_23.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_24.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF TERIYAKI', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price24 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price24 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_24.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                            // END BEEF TERIYAKI

                            // Insert BEEF CURRY
                            if (txtQuantity_25.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price25 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price25 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_25.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_26.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price26 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price26 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_26.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:0;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal');";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result


                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_27.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price27 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price27 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_27.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_28.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price28 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price28 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_28.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:1:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:1:{i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_29.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price29 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price29 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_29.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)');";



                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_30.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price30 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price30 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_30.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:0;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_31.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";



                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price31 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price31 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_31.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            //"(" + last_insert_order_item + ", 'a:2:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:2:{i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_32.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('EFC BEEF CURRY', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";


                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price32 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price32 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_32.Text + "), " +

                                            // ADD ONS
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            //"(" + last_insert_order_item + ", '_ywapo_meta_data', 'a:3:{i:0;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:14:\"Full Rice Meal\";s:5:\"price\";i:0;s:14:\"price_original\";i:0;s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:0;}i:1;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Sauce(20ml)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:1;}i:2;a:8:{s:4:\"name\";s:7:\"ADD ONS\";s:5:\"value\";s:18:\"Extra Rice(1 Cup)\";s:5:\"price\";d:20;s:14:\"price_original\";s:2:\"20\";s:10:\"price_type\";s:5:\"fixed\";s:7:\"type_id\";s:2:\"10\";s:14:\"original_value\";a:3:{i:0;s:14:\"ywapo_value_10\";i:1;s:14:\"ywapo_value_10\";i:2;s:14:\"ywapo_value_10\";}s:14:\"original_index\";i:2;}}'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span>', 'Full Rice Meal'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Sauce (20ml)'), " +
                                            "(" + last_insert_order_item + ", '<span id=\"10\">ADD ONS</span> (<span class=\"woocommerce - Price - amount amount\"><span class=\"woocommerce - Price - currencySymbol\">&#8369;</span>20.00</span>', 'Extra Rice (1 Cup)');";


                                    cmd_insert.ExecuteNonQuery();

                                }

                            // END BEEF CURRY

                            // THE REST PRODUCT
                            // CHICKEN
                            if (txtQuantity_33.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('CHICKEN GRATIN WITH MIX VEGETABLES', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price33 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price33 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_33.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_34.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('ROASTED CHICKEN WITH FUNKY SALAD', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price34 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price34 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_34.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_35.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('CHICKEN WITH CARAMELIZED APPLE WITH POTATO WEDGES', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price35 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price35 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_35.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_36.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('ROSEMARY CHICKEN BREAST WITH SIMPLE PASTA OR MIX', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price36 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price36 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_36.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_37.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('CHICKEN TIKKA WITH PAN GRILL BANANA WITH MIX GREENS', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price37 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price37 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_37.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                            // BEEF
                            if (txtQuantity_38.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('ARROZ ALA CUBANA WITH GARLIC MUSHROOM SPINACH', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price38 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price38 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_38.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_39.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('MINT BEEF WITH SALSA', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price39 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price39 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_39.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_40.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('BALSAMIC BEEF WITH ONION CONFIT SERVED WITH MIX GREENS', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price40 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price40 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_40.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_41.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('MUSTARD BEEF CUTLETS WITH BASIL CREAM SERVED WITH MASHED POTATO', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price41 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price41 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_41.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_42.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('BEEF WITH CAPSICUM PESTO SERVED WITH MASHED KUMARA', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price42 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price42 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_42.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                            // FISH
                            if (txtQuantity_43.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('CHIMICHURRI FISH WITH RICE AND MIX GREENS', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price43 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price43 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_43.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_44.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('GINGER FISH DRIZZLED WITH WASABI SERVED WITH BROWN RICE', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price44 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price44 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_44.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_45.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('DILL PESTO TUNA WITH SIMPLE PASTA', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price45 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price45 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_45.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_46.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('YOGURT SALMON WITH SUNDRIED TOMATO SERVED WITH BROWN RICE', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price46 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price46 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_46.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                            // VEGAN
                            if (txtQuantity_47.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('BARBECUE CAULIFLOWER WITH MASHED POTATO', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price47 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price47 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_47.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_48.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('ROASTED SQUASH AND TOFU WITH PUMPKIN PUREE', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price48 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price48 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_48.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_49.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('CREAMY VEGAN PENNE', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price49 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price49 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_49.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_50.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('TOFU STEAK WITH MUSHROOM', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price50 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price50 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_50.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_51.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('LO MEIN PRIMAVERA PASTA', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price51 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price51 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_51.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                            // PASTA
                            if (txtQuantity_52.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('CHEESY COLD PASTA', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price52 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price52 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_52.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_53.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('PESTO PASTA WITH CHICKEN BREAST', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price53 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price53 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_53.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_54.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('SEAFOOD MARINARA', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price54 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price54 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_54.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                            // SANDWICH
                            if (txtQuantity_55.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('CHICKEN PITA', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price55 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price55 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_55.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_56.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('GRILLED VEGGIE SANDWICH', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price56 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price56 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_56.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }
                                if (txtQuantity_57.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('GRILLED BEEF WITH MOZZARELLA CHEESE', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price57 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price57 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_57.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                            // SALAD
                            if (txtQuantity_58.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('FUNKY FRUIT SALAD', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price58 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price58 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_58.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_59.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('MEDITERESIAN CHICKEN SALAD', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price59 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price59 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_59.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                                if (txtQuantity_60.Text != "")
                                {
                                    cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values('SALAD NICOISE', 'line_item', " + insertedID + "); SELECT LAST_INSERT_ID();";

                                // Get last Inserted ID and Execute it
                                int last_insert_order_item = Convert.ToInt32(cmd_insert.ExecuteScalar());
                                // End Last Inserted ID

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                            // values
                                            "values(" + last_insert_order_item + ", '_line_tax_data', 'a:2:{s:5:\"total\";a:0:{}s:8:\"subtotal\";a:0:{}}'), " +
                                            "(" + last_insert_order_item + ", '_line_total', " + price60 + "), " +
                                            "(" + last_insert_order_item + ", '_line_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal_tax', '0'), " +
                                            "(" + last_insert_order_item + ", '_line_subtotal', " + price60 + "), " +
                                            "(" + last_insert_order_item + ", '_tax_class', ''), " +
                                            "(" + last_insert_order_item + ", '_product_id', '308'), " +
                                            "(" + last_insert_order_item + ", '_variation_id', '0'), " +
                                            "(" + last_insert_order_item + ", '_qty', " + txtQuantity_60.Text + ");";

                                // If you want to call the total and result. Just use this variable --> subtotal_result, final_result



                                cmd_insert.ExecuteNonQuery();

                                }

                                cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_items(order_item_name, order_item_type, order_id) " +
                                        // values
                                        "values(@order_item_name_flat_rate, @order_item_type_flat_rate, @order_id_flat_rate); SELECT LAST_INSERT_ID();";

                                cmd_insert.Parameters.AddWithValue("@order_item_name_flat_rate", "Flat rate");
                                cmd_insert.Parameters.AddWithValue("@order_item_type_flat_rate", "shipping");
                                cmd_insert.Parameters.AddWithValue("@order_id_flat_rate", insertedID);

                            // Get last Inserted ID and Execute it
                            int last_inserted_id_for_flat_rate = Convert.ToInt32(cmd_insert.ExecuteScalar());
                            // End Last Inserted ID

                            cmd_insert.CommandText = "insert into wp_kdskli23jkwoocommerce_order_itemmeta(order_item_id, meta_key, meta_value) " +
                                        // values
                                        "values(@order_item_id_flat_rate, @meta_key_flat_rate, @meta_value_flat_rate), (@order_item_id_flat_rate2, @meta_key_flat_rate2, @meta_value_flat_rate2), (@order_item_id_flat_rate3, @meta_key_flat_rate3, @meta_value_flat_rate3), " +
                                        "(@order_item_id_flat_rate4, @meta_key_flat_rate4, @meta_value_flat_rate4), (@order_item_id_flat_rate5, @meta_key_flat_rate4, @meta_value_flat_rate5);";

                            // If you want to call the total and result. Just use this variable --> subtotal_result, final_result

                            cmd_insert.Parameters.AddWithValue("@order_item_id_flat_rate", last_inserted_id_for_flat_rate);
                                cmd_insert.Parameters.AddWithValue("@meta_key_flat_rate", "method_id");
                                cmd_insert.Parameters.AddWithValue("@meta_value_flat_rate", "flat_rate:22");

                                cmd_insert.Parameters.AddWithValue("@order_item_id_flat_rate2", last_inserted_id_for_flat_rate);
                                cmd_insert.Parameters.AddWithValue("@meta_key_flat_rate2", "cost");
                                cmd_insert.Parameters.AddWithValue("@meta_value_flat_rate2", "20.00");

                                cmd_insert.Parameters.AddWithValue("@order_item_id_flat_rate3", last_inserted_id_for_flat_rate);
                                cmd_insert.Parameters.AddWithValue("@meta_key_flat_rate3", "total_tax");
                                cmd_insert.Parameters.AddWithValue("@meta_value_flat_rate3", "0");

                                cmd_insert.Parameters.AddWithValue("@order_item_id_flat_rate4", last_inserted_id_for_flat_rate);
                                cmd_insert.Parameters.AddWithValue("@meta_key_flat_rate4", "taxes");
                                cmd_insert.Parameters.AddWithValue("@meta_value_flat_rate4", "a:1:{s:5:\"total\";a:0:{}}");

                                cmd_insert.Parameters.AddWithValue("@order_item_id_flat_rate5", last_inserted_id_for_flat_rate);
                                cmd_insert.Parameters.AddWithValue("@meta_key_flat_rate5", "Items");
                                cmd_insert.Parameters.AddWithValue("@meta_value_flat_rate5", "");

                                cmd_insert.ExecuteNonQuery();

                                // UPDATE USER INFORMATION LIKE (BILLING & SHIPPING)
                                cmd_insert.CommandText = "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_fname " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_first_name';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_lname " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_last_name';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_company " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_company';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_address1 " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_address_1';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_city " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_city';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_zipcode " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_postcode';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_payment " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_payment';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_phone " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_phone';" +

                                "UPDATE wp_kdskli23jkusers JOIN wp_kdskli23jkusermeta ON wp_kdskli23jkusers.ID = wp_kdskli23jkusermeta.user_id " +
                                "SET wp_kdskli23jkusermeta.meta_value = @cmd_bill_email " +
                                "WHERE wp_kdskli23jkusers.ID = " + session_user + " AND wp_kdskli23jkusermeta.meta_key = 'billing_email';";

                                cmd_insert.Parameters.AddWithValue("@cmd_bill_fname", fName.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_lname", lName.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_company", company_Name.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_address1", address1.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_city", city1.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_zipcode", zip_code.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_payment", billing_payment.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_phone", phone1.Text);
                                cmd_insert.Parameters.AddWithValue("@cmd_bill_email", email1.Text);

                                cmd_insert.ExecuteNonQuery();

                                cmd_insert.CommandText = "delete from wp_product_cart where customer_name = " + session_user + "; " +
                                "delete from wp_product_cart_add_ons where customer_name = " + session_user + ";";

                                cmd_insert.ExecuteNonQuery();


                                this.RunOnUiThread(() =>
                                {
                                    Window.ClearFlags(WindowManagerFlags.NotTouchable);
                                    progressbar.Visibility = ViewStates.Invisible;
                                    //circleprogressbar.Visibility = ViewStates.Invisible;
                                    progressValue = 0;

                                    Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(this);
                                    except.SetTitle("Your order has been received");
                                    except.SetMessage("Your order number: " + insertedID);
                                    except.SetPositiveButton("Ok", (senderAlert, args) =>
                                    {
                                        Intent myIntent;
                                        myIntent = new Intent(this, typeof(Activity_checkout));
                                        myIntent.PutExtra("result", "Success");
                                        SetResult(Result.Ok, myIntent);

                                        except.Dispose();
                                        Finish();
                                    });
                                    except.Show();

                                });


                                conn.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Looper.Prepare();
                                Android.Support.V7.App.AlertDialog.Builder except = new Android.Support.V7.App.AlertDialog.Builder(this);
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
                        break;
                }
            }
        }

        private ValueAnimator SlideAnimator_Form(int start, int end)
        {

            ValueAnimator animator = ValueAnimator.OfInt(start, end);
            //ValueAnimator animator2 = ValueAnimator.OfInt(start, end);
            //  animator.AddUpdateListener (new ValueAnimator.IAnimatorUpdateListener{
            animator.Update +=
                (object sender, ValueAnimator.AnimatorUpdateEventArgs e) => {
                //  int newValue = (int)
                //e.Animation.AnimatedValue; // Apply this new value to the object being animated.
                //  myObj.SomeIntegerValue = newValue; 
                var value = (int)animator.AnimatedValue;
                    ViewGroup.LayoutParams layoutParams = mLinearLayout_expandable.LayoutParameters;
                    layoutParams.Height = value;
                    mLinearLayout_expandable.LayoutParameters = layoutParams;

                };


            //      });
            return animator;
        }

        private ValueAnimator SlideAnimator_Cart(int start, int end)
        {

            ValueAnimator animator = ValueAnimator.OfInt(start, end);
            //ValueAnimator animator2 = ValueAnimator.OfInt(start, end);
            //  animator.AddUpdateListener (new ValueAnimator.IAnimatorUpdateListener{
            animator.Update +=
                (object sender, ValueAnimator.AnimatorUpdateEventArgs e) => {
                    //  int newValue = (int)
                    //e.Animation.AnimatedValue; // Apply this new value to the object being animated.
                    //  myObj.SomeIntegerValue = newValue; 
                    var value = (int)animator.AnimatedValue;
                    ViewGroup.LayoutParams layoutParams = mLinearLayout_expandable2.LayoutParameters;
                    layoutParams.Height = value;
                    mLinearLayout_expandable2.LayoutParameters = layoutParams;

                };


            //      });
            return animator;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
    }
}