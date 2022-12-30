using LegendsOfIdleon;
using ScriptImage;

public class Project
{

    public static void Main()
    {
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
        var nameOfLocation = StaticLocations.WhereAmI(handle);
        if (nameOfLocation == "unknown")
            return;
        else
            Console.WriteLine("I am in " + nameOfLocation);

        //check bag space
        var bag_size = GameProcess.BagSpace(handle, @"Images\Items\Gold_Ore_Bag.png", 0.80, ItemSpace: 10);
        if (bag_size)
        {
            Console.WriteLine("the Bag is full");

            //go to G1 to sell the items.
            if (TheRoad.MoveFromTo(handle, nameOfLocation, "G1"))
                Console.WriteLine("I am in G1 now");

            if(Selling.OpenShop(handle))

                if(Selling.SellAll(handle, @"Images\Items\Gold_Ore_Bag.png", 0.80))
                    Console.WriteLine("I sold all the items");
                else
                    Console.WriteLine("I can't sell the items");
            else
            Console.WriteLine("I can't open the shop");
        }

        else
        {
            Console.WriteLine("the Bag is not full");

            //go to M2 to farm.
            TheRoad.MoveFromTo(handle, nameOfLocation, "M2");
        }
        Console.WriteLine(Mouse.GetCursorPosition(handle));
    }
}
