using ScriptImage;

namespace LegendsOfIdleon
{
    //This class is for moving the player to the specific location
    internal class TheRoad
    {
        //This method is for moving the player to the specific location
        private static void MoveToNextMap(IntPtr handle, (int x, int y) Location)
        {
            DelayTime.Delay(0.5);
            //Move to the location
            Mouse.Left_Click(handle, Location, 0.1);

            while (true)
            {
                // Wait for the loading screen to appear
                //if return false, try again.
                if (!GameProcess.Lodaing(handle))
                {
                    //Move to the location again
                    Mouse.Left_Click(handle, Location, 0.1);
                }
                else
                {
                    break;
                }
            }
            // Wait for the loading screen to disappear
            DelayTime.Delay(0.5);
        }

        //method for move the player to the specific location step by step
        public static bool MoveFromTo(IntPtr handle, string From, string To)
        {
            if (From == To)
            {
                return true;
            }
            else if (From == "G1" && To == "M2")
            {
                var G1_Door = GameProcess.Door_Left(handle);
                //Step 1 move from G1 to M1
                if (G1_Door != (0, 0))
                {
                    MoveToNextMap(handle, G1_Door);
                }
                else
                {
                    MoveToNextMap(handle, StaticLocations.GetDoor(From, "M1"));
                }

                //Step 2 move from M1 to M2
                MoveToNextMap(handle, StaticLocations.GetDoor("M1", To));
                return true;
            }
            else if (From == "M2" && To == "G1")
            {
                //step 1 move from M2 to M1
                MoveToNextMap(handle, StaticLocations.GetDoor(From, "M1"));

                //step 2 move from M1 to G1
                MoveToNextMap(handle, StaticLocations.GetDoor("M1", To));
                return true;
            }
            else
            {
                MoveToNextMap(handle, StaticLocations.GetDoor(From, To));
                return true;
            }
        }
    }
}
