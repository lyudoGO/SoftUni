using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Computer
{
    private string name;
    private Component processor;
    private Component mainBoard;
    private Component graphicsCard;
    private Component ram;
    private Component hdd;
    private decimal totalPrice;

    public Computer(string name, Component processor, Component ram)
    {
        this.Name = name;
        this.Processor = processor;
        this.Ram = ram;
        this.totalPrice = this.processor.Price + this.ram.Price;
    }

    public Computer(string name, Component processor, Component ram, Component mainBoard, Component graphicsCard, Component hdd)
    {
        this.Name = name;
        this.Processor = processor;
        this.Ram = ram;
        this.MainBoard = mainBoard;
        this.GraphicsCard = graphicsCard;
        this.Hdd = hdd;
        this.totalPrice = this.processor.Price + this.ram.Price + this.mainBoard.Price + this.graphicsCard.Price + this.hdd.Price;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty!");
            }

            this.name = value;
        }
    }

    public Component Processor
    {
        get { return this.processor; }
        set { this.processor = value; }
    }

    public Component MainBoard
    {
        get { return this.mainBoard; }
        set { this.mainBoard = value; }
    }

    public Component GraphicsCard
    {
        get { return this.graphicsCard; }
        set { this.graphicsCard = value; }
    }

    public Component Ram
    {
        get { return this.ram; }
        set { this.ram = value; }
    }

    public Component Hdd
    {
        get { return this.hdd; }
        set { this.hdd = value; }
    }

    public decimal TotalPrice
    {
        get { return this.totalPrice; }
        set { this.totalPrice = value; }
    }

    public void PrintResult()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("Computer name: " + this.Name);
        result.AppendLine("Processor: " + this.Processor);
        result.AppendLine("RAM: " + this.Ram);
        if (this.MainBoard != null)
        {
            result.AppendLine("Main board: " + this.MainBoard);
        }

        if (this.GraphicsCard != null)
        {
            result.AppendLine("Graphics card: " + this.GraphicsCard);
        }

        if (this.Hdd != null)
        {
            result.AppendLine("HDD: " + this.Hdd);
        }

        result.AppendLine("Total price: " + this.TotalPrice + " lv.\n");
        Console.WriteLine(result);
     }
}

class Component
{
    private string name;
    private string details;
    private decimal price = 0M;

    public Component(string name, string details, decimal price)
    {
        this.Name = name;
        this.Details = details;
        this.Price = price;
    }

    public Component(string name, decimal price) : this(name, null, price) { }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty!");
            }

            this.name = value;
        }
    }

    public string Details
    {
        get { return this.details; }
        set
        {
            if (value != null && value.Length <= 0)
            {
                throw new ArgumentException("Details cannot be empty!");
            }

            this.details = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price cannot be negative or zero!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        string result = "";
        if (String.IsNullOrEmpty(this.Details))
        {
            return result = string.Format("{0}, Price: {1}lv.", this.Name, this.Price);
        }
        else
        {
            return result = string.Format("{0}, Details: {1}, Price: {2}lv.", this.Name, this.Details, this.Price);
        }
    }
}

class Problem3
{
    static void Main(string[] args)
    {
        Component component11 = new Component("I5-4570", "3,2GHz/2MB/LGA1150/BOX", 220.00M);
        Component componetn12 = new Component("4 GB", "DDR3 1333 ADATA", 45.00M);
        Computer computer1 = new Computer("ASUS", component11, componetn12);

        Component component21 = new Component("I7-4930K", 650.00M);
        Component componetn22 = new Component("16 GB", 190.00M);
        Computer computer2 = new Computer("DELL", component21, componetn22);

        Component component31 = new Component("I3-4150", "3.5GHZ/3MB/LGA1150/BOX", 120.00M);
        Component componetn32 = new Component("2 GB", "DDR3 1333 ADATA", 25.00M);
        Computer computer3 = new Computer("DELL", component31, componetn32);

        Component component41 = new Component("AMD A6-7400K", "X2/3.5G/FM2+/BOX", 163.00M);
        Component component42 = new Component("2X8 GB", "DDR3 1600 ADATA", 25.00M);
        Component component43 = new Component("ASROCK 970", "EXTREME3/AMD970/AM3", 80.00M);
        Component component44 = new Component("SAPPHIRE R5 230", "1GB DDR3 HDMI", 48.00M);
        Component component45 = new Component("Hitachi", "1T SG SATA 6G/7200/64M", 115.00M);
        Computer computer4 = new Computer("Sbirstain", component41, component42, component43, component44, component45);
 
        List<Computer> computers = new List<Computer>();

        computers.Add(computer1);
        computers.Add(computer2);
        computers.Add(computer3);
        computers.Add(computer4);

        computers = computers.OrderBy(x => x.TotalPrice).ToList();

        foreach (var computer in computers)
        {
            computer.PrintResult();
        }
    }
}