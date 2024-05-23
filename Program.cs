using System.Drawing;
namespace Colorful;

public class Program {
    public static void Main() {
        var encoded = "Critical_Blue";
        var prog = new Program();
        prog.DecodeColor(encoded);
    }
    public void DecodeColor(string encoded) {
        var statusAndColor = encoded.Split("_");
        Color textColor = Color.Black;
        if (statusAndColor.Length >= 2) {
            textColor = StringToColor(statusAndColor[1]);
        } 
        // At this point, you can pass textColor to anything expecting a color
        var outMessage = "Selected Color is ";
        outMessage += $"Alpha: {textColor.A}, ";
        outMessage += $"Red: {textColor.R}, ";
        outMessage += $"Green: {textColor.G}, ";
        outMessage += $"Blue: {textColor.B}, ";
        Console.WriteLine(outMessage);
    }
    private Color StringToColor(string color_name) {
        // Alternatively, you could loop over the result of
        // typeof(Color).GetProperties() until you find the one where the
        // Name matches.  I'm using ToLower() on both values to make the match
        // case insensitive so green or Green would both match Color.Green
        var result = typeof(Color).GetProperties().FirstOrDefault(cprop => 
            cprop.Name.ToLower() == color_name.ToLower());
        if (result != null) {
            // If you are using a version of C# that doesn't have the 
            // null coalescing operator (??), you can instead do a conditional
            // to check that result.GetValue(null,null) is not null before 
            // casting it to a color
            return (Color)(result.GetValue(null,null) ?? Color.Black);
        } else {
            return Color.Black;
        }
    }
}

