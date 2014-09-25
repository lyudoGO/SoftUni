using System;

namespace Problem04HTMLDispatcher
{
    static class HTMLDispatcher
    {
        public static void CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder image = new ElementBuilder("img");
            image.AddAtribute("src", imageSource);
            image.AddAtribute("alt", alt);
            image.AddContent(title);
            Console.WriteLine(image);
        }

        public static void CreateURL(string url, string title, string text)
        {
            ElementBuilder link = new ElementBuilder("a");
            link.AddAtribute("href", url);
            link.AddAtribute("title", title);
            link.AddContent(text);
            Console.WriteLine(link);
        }

        public static void CreateInput(string inputType, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAtribute("type", inputType);
            input.AddAtribute("name", name);
            input.AddAtribute("value", value);
            Console.WriteLine(input);
        }
    }
}
