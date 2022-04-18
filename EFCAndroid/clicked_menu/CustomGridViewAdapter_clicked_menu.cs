using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Square.Picasso;

namespace EFCAndroid.clicked_menu
{
    public class CustomGridViewAdapter_clicked_menu : BaseAdapter
    {
        private Context context;

        private string[] gridViewImage;

        public CustomGridViewAdapter_clicked_menu(Context context, string[] gridViewImage /*int[] gridViewImage*/)
        {
            this.context = context;
            this.gridViewImage = gridViewImage;
        }
        public override int Count
        {
            get
            {
                return gridViewImage.Length;
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

            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            if (convertView == null)
            {
                view = new View(context);
                view = inflater.Inflate(Resource.Layout.gridview_layout_clicked_menu, null);

                ImageView imgview = view.FindViewById<ImageView>(Resource.Id.imageViewGrid);

                //imgview.SetImageResource(gridViewImage[position]);
                // imgview.SetImageBitmap(GetImageBitmapFromUrl(gridViewImage[position]));
                Picasso.With(context)
       .Load((gridViewImage[position]))
       .Into(imgview);
            }
            else
            {
                //DownloadAsyncBitmap(GetImageBitmapFromUrl(gridViewImage[position], img));
                view = (View)convertView;

            }
            return view;
        }


    }
}