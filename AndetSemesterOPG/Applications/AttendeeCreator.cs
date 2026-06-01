using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace AndetSemesterOPG.Applications
{
    internal class AttendeeCreator //Flyt til festival?
    {
        DispatcherTimer timer;
        AttendeeService attendeeService;
        public AttendeeCreator(DispatcherTimer timer, AttendeeService attendeeService)
        {
            this.timer = timer;
            this.attendeeService = attendeeService;

            this.timer.Tick += new EventHandler(AutoCreateAttendee);
            this.timer.Interval = new TimeSpan(0, 0, 5); // Her sættes intervallet for timeren til 5 sekunder
            this.timer.Start();
        }


        public void AutoCreateAttendee(object sender, EventArgs e)
        {
            attendeeService.CreateAttendee();
        }
    }
}
