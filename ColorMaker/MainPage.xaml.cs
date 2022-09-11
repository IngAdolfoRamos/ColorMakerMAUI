using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	bool isRandom = false;
	string hexValue; 

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
		hexValue = color.ToHex();
		HexL.Text = hexValue;
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

	private async void CopyColorIB(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);

		var toast = Toast.Make("Color copiado !",
			CommunityToolkit.Maui.Core.ToastDuration.Short, 12);

		await toast.Show();
    }
}


