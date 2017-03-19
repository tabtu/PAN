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
using Android.Webkit;

namespace SysMonMS
{
    [Activity(Label = "Detail")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Detail);
            // Create your application here

            WebView wv = FindViewById<WebView>(Resource.Id.webView_detail);
            wv.LoadUrl("http://tu6.myweb.cs.uwindsor.ca/n.html");
        }
    }
}