using OpenCvSharp;
using ScriptImage;

namespace LegendsOfIdleon
{

    internal class GameProcess
    {
        //Calling this method will start an infinite loop and end if the loading screen is shown
        public static void Lodaing(IntPtr handle)
        {
            while (true)
            {
                using (var mainWIndow = WindowInfo.Capture(handle))
                {
                    var img = ImgProcess.MatchTemplateInRange(mainWIndow,
                        @"Images\Process\Loading.png",
                        (125, 492), (170, 557), 0.99);

                    if (img.GetListRects.Count == 0)
                    {
                        Console.WriteLine("Loading...");
                        img.Dispose();
                        break;
                    }
                    img.Dispose();
                }
            }
        }

        //return true if the Inventory is Full. ((6, 422), (167, 495) 0.60);
        public static bool FullInventoryText(IntPtr handle)
        {
            using (var mainWIndow = WindowInfo.Capture(handle))
            {
                var img = ImgProcess.MatchTemplateInRange(mainWIndow,
                    @"Images\Status\Full_Inventory.png",
                    (3, 422), (167, 495), 0.60);

                if (img.GetListRects.Count > 0)
                {
                    Console.WriteLine("Inventory is full");
                    img.Dispose();
                    return true;
                }
                img.Dispose();
            }
            return false;
        }

        //check if door is right. ((799, 35), (932, 557), 0.56, 5, ColorConversionCodes.BGRA2BGR, ColorConversionCodes.BGRA2BGR);
        public static bool Door_Right(IntPtr handle)
        {
            using (var mainWIndow = WindowInfo.Capture(handle))
            {
                var img = ImgProcess.MatchTemplateInRange(mainWIndow,
                    @"Images\Doors\Door_Right.png",
                    (799, 35), (932, 557), 0.56, 5, ColorConversionCodes.BGRA2BGR, ColorConversionCodes.BGRA2BGR);

                if (img.GetListRects.Count > 0)
                {
                    Console.WriteLine("the Door is Right");
                    img.Dispose();
                    return true;
                }
                img.Dispose();
            }
            return false;
        }

        //check if this map is correct map
        public static bool Map_checker(IntPtr handle, string ImgMap)
        {
            using (var mainWIndow = WindowInfo.Capture(handle))
            {
                var img = ImgProcess.MatchTemplate(mainWIndow,
                    @ImgMap,
                     0.90);

                if (img.GetListRects.Count > 0)
                {
                    img.Dispose();
                    return true;
                }
                img.Dispose();
            }
            return false;
        }

        //This method will check any image in the window.
        public static bool Window_Checker(IntPtr handle, string ImgPah, double threshold = 0.90)
        {
            using (var mainWIndow = WindowInfo.Capture(handle))
            {
                var img = ImgProcess.MatchTemplate(mainWIndow,
                    ImgPah, threshold, mainImgColor: ColorConversionCodes.RGBA2RGB, subImgColor: ColorConversionCodes.RGBA2RGB);

                if (img.GetListRects.Count > 0)
                {
                    img.Dispose();
                    return true;
                }
                img.Dispose();
            }
            return false;
        }

        //checking the bag space.
        public static bool BagSpace(IntPtr handle, string ImgPah, double threshold = 0.80, int ItemSpace = 9)
        {
            //open the Bag.
            Mouse.Left_Click(handle, StaticLocations.Bag_Button);
            DelayTime.Delay(1);

            using (var mainWIndow = WindowInfo.Capture(handle))
            {
                var img = ImgProcess.MatchTemplate(mainWIndow,
                    ImgPah, threshold, mainImgColor: ColorConversionCodes.RGBA2RGB, subImgColor: ColorConversionCodes.RGBA2RGB);

                if (img.GetListRects.Count >= ItemSpace)
                {
                    Mouse.Left_Click(handle, StaticLocations.Bag_Button);
                    DelayTime.Delay(0.5);
                    img.Dispose();
                    return true;
                }
                img.Dispose();
            }
            Mouse.Left_Click(handle, StaticLocations.Bag_Button);
            DelayTime.Delay(0.5);
            return false;
        }

        //auto loot
        public static void AutoLoot (IntPtr handle)
        {
            using (var mainWIndow = WindowInfo.Capture(handle))
            {
                var img = ImgProcess.MatchTemplate(mainWIndow,
                    @"Images\Items\Gold_Ore.png", 0.80);

                if (img.GetListRects.Count > 0)
                {
                    Mouse.Left_Click(handle, img.GetCenterPoint);
                }
                img.Dispose();
            }
        }
    }
}
