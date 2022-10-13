using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using APIRequest;
using Newtonsoft.Json;
using System.Text;

namespace ArduinoFrontEnd
{
    public partial class MainViewModel : ObservableObject
    {
        public LedBlinkTest LedTest;

        [ObservableProperty]
        string apiResult = "Waiting...";
      
        [RelayCommand]
        async Task TurnOn()
        {
            var res = await ServerConnection.GetString("ledOn");
            ApiResult = res;
        }

        [RelayCommand]
        async void TurnOff()
        {
            //reverse logic
            var res = await ServerConnection.GetString("ledOff");
            ApiResult = res;
        }

        [RelayCommand]
        async Task ToBlinkerPage()
        {
            //data nav example
            await Shell.Current.GoToAsync(nameof(LedBlinkerPage), new Dictionary<string, object>
            {
                ["LedTest"] = LedTest
            });
        }

        public MainViewModel()
        {                   
            ServerConnection.SetUrl("http://192.168.100.6/");
           
        }
    }

    public class LedBlinkTest
    {
        public int DelayBetweenSequences { get; set; }
        public int BlinkAmout { get; set; }
        public int DelayBetweenBlinks { get; set; }

        public LedBlinkTest(int delayBetweenSequences, int blinkAmout, int delayBetweenBlinks)
        {
            DelayBetweenSequences = delayBetweenSequences;
            BlinkAmout = blinkAmout;
            DelayBetweenBlinks = delayBetweenBlinks;
        }
    }
}
