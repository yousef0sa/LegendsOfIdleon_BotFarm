using LegendsOfIdleon;
using ScriptImage;

public class Project
{

    public static void Main()
    {

        string nameOfLocation = "";


        //handle the Window
        var handle = WindowInfo.handleProcessName("LegendsOfIdleon");
        if (handle == IntPtr.Zero)
        {
            Console.WriteLine("Window Not Found");
            return;
        }

        //set Window position
        WindowInfo.SetWindowPos(handle, 0, 0, 563, 942);

        //Bring Window To Top
        WindowInfo.BringWindowToTop(handle);

        //where am i.
        nameOfLocation = StaticLocations.WhereAmI(handle);

    }
}