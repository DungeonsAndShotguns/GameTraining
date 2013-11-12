using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breakout.Entities
{
    public class Ball : Entity
    {
        float Speed { get; set; }
        bool InMovment { get; set; }

        public void ToggleMovment()
        {
            if (InMovment == true)
            {
                InMovment = false;
            }
            else
            {
                InMovment = true;
            }
        }
    }
}
