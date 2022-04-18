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
using Square.Picasso;

namespace EFCAndroid
{
    public class CustomGridViewAdapter_for_Menu : BaseAdapter
    {
        private Context context;
        private string[] gridViewString;
        //private int[] gridViewImage;
        private string[] gridViewImage;
        public CustomGridViewAdapter_for_Menu(Context context, string[] gridViewstr, string[] gridViewImage /*int[] gridViewImage*/)
        {
            this.context = context;
            gridViewString = gridViewstr;
            this.gridViewImage = gridViewImage;
        }
        public override int Count
        {
            get
            {
                return gridViewString.Length;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;

            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                // view = new View(context);
                view = inflater.Inflate(Resource.Layout.gridview_layout_menu, parent, false);
            }
            else
            {
                view = (View)convertView;
            }
                TextView txtview = view.FindViewById<TextView>(Resource.Id.textViewGrid);
                ImageView imgview = view.FindViewById<ImageView>(Resource.Id.imageViewGrid);

                txtview.Text = gridViewString[position];

                //imgview.SetImageResource(gridViewImage[position]);

                //imgview.SetImageBitmap(GetImageBitmapFromUrl(gridViewImage[position]));

                // the image will load into here... so the performance of android will increase and reduce the freeze and hang.
                Picasso.With(context)
                    .Load((gridViewImage[position]))
                    .Into(imgview);

            return view;
        }
         
           
        }

        //private Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
        //{
        //    Android.Graphics.Bitmap imageBitmap = null;

        //    using (var webClient = new System.Net.WebClient())
        //    {
        //        var imageBytes = webClient.DownloadData(url);
        //        if (imageBytes != null && imageBytes.Length > 0)
        //        {
        //            imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
        //        }


        //    }

        //    return imageBitmap;
        //}
    }
