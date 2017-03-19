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

namespace SysMonMS
{
    [Activity(Label = "ListActivity")]
    public class ServActivity : ListActivity
    {
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.List);
            listView = FindViewById<ListView>(Resource.Id.lv_list);


        }
    }
}