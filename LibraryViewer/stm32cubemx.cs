using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace LibraryViewer
{
    internal class STM32CubeMX_Parser
    {
        string _filename;
        public struct MCUPrams
        {
            public string name;
            public string CPN;
            public string Package;
            public int pinsCount;
        }

        public struct PinsParams
        {
            public string number;
            public string mode;
            public string signal;
            public string name;
            public string label;
        }


        public MCUPrams MCU;
        public List<PinsParams> Pins = new List<PinsParams>();

        public STM32CubeMX_Parser(string filename)
        {
            _filename = filename;
            //Get MCU Data
            foreach (string line in File.ReadLines(filename))
            {
                int startIndex = line.IndexOf('=');
               
                if (startIndex == -1) continue;

                string type = line.Substring(0, startIndex);
                string value = line.Substring(startIndex + 1);

                switch (type)
                {
                    case "Mcu.Name": MCU.name = value; break;
                    case "Mcu.CPN": MCU.CPN = value; break;
                    case "Mcu.Package": MCU.Package = value; break;
                    case "Mcu.PinsNb": MCU.pinsCount = int.Parse(value); break;
                }
            }
            
            //Get Pins Name
            foreach (string line in File.ReadLines(filename))
            {
                int startIndex = line.IndexOf('=');

                if (startIndex == -1) continue;

                string type = line.Substring(0, startIndex);
                string value = line.Substring(startIndex + 1);

                if(type.StartsWith("Mcu.Pin") && type != "Mcu.PinsNb")
                {
                    string pinNum = type.Substring(7);
                    PinsParams pinData = GetPinsParams(pinNum);
                    Pins.Add(pinData);
                }


            }



        }

        private PinsParams GetPinsParams(string num)
        {
            PinsParams pin = new PinsParams();
            pin.number = num;
            pin.name = "";
            Regex rgName = new Regex(@"^P[A-Z]\d+");
            Regex rgMode = new Regex(@"P[A-Za-z][0-9]+.*Mode");
            Regex rgSignal = new Regex(@"P[A-Za-z][0-9]+.*Signal");


            foreach (string line in File.ReadLines(_filename))
            {
                int startIndex = line.IndexOf('=');

                if (startIndex == -1) continue;

                string type = line.Substring(0, startIndex);
                string value = line.Substring(startIndex + 1);


                if (type == "Mcu.Pin" + num)pin.name = rgName.Match(value).Value;
                if (Regex.IsMatch(type,"^" + pin.name + ".*Mode")) pin.mode = value;
                if (Regex.IsMatch(type,"^" + pin.name + ".*Signal")) pin.signal = value;
                if (Regex.IsMatch(type, "^" + pin.name + ".*GPIO_Label")) pin.label = value;


            }

            return pin;

        }
    }
}
