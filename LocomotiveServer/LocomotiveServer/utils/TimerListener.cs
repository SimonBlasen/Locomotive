using System;
using System.Collections.Generic;
using System.Text;

namespace LocomotiveServer.utils
{
    public interface TimerListener
    {
        public void TimerElapsed(float time, int timerCounter);
    }
}
