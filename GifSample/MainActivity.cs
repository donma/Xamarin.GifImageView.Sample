using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.IO;

namespace GifSample
{
    [Activity(Label = "GifSample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, Felipecsl.GifImageViewLibrary.GifImageView.IOnFrameAvailableListener
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var gifViewer = FindViewById<Felipecsl.GifImageViewLibrary.GifImageView>(Resource.Id.gifImageView);

            // Read From Assets

            AssetManager assets = this.Assets;
            using (var streamReader = new StreamReader(assets.Open("sample.gif")))
            {
                var bytes = default(byte[]);
                using (var memstream = new MemoryStream())
                {
                    streamReader.BaseStream.CopyTo(memstream);
                    bytes = memstream.ToArray();

                    gifViewer.SetBytes(bytes);
                    gifViewer.StartAnimation();
                }

            }


            //Read From Drawable
            var stream = Resources.OpenRawResource(Resource.Drawable.sample2);
            using (var streamReader = new StreamReader(stream))
            {
                var bytes = default(byte[]);
                using (var memstream = new MemoryStream())
                {
                    streamReader.BaseStream.CopyTo(memstream);
                    bytes = memstream.ToArray();

                    gifViewer.SetBytes(bytes);
                    gifViewer.StartAnimation();
                }

            }
        }

        public Bitmap OnFrameAvailable(Bitmap bitmap)
        {
            return bitmap;
        }
    }
}

