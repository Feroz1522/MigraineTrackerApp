using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;


namespace MigraineTrackerApp.Helpers.Utilities
{
    public class Utilities
    {

        public static void ExceptionHandling(string message)
        {
            try
            {
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static async void ErrorResponseHandling(string message)
        {
            try
            {
                var toast = Toast.Make(message);
                await toast.Show();
            }
            catch (Exception ex)
            {
                Utilities.ExceptionHandling(ex.Message);
            }
        }
    }

}
