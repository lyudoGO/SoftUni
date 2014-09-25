using System;
using Problem04HTMLDispatcher;

class Problem04
{
    static void Main(string[] args)
    {
        ElementBuilder div = new ElementBuilder("div");
        div.AddAtribute("id", "page");
        div.AddAtribute("class", "big");
        div.AddContent("<p>Hello</p>");
        Console.WriteLine(div * 2);

        ElementBuilder span = new ElementBuilder("span");
        span.AddAtribute("class", "first");
        Console.WriteLine(span);

        ElementBuilder li = new ElementBuilder("li");
        li.AddAtribute("type", "disk");
        li.AddContent("I am list");
        Console.WriteLine(li * 3);

        HTMLDispatcher.CreateImage("stickman.gif", "Stickman", "Biggest image");
        HTMLDispatcher.CreateURL("http://www.softuni.bg", "Software University", "Visit as!");
        HTMLDispatcher.CreateInput("submit", "sub-button", "submit");
    }
}

