using System.Diagnostics;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom = false;

	public MainPage()
	{
		InitializeComponent();
	}

	private void ColorValueChangedS(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var redColor = RedSlider.Value;
            var blueColor = BlueSlider.Value;
            var greenColor = GreenSlider.Value;

            Color color = Color.FromRgb(redColor, greenColor, blueColor);

            SetColor(color);
        }
    }

	private void SetColor(Color color)
    {
		Debug.WriteLine(color.ToString());
		RandomColorB.BackgroundColor = color;
		Container.BackgroundColor = color;
		HexL.Text = color.ToHex();
    }

	private void GenerateRandomColorB(object sender, EventArgs e)
    {
		isRandom = true;

		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0, 256),
			random.Next(0, 256),
			random.Next(0, 256)
			);

		SetColor(color);

		RedSlider.Value = color.Red;
		GreenSlider.Value = color.Green;
		BlueSlider.Value = color.Blue;

		isRandom = false;
    }
}


