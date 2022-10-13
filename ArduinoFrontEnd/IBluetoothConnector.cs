using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoFrontEnd
{
    public interface IBluetoothConnector
    {
        List<string> GetConnectedDevices();    
        void Connect(string deviceName);
    }
}
