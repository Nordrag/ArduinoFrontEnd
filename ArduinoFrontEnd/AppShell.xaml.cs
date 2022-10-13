namespace ArduinoFrontEnd;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LedBlinkerPage), typeof(LedBlinkerPage));
	}
}
