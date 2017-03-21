using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using Android.Widget;

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
            //设置编码  
            settings.DefaultTextEncodingName = "utf-8";
            settings.JavaScriptEnabled = true;
            settings.LoadWithOverviewMode = true;
            //settings.setSupportZoom = true;
            settings.DomStorageEnabled = true;  // 
            //settings.setCacheMode(WebSettings.LOAD_NO_CACHE);
            settings.AllowFileAccess = true;// 设置允许访问文件数据  
            settings.UseWideViewPort = true;
            //settings.setSupportMultipleWindows(true);
            settings.BlockNetworkImage = false;  ///同步请求图片  


            //设置背景颜色 透明  
            //wv.Background = new Color.argb(0, 0, 0, 0);
            //设置本地调用对象及其接口  
            wv.AddJavascriptInterface(this, "callByJs");

            wv.LoadUrl("file:///android_asset/Chat.html");
            //wv.LoadUrl("javascript:alert('hello js')");
        }

        
        public void testtoast(string content)
        {
            Toast.MakeText(this, "receive data: " + content, new ToastLength()).Show();
        }
    }
}