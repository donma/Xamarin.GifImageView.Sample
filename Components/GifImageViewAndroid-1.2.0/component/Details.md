# GifImageView Details

Xamarin.Android ImageView that handles Animated GIF images!

Simply add some xml:

```xml
<com.felipecsl.gifimageview.library.GifImageView
    android:id="@+id/gifImageView"
    android:layout_gravity="center"
    android:scaleType="fitCenter"
    android:layout_width="match_parent"
    android:layout_height="match_parent" />
```

Download a byte array and start your animation:

```csharp
 var bytes = await client.GetByteArrayAsync("http://dogoverflow.com/dRX5G8qK");
gifImageView.SetBytes(bytes);
gifImageView.StartAnimation();
```

Let there be Gif Animations!
![](https://raw.githubusercontent.com/jamesmontemagno/GifImageView-Xamarin.Android/master/sample.gif)