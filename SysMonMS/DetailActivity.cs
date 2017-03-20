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

            string prefix = Intent.GetStringExtra("serv");
            SerMod ss = new SerMod(prefix);

            WebView wv = FindViewById<WebView>(Resource.Id.webView_detail);

            WebSettings settings = wv.Settings;
            settings.JavaScriptEnabled = true;
            settings.LoadWithOverviewMode = true;
            //settings.setSupportZoom = true;
            settings.DomStorageEnabled = true;  // 
            //settings.setCacheMode(WebSettings.LOAD_NO_CACHE);
            settings.AllowFileAccess = true;// ������������ļ�����  
            settings.UseWideViewPort = true;
            //settings.setSupportMultipleWindows(true);
            settings.BlockNetworkImage = false;  ///ͬ������ͼƬ  

            wv.LoadUrl("http://tu6.myweb.cs.uwindsor.ca/n.html");
            
        }
    }
}