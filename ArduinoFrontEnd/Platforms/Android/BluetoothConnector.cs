using ArduinoFrontEnd.Platforms.Android;
using Android.Bluetooth;
using Java.Util;


[assembly:Dependency(typeof(BluetoothConnector))]
namespace ArduinoFrontEnd.Platforms.Android
{
    public class BluetoothConnector : IBluetoothConnector
    {
        private const string SspUdid = "00001101-0000-1000-8000-00805f9b34fb";
        private BluetoothAdapter adapter;
        private BluetoothManager manager;

        public void Connect(string deviceName)
        {
            
            var device = adapter.BondedDevices.FirstOrDefault(d => d.Name == deviceName);
            var socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString(SspUdid));
            socket.Connect();
            var buffer = new byte[] { (int)'1' };
            // Write data to the device to trigger LED
            socket.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            
        }

        public List<string> GetConnectedDevices()
        {
            adapter = BluetoothAdapter.DefaultAdapter;     
            if (adapter == null)
                throw new Exception("No Bluetooth adapter found.");
            if (adapter.IsEnabled)
            {
                if (adapter.BondedDevices.Count > 0)
                {
                    return adapter.BondedDevices.Select(d => d.Name).ToList();
                }
            }
            else
            {
                Console.Write("Bluetooth is not enabled on device");
            }
            return new List<string>();
        }
    }
}
