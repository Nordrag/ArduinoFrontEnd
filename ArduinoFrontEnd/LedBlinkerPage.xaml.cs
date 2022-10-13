namespace ArduinoFrontEnd;

public partial class LedBlinkerPage : ContentPage
{
	public LedBlinkerPage(LedBlinkerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}