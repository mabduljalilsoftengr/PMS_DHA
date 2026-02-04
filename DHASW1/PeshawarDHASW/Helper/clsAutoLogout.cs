using System;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Helper
{
    class clsAutoLogout
    {
        // This is the maximum number of minutes the application can remain 
        // without activity before the AutoLogout routine will close the 
        // application. The field is public so that it can be changed.
        public static int maxNumberMinutesIdle { get; set; } = 1;

        // Keeps the timestamp for the last time activity was detected.
        private static System.DateTime dtLastActivity { get; set; } = DateTime.Now;

        // This is the method that will serve as the background thread.
        private static void CheckForExceededIdleTime()
        {
            // Sets up an infinite loop
            while (true)
            {
                // If the last time activity occured + the Maximum Allowable 
                // Idle time is less than the current time, then the system 
                // should be shut down
                if (dtLastActivity.AddMinutes
                              (maxNumberMinutesIdle) < DateTime.Now)
                {
                    Console.WriteLine("Inactivity Exceeded");

                    // Exits the program, not elegant you should modify this
                    // so it disposes all open windows, etc.
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    Console.WriteLine("Not AutoLogged Out");
                }
                // Probably don't need this running every second
                // Perhaps every minute would be better in a production system
                Thread.Sleep(1000);
            }
        }
        // Static Constructor. Used to launch the background thread
        static clsAutoLogout()
        {
            ThreadStart ts = new ThreadStart(CheckForExceededIdleTime);
            Thread t = new Thread(ts);

            // Ensures background thread is killed when 
            // last foreground terminates
            t.IsBackground = true;

            // Don't want this thread taking up too much CPU            
            t.Priority = ThreadPriority.BelowNormal;
            t.Start();
        }
        // Private Constructor Prevents Instantiation
        private clsAutoLogout()
        {
        }
        // This is the method called to watch a form
        public static void WatchControl(RadControl c)
        {
            //  If the control is a textbox then we want to watch 
            // for KeyStrokes since these signify activity.
            if (c is RadTextBox)
            {
                RadTextBox t = (RadTextBox)c;
                // Register an event listener for the keypress event
                t.KeyPress += new System.Windows.Forms.
                 KeyPressEventHandler(MethodWhichResetsTheDateofLastActivity);

                // Register an event listener for the MouseMove event
                c.MouseMove += new System.Windows.Forms.MouseEventHandler
                                  (MethodWhichResetsTheDateofLastActivity);
            }
            // If the control is not a TextBox then the we want to watch 
            // for MouseMovement since this signifies activity
            else
            {
                c.MouseMove += new System.Windows.Forms.MouseEventHandler
                                  (MethodWhichResetsTheDateofLastActivity);
            }
            // Checks to see if the control is a container for other controls
            // if so then we need to watch of all the constituent controls/
            if (c.Controls.Count > 0)
            {
                foreach (RadControl cx in c.Controls)
                {
                    // Recursive call
                    WatchControl(cx);
                }
            }
        }  // End of Watch Control Method
        // This method resets the datetime stamp which indicates when the last 
        // activity occured. Overloaded to support KeyPressEventArgs parameter
        private static void MethodWhichResetsTheDateofLastActivity(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Console.WriteLine("Keyboard Activity Detected");
            dtLastActivity = DateTime.Now;
        }
        // This method resets the datetime stamp which indicates when the last
        // activity occured. Overloaded to support MouseEventArgs parameter
        private static void MethodWhichResetsTheDateofLastActivity(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine("Mouse Activity Detected");
            dtLastActivity = DateTime.Now;
        }
    }
}
