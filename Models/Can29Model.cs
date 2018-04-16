using System;

namespace ServiceSample.Models
{
    public class Servo
    {
        // public int Reflector { get; set; }
        // public int Objective { get; set; }
        // public int RTTL { get; set; }


        public Byte CanAddr{ get; set; }
        public Int16 Position{ get; set; }
        public Int32 Mode{ get; set; }
    }
}
