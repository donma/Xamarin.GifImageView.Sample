# Getting Started with GifImageView

Xamarin.Android ImageView that handles Animated GIF images!

This is a derivative of Felipe Lima's GifImageView: https://github.com/felipecsl/GifImageView/ under MIT

### Usage

Install NuGet Package into Android project: https://www.nuget.org/packages/Refractored.GifImageView

**In your Android XML:**

```xml
<com.felipecsl.gifimageview.library.GifImageView
    android:id="@+id/gifImageView"
    android:layout_gravity="center"
    android:scaleType="fitCenter"
    android:layout_width="match_parent"
    android:layout_height="match_parent" />
```

**In your Activity class:**

Add using statement:
```csharp
using Felipecsl.GifImageViewLibrary;
```
Find views and load animation:

```csharp
GifImageView gifImageView;     

protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);

    // Set our view from the "main" layout resource
    SetContentView(Resource.Layout.Main);

    gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
    var buttonLoad = FindViewById<Button>(Resource.Id.loadImage);

    buttonLoad.Click += async (sender, e) => 
        {
            try
            {
                ActionBar.Title = "Error downloading";
                using(var client = new HttpClient())
                {
                    var bytes = await client.GetByteArrayAsync("http://dogoverflow.com/dRX5G8qK");
                    gifImageView.SetBytes(bytes);
                    gifImageView.StartAnimation();
                }
            }
            catch(Exception ex)
            {
                ActionBar.Title = "Error downloading";
            }
        };
}

protected override void OnStop()
{
    base.OnStop();
    gifImageView.StopAnimation();
}

protected override void OnStart()
{
    base.OnStart();
    gifImageView.StartAnimation();
}
```

If you need to post-process the GIF frames, you can do that via ``ISetOnFrameAvailableListener``.


```csharp
public class MainActivity : Activity, GifImageView.IOnFrameAvailableListener
{
    protected override async void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.Main);

        gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
        gifImageView.OnFrameAvailableListener = this;
    }   

    public Bitmap OnFrameAvailable(Bitmap bitmap)
    {
        if (shouldBlur)
            return blur.BlurImage(bitmap);

        return bitmap;
    }
}   
```

You can see an example of that in the sample application.