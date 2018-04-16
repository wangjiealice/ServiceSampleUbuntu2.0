using System.Runtime.InteropServices;
using System;

namespace ServiceSample
{
    public static class Can29
    {
        public delegate int UartPositionChangeCallback(int i);

        [DllImport("libcan29.so")]
        public static extern int initUsb();

        [DllImport("libcan29.so")]
        public static extern int finitUsb();

        [DllImport("libcan29.so")]
        public static extern void monitorMik();

        [DllImport("libcan29.so")]
        public static extern UInt16 getChangerPosReflector();

        [DllImport("libcan29.so")]
        public static extern UInt16 getChangerPosNosepiece();

        [DllImport("libcan29.so")]
        public static extern UInt16 getChangerPosRLTLSwitch();

        [DllImport("libcan29.so")]
        //oid setPosServo(uint8 canAddr, int16 position, int32 mode)
        public static extern void setPosServo(Byte canAddr, Int16 position, Int32 mode);

        [DllImport("libcan29.so")]//TO DO
        //void setPosChanger(uint8 canAddr, int16 position, int32 mode);
        public static extern void setPosChanger(Byte canAddr, Int16 position, Int32 mode);

        [DllImport("libcan29.so")]
        public static extern void setObjectivePositionChangeCallback(UartPositionChangeCallback pointer);

        [DllImport("libcan29.so")]
        public static extern void setReflectorPositionChangeCallback(UartPositionChangeCallback pointer);

        [DllImport("libcan29.so")]//TO DO
        public static extern void setBrightnessChangeCallback(UartPositionChangeCallback pointer);

        [DllImport("libcan29.so")]//TO DO
        public static extern void setRLTLChangeCallback(UartPositionChangeCallback pointer);
    }
}