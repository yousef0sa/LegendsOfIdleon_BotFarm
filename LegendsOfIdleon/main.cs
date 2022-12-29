using LegendsOfIdleon;
using OpenCvSharp;
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

        //where am i?
        nameOfLocation = StaticLocations.WhereAmI(handle);
        Console.WriteLine("I'm in " + nameOfLocation + " Map.");

        // check bag space
        var bag_size =  GameProcess.BagSpace(handle, @"Images\Items\Gold_Ore_Bag.png", 0.90, ItemSpace: 10);
        if (bag_size)
            Console.WriteLine("the Bag is full");
        else
            Console.WriteLine("the Bag is not full");


    }
}
