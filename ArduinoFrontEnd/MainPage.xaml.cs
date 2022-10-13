using APIRequest;
namespace ArduinoFrontEnd;

public partial class MainPage : ContentPage
{
	MainViewModel viewModel = new MainViewModel();

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	
}

