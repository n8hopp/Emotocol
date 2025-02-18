using Wacton.Unicolour;

namespace Emotocool;

public class GraphicsDrawable : IDrawable
{
    public GraphicsDrawable()
    {
        EmotoColor = new Color(0,0,0);
    }

    public int RedAlpha { get; set; } 
    public int YellowAlpha { get; set; }
    public int GreenAlpha { get; set; }
    public int CyanAlpha { get; set; }
    public int BlueAlpha { get; set; }
    public int MagentaAlpha { get; set; }
    private Color EmotoColor { get; set; }
    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeSize = 20;
        RectF ovalRect = new RectF(dirtyRect.Center.X-100, dirtyRect.Center.Y-100, 200, 200);
        
        List<Color> colors =
        [
            new Color(255, 0, 0, RedAlpha),
            new Color(255, 255, 0, YellowAlpha),
            new Color(0, 255, 0, GreenAlpha),
            new Color(0, 255, 255, CyanAlpha),
            new Color(0, 0, 255, BlueAlpha),
            new Color(255, 0, 255, MagentaAlpha)
        ];
        
        var redWhiteness = 1 - RedAlpha / 255.0;
        var yellowWhiteness = 1 - YellowAlpha / 255.0;
        var greenWhiteness = 1 - GreenAlpha / 255.0;
        var cyanWhiteness = 1 - CyanAlpha / 255.0;
        var blueWhiteness = 1 - BlueAlpha / 255.0;
        var magentaWhiteness = 1 - MagentaAlpha / 255.0;
        
        // Unicolour red = new Unicolour(ColourSpace.Hwb, 0, redWhiteness, 0.0);
        // Unicolour yellow = new Unicolour(ColourSpace.Hwb, 60, yellowWhiteness, 0.0);
        // Unicolour green = new Unicolour(ColourSpace.Hwb, 120, greenWhiteness, 0.0);
        // Unicolour cyan = new Unicolour(ColourSpace.Hwb, 180, cyanWhiteness, 0.0);
        // Unicolour blue = new Unicolour(ColourSpace.Hwb, 240, blueWhiteness, 0.0);
        // Unicolour magenta = new Unicolour(ColourSpace.Hwb, 300, magentaWhiteness, 0.0);
        //
        //
        // EmotoColor = new Color(fullMix.Rgb.Byte255.R, fullMix.Rgb.Byte255.G, fullMix.Rgb.Byte255.B, 255);

        // Drawing code goes here
        CalculateEmoto(colors);
        canvas.FillColor = EmotoColor;
        canvas.FillCircle(dirtyRect.Center, 90);
        //
        // foreach(Color color in colors)
        // {
        //     canvas.FillColor = color;
        //     canvas.FillCircle(dirtyRect.Center, 90);
        // }
        int startAngle = 60;
        int endAngle = 120;
        foreach (var color in colors)
        {
            canvas.StrokeColor = color;
            canvas.DrawArc(ovalRect, startAngle, endAngle, false, false);
            startAngle -= 60;
            endAngle -= 60;
        }
    }

    public void CalculateEmoto(List<Color> list)
    {
        float redScale = 0;
        float greenScale = 0;
        float blueScale = 0;
        
        // calculate un-scaled color values
        // 
        foreach (Color color in list)
        {
            var scalar = color.Alpha;
            redScale += scalar * color.Red;
            greenScale += scalar * color.Green;
            blueScale += scalar * color.Blue;
        }
        
        // scale the color values to percentages
        var total = redScale + greenScale + blueScale;
        redScale /= total;
        greenScale /= total;
        blueScale /= total;
        
        Console.WriteLine("Red: " + redScale + " Green: " + greenScale + " Blue: " + blueScale + " Total: " + total);
        EmotoColor = new Color(redScale, greenScale, blueScale, 1);
    }
}