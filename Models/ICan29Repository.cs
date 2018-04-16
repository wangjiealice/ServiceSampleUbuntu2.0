using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSample.Models
{
    public interface ICan29Repository
    {
        void Init();

         int GetChangerPosReflector();

         int GetChangerPosObject();

         int GetBrightness();

         int GetRLTL();

        // int GetChangerPosRLTLSwitch()   

         void SetPosServo(Servo data);

         void setPosChanger(Servo data);


    }
}