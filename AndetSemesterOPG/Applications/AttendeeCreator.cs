using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace AndetSemesterOPG.Applications
{
    internal class AttendeeCreator
    {
        DispatcherTimer timer;
        AttendeeService attendeeService;
        public AttendeeCreator(DispatcherTimer timer, AttendeeService attendeeService)
        {
            this.timer = timer;
            this.attendeeService = attendeeService;

            timer.Tick += new EventHandler(AutoCreateAttendee);
            timer.Interval = new TimeSpan(0, 0, 5); // Her sættes intervallet for timeren til 5 sekunder
            timer.Start();
        }


        public void AutoCreateAttendee(object sender, EventArgs e)
        {
            attendeeService.CreateAttendee();
        }
    }
}
