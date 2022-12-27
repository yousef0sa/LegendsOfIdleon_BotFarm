using ScriptImage;


namespace LegendsOfIdleon
{
    internal class Selling
    {
        //This method is for selling all the items in the inventory
        public static void SellAll(IntPtr handle, string ImgPath)
        {
            //Drag and Drop.
        }

        //Open the shop.
        public static bool OpenShop(IntPtr handle)
        {
            //Open the shop
            Mouse.Left_Click(handle, StaticLocations.Shop);

            //infinite loop.
            while (true)
            {
                //Wait for the shop to open
                if (GameProcess.Window_Checker(handle,
                    @"Images\Process\Shop_List.png",
                    "Shop List", 0.50))
                {
                    break;
                }
            }
            return true;
        }
    }
}
