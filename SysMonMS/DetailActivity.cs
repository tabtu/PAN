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
            //���ñ���  
            settings.DefaultTextEncodingName = "utf-8";
            settings.JavaScriptEnabled = true;
            settings.LoadWithOverviewMode = true;
            //settings.setSupportZoom = true;
            settings.DomStorageEnabled = true;  // 
            //settings.setCacheMode(WebSettings.LOAD_NO_CACHE);
            settings.AllowFileAccess = true;// ������������ļ�����  
            settings.UseWideViewPort = true;
            //settings.setSupportMultipleWindows(true);
            settings.BlockNetworkImage = false;  ///ͬ������ͼƬ  


            //���ñ�����ɫ ͸��  
            //wv.Background = new Color.argb(0, 0, 0, 0);
            //���ñ��ص��ö�����ӿ�  
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