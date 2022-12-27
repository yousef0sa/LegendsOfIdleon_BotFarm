using ScriptImage;

namespace LegendsOfIdleon
{
    //This class is for moving the player to the specific location
    internal class TheRoad
    {
        //This method is for moving the player to the specific location
        public static void MoveToNextMap(IntPtr handle, (int x, int y) Location)
        {
            //Move to the location
            Mouse.Left_Click(handle, Location);

            // Wait for the loading screen to appear
            GameProcess.Lodaing(handle);

            // Wait for the loading screen to disappear
            DelayTime.Delay(0.5);
        }
    }
}
