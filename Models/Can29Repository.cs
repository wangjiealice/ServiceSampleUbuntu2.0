using ServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;


namespace ServiceSample.Models
{
    public class Can29Repository : Hub, ICan29Repository
    {
        private int _objectivePosition;
        private int _reflectorPosition;
        private int _brightness;
        private int _rltl;


        public void Init()
        {
            try
            {
                int initResult = Can29.initUsb();//0 is normal
                if (initResult != 0)
                {
                    Console.WriteLine("initUsb failed");
                    return;
                }
                Can29.monitorMik();

                _objectivePosition = Can29.getChangerPosNosepiece();
                _reflectorPosition = Can29.getChangerPosReflector();
                Can29.UartPositionChangeCallback ObjectivePositionChangedCallback = ObjectivePositionChanged;
                Can29.setObjectivePositionChangeCallback(ObjectivePositionChangedCallback);

                Can29.UartPositionChangeCallback ReflectorPositionChangedCallback = ReflectorPositionChanged;
                Can29.setReflectorPositionChangeCallback(ReflectorPositionChangedCallback);

                Can29.UartPositionChangeCallback BrightnessChangeCallback = BrightnessChanged;
                Can29.setBrightnessChangeCallback(BrightnessChangeCallback);

                Can29.UartPositionChangeCallback RLTLChangeCallback = RLTLChanged;
                Can29.setRLTLChangeCallback(RLTLChangeCallback);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private int ObjectivePositionChanged(int i)
        {
            _objectivePosition = i;
            Send("Objective", i);
            Console.WriteLine("ObjectivePosition value is: " + i);
            return 0;
        }

        private int ReflectorPositionChanged(int i)
        {
            _reflectorPosition = i;
            Send("Reflector", i);
            Console.WriteLine("ReflectorPosition value is: " + i);
            return 0;
        }

        private int BrightnessChanged(int i)
        {
            _brightness = i;
            Send("Brightness", i);

            Console.WriteLine("Brightness value is: " + i);
            return 0;
        }

        private int RLTLChanged(int i)
        {
            _rltl = i;
            Send("RLTL", i);

            Console.WriteLine("RLTL value is: " + i);
            return 0;
        }

        public int GetChangerPosReflector()
        {
            return _reflectorPosition;
        }

        public int GetChangerPosObject()
        {
            return _objectivePosition;
        }

        public int GetBrightness()
        {
            return _brightness;
        }

        public int GetRLTL()
        {
            return _rltl;
        }

        //need modify,use callback
        // public int GetChangerPosRLTLSwitch()
        // {
        //     var sRLTLSwitch = Can29.getChangerPosRLTLSwitch();
        //     Console.WriteLine("Current RLTLSwitch value is: " + sRLTLSwitch);
        //     return sRLTLSwitch;
        // }

        public void SetPosServo(Servo data)
        {
            //for example: 0x29,500,2
            //0x29, 1-1000, 2
            Can29.setPosServo(data.CanAddr, data.Position, data.Mode);
        }

        public void setPosChanger(Servo data)
        {
            //for example: 0x1f,1,2 
            //0x1f,2,2 
            Can29.setPosChanger(data.CanAddr, data.Position, data.Mode);
        }

        public void Send(string propertyname, int value)
        {
            Console.WriteLine("BroadcastMessage " + propertyname + " " + value);
            if (Clients != null && Clients.All != null)
            {
                // Call the broadcastMessage method to update clients.
                Clients.All.SendAsync("BroadcastMessage", propertyname, value);
                Console.WriteLine("Really BroadcastMessage");
            }
        }

        public override Task OnConnectedAsync()
        {
            // you can access info using base.Context
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


    }
}
