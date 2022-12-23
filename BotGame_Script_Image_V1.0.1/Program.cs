using OpenCvSharp;
using ScriptImage;

//handle Game Called "Dead Cells"
var handle = WindowInfo.handleTitle("Dead Cells");

while (true)
{
    //Take screen-shot of the game window.
    using (var mainImage = WindowInfo.Capture(handle))
    {
        //make MatchTemplate
        var image = ImgProcess.MatchTemplate(mainImage, @"Images\Img1.png", 0.9);

        //draw the matching
        image.DrawMultiRec();

        //this fixes the memory leak
        image.Dispose();

        //show me the result
        Cv2.ImShow("Window", mainImage);
        Cv2.WaitKey(1);
    }
}