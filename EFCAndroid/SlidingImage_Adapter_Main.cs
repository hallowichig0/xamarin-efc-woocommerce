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
using Android.Util;
using Java.Lang;
using Android.Support.V4.View;
using Square.Picasso;

namespace EFCAndroid
{
    public class SlidingImage_Adapter_Main : PagerAdapter
    {
        private string[] gridViewImage;
        private LayoutInflater layoutInflater;
        private Context context;



        public SlidingImage_Adapter_Main(Context context, string[] gridViewImage)
        {
            this.context = context;
            this.gridViewImage = gridViewImage;
            //this.gridViewImage = gridViewImage;
            //inflater = LayoutInflater.From(context);
        }


        public override int Count
        {
            get
            {
                return gridViewImage.Length;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object objects)
        {
            return view == objects;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {

            //var imageView = new ImageView(context);
            //imageView.SetImageResource(gridViewImage[position]);
            layoutInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View view = layoutInflater.Inflate(Resource.Layout.custom_layour_main_slider, null);

            ImageView imageview = view.FindViewById<ImageView>(Resource.Id.imageView);
            Picasso.With(context)
                   .Load((gridViewImage[position]))
                   .Into(imageview);

            ViewPager vp = (ViewPager)container;
            vp.AddView(view, 0);




            //var viewPager = container.JavaCast<ViewPager>();

            //viewPager.AddView(imageView);
            //return imageView;
            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objects)
        {
            ViewPager vp = (ViewPager)container;
            View view = (View)objects;
            vp.RemoveView(view);
            //var viewPager = container.JavaCast<ViewPager>();
            //viewPager.RemoveView(objects as View);
        }

        //public override void RestoreState(IParcelable state, ClassLoader loader)
        //{

        //}

        //public override IParcelable SaveState()
        //{
        //    return null;
        //}


    }
}