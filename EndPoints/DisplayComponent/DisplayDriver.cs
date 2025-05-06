using System;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.EndPoints.DisplayComponent;

public class DisplayDriver
{
    public string? Title { get; set; }
    public string? Body { get; set; }
    public static void Clear()
    {
        Console.Clear();
    }

    public void GetColour(string colour, string title, string body)
    {
        switch (colour)
        {
            case "Black":
                Title = Black(title);
                Body = Black(body);
                break;
            case "Red":
                Title = Red(title);
                Body = Red(body);
                break;
            case "Green":
                Title = Green(title);
                Body = Green(body);
                break;
            case "Yellow":
                Title = Yellow(title);
                Body = Yellow(body);
                break;
            case "Blue":
                Title = Blue(title);
                Body = Blue(body);
                break;
            case "Magenta":
                Title = Magenta(title);
                Body = Magenta(body);
                break;
            case "Cyan":
                Title = Cyan(title);
                Body = Cyan(body);
                break;
            case "White":
                Title = White(title);
                Body = White(body);
                break;
        }
    }
}