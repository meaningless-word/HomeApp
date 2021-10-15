using HomeApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace HomeApp.Droid.Renderers
{
	/// <summary>
	/// Отключаем подчеркивание по умолчанию для элемента Entry не платформе Android
	/// </summary>
	[System.Obsolete]
	public class CustomEditorRenderer : EditorRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}