using APIRequest;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace ArduinoFrontEnd
{
    [QueryProperty(nameof(LedTest), nameof(LedTest))]
    public partial class LedBlinkerViewModel : ObservableObject
    {
        [ObservableProperty]
        DatePicker datePicker;

        [ObservableProperty]
        TimeSpan timePicker;

        [ObservableProperty]
        LedBlinkTest ledTest;

        [ObservableProperty]
        string minutes;       

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
      
        [RelayCommand] 
        async Task SendTimer()
        {
            try
            {
                //sweet mother of god c++, you suck ass
                var sString = $"'year':{DatePicker.Date.Year},'month':{DatePicker.Date.Month},'day':{DatePicker.Date.Day},'hours':{TimePicker.Hours},'minutes':{TimePicker.Minutes},'seconds':{TimePicker.Seconds}";
                await ServerConnection.GetRequest<string>("/dateTime?{" + sString + '}');
            }
            catch (Exception)
            {

               
            }
            
        }

        public LedBlinkerViewModel()
        {
            datePicker = new DatePicker
            {
                MinimumDate = DateTime.Now,
                MaximumDate = new DateTime(2100, 12, 30),
                Date = DateTime.Now,
            };

            timePicker = new TimeSpan(10, 0, 0);           
        }
            
    }
}
