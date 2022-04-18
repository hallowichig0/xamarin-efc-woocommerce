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

namespace EFCAndroid
{
    class MyListViewAdapter : BaseAdapter<Person>
    {
        public List<Person> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<Person> items)
        {
            mItems = items;
            mContext = context;
        }
        public override int Count
        {
            get { return mItems.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Person this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView txtOrder = row.FindViewById<TextView>(Resource.Id.txtOrder);
            TextView txtDate = row.FindViewById<TextView>(Resource.Id.txtDate);
            TextView txtStatus = row.FindViewById<TextView>(Resource.Id.txtStatus);
            TextView txtAction = row.FindViewById<TextView>(Resource.Id.txtAction);

            txtOrder.Text = mItems[position].Order;
            txtDate.Text = mItems[position].Date;
            txtStatus.Text = mItems[position].Status;
            txtAction.Text = mItems[position].Actions;

            return row;
        }

    }
}