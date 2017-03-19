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
using Java.Lang;

namespace SysMonMS
{
    class ServAdapter : BaseAdapter
    {
        private List<SerMod> servs;

        private Context context;
        
        public ServAdapter(Context context, List<SerMod> servs)
        {
            this.context = context;
            this.servs = servs;
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

        private class ViewHolder
        {
            public TextView tv_title;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // °ó¶¨¿Ø¼þID
            ViewHolder holder;
            if (convertView == null)
            {
                holder = new ViewHolder();
                LayoutInflater inflater = LayoutInflater.From(context);
                convertView = inflater.Inflate(Resource.Layout.adapter, null);
                holder.tv_title = (TextView)convertView.FindViewById(Resource.Id.tv_title);
                //convertView.SetTag(holder);
            }
            else
            {
                //holder = (ViewHolder)convertView.GetTag(0);
            }

            //holder.tv_title.SetText(servs[position].cpu_num);

	    	return convertView;
        }
    }
}