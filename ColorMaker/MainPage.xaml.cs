namespace ColorMaker;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void ColorValueChangedS(object sender, ValueChangedEventArgs e)
    {
		var redColor = RedSlider.Value;
		var blueColor = BlueSlider.Value;
		var greenColor = GreenSlider.Value;

		Color color = Color.FromRgb(redColor, greenColor, blueColor);

		SetColor(color);
    }

	private void SetColor(Color color)
    {
		RandomColorB.BackgroundColor = color;
		Container.BackgroundColor = color;
		HexL.Text = color.ToHex();
    }
}


