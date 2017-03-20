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
using Android.Graphics;

namespace SysMonMS
{
    class ServAdapter : BaseAdapter
    {

        LayoutInflater mInflater;

        private Context self;

        private IList<SerMod> servs;

        public ServAdapter(Context s, IList<SerMod> l)
        {
            mInflater = LayoutInflater.From(s);
            self = s;
            servs = l;
        }

        public override int Count
        {
            get
            {
                return servs.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // A ViewHolder keeps references to children views to avoid unneccessary calls
            // to findViewById() on each row.
            ViewHolder holder;

            // When convertView is not null, we can reuse it directly, there is no need
            // to reinflate it. We only inflate a new View when the convertView supplied
            // by ListView is null.
            if (convertView == null)
            {
                convertView = mInflater.Inflate(Resource.Layout.adapter, null);

                // Creates a ViewHolder and store references to the two children views
                // we want to bind data to.
                holder = new ViewHolder();
                holder.tv = convertView.FindViewById<TextView>(Resource.Id.tv_title);

                convertView.Tag = holder;
            }
            else
            {
                // Get the ViewHolder back to get fast access to the TextView
                // and the ImageView.
                holder = (ViewHolder)convertView.Tag;
            }

            // Bind the data efficiently with the holder.
            holder.tv.Text = (servs[position].CPUload_id.ToString());


            if (position == 0)
            {
                holder.tv.Text = "Master";
            }
            else
            {
                holder.tv.Text = "Branch_" + position;
            }

            return convertView;
        }

        class ViewHolder : Java.Lang.Object
        {
            public TextView tv { get; set; }
        }
    }
}