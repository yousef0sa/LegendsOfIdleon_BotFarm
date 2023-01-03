using ScriptImage;


namespace LegendsOfIdleon
{
    internal class Selling
    {
        //This method is for selling all the items in the inventory
        public static bool SellAll(IntPtr handle, string ImgPath, double threshold = 0.85)
        {
            //check if the items in the bag
            var items = GameProcess.Window_Checker(handle, ImgPath, threshold);
            if (items)
            {
                while (true)
                {
                    using (var mainWIndow = WindowInfo.Capture(handle))
                    {
                        var img = ImgProcess.MatchTemplate(mainWIndow, ImgPath, threshold);

                        if (img.GetCenterListPoint.Count > 0)
                        {
                            Mouse.Left_Click(handle, img.GetCenterPoint, 0.1);
                        }
                        else
                        {
                            img.Dispose();
                            return true;
                        }
                        img.Dispose();
                    }
                }
            }
            else
                return false;
        }



        //Open the shop.
        public static bool OpenShop(IntPtr handle)
        {
            //Open the shop
            Mouse.Left_Click(handle, StaticLocations.Shop);

            //Wait for the shop to open
            var startTimer = DelayTime.TimerStart();

            //infinite loop.
            while (true)
            {
                //Wait for the shop to open
                if (GameProcess.Window_Checker(handle, @"Images\Process\Shop_List.png", 0.50))
                {
                    if (QuickSell(handle))
                    {
                        Console.WriteLine("Quick Sell Mode is on");
                        break;
                    }
                }
                else if (DelayTime.TimerStop(startTimer) > 10)
                {
                    //Open the shop try again
                    Mouse.Left_Click(handle, StaticLocations.Shop);

                    //reset the timer
                    startTimer = DelayTime.TimerStart();

                    Console.WriteLine("Shop is not open");
                    Console.WriteLine("Try again");
                }
            }
            return true;
        }

        //Check if the shop is in quick sell mode.
        private static bool QuickSell(IntPtr handle)
        {
            //Check if the shop is in quick sell mode.
            if (GameProcess.Window_Checker(handle, @"Images\Process\Quick_Sell.png", 0.90))
            {
                return true;
            }
            else
            {
                //Click the quick sell button.
                Mouse.Left_Click(handle, StaticLocations.Quick_Sell_Button);
                DelayTime.Delay(0.5);
                return true;
            }
        }
    }
}

