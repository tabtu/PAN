using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace SysMonMS
{
    [Activity(Label = "ServerList")]
    public class ServActivity : ListActivity
    {
        private IList<SerMod> serv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            //SetContentView(Resource.Layout.List);
            // Create your application here
            string prefix = Intent.GetStringExtra("servlist");

            string[] smlist = prefix.Split('/');
            serv = new List<SerMod>();
            for (int i = 0; i < smlist.Length - 1; i++)
            {
                SerMod ss = new SerMod(smlist[i]);
                serv.Add(ss);
            }

            ListAdapter = new ServAdapter(this, serv);



            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                Intent result = new Intent();
                result.SetClass(this, typeof(DetailActivity));
                result.PutExtra("serv", serv[e.Position].ToStringExt());
                StartActivity(result);
            };
        }
    }
}