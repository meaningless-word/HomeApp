using HomeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
 
 
[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace HomeApp.Droid.Renderers
{
	/// <summary>
	/// Отключаем подчеркивание по умолчанию для элемента Entry не платформе Android
	/// </summary>
	[System.Obsolete]
	public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}