using ScriptImage;

namespace LegendsOfIdleon
{
    //restore static locations.
    public class StaticLocations
    {
        //Info List of Locations
        private static List<(string name, (int x, int y) Lift, (int x, int y) Right)> L1 = new List<(string, (int, int), (int, int))>();

        //static things to do with the game.
        public readonly static (int x, int y) Map_Button = (764, 524);
        public readonly static (int x, int y) Bag_Button = (570, 527);
        public readonly static (int x, int y) Quick_Sell_Button = (300, 473);

        public readonly static (int x, int y) Shop = (492, 411);
        public readonly static (int x, int y) Sell_Area = (516, 138);
        public readonly static (int x, int y) Gold_Static = (432, 378);

        //static door locations
        public readonly static (int x, int y) G1_To_M1 = (23, 303);
        public readonly static (int x, int y) M1_To_G1 = (913, 418);
        public readonly static (int x, int y) M1_To_M2 = (29, 417);
        public readonly static (int x, int y) M2_To_M1 = (912, 58);


        //return the location of the door by using the name of the location from the map.
        public static (int x, int y) GetDoor(string From, string To)
        {
            switch (From + To)
            {
                case "G1" + "M1":
                    return G1_To_M1;
                case "M1" + "G1":
                    return M1_To_G1;
                case "M1" + "M2":
                    return M1_To_M2;
                case "M2" + "M1":
                    return M2_To_M1;
                default:
                    return (0, 0);
            }
        }

        //method to return string where am i.
        public static string WhereAmI(IntPtr handle)
        {
            //open the map.
            Mouse.Left_Click(handle, Map_Button);
            DelayTime.Delay(0.8);

            if (GameProcess.Map_checker(handle, @"Images\Lications\Blunder_Hills.png"))
            {
                DelayTime.Delay(0.5);
                Mouse.Left_Click(handle, Map_Button);
                return "G1";
            }
            else if (GameProcess.Map_checker(handle, @"Images\Lications\Tunnels_Entrance.png"))
            {
                DelayTime.Delay(0.5);
                Mouse.Left_Click(handle, Map_Button);
                return "M1";
            }
            else if (GameProcess.Map_checker(handle, @"Images\Lications\Freefall_Caverns.png"))
            {
                DelayTime.Delay(0.5);
                Mouse.Left_Click(handle, Map_Button);
                return "M2";
            }
            else
            {
                DelayTime.Delay(0.5);
                Mouse.Left_Click(handle, Map_Button);
                return "Unknown";
            }
        }
    }
}
