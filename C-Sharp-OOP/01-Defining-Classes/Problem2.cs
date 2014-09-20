using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

class Laptop
{
    private string model;
    private string manufacturer;
    private string processor;
    private int ram;
    private string graphicsCard;
    private string hdd;
    private string screen;
    private double price;
    private Battery batt;

    public Laptop(string model, double price)
    {
        this.Model = model;
        this.Price = price;
    }

    public Laptop(string model, double price, string manufacturer = null, string processor = null, int ram = 0, string graphicsCard = null, string hdd = null, string screen = null, Battery batt = null):this(model, price)
    {
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.Ram = ram;
        this.GraphicsCard = graphicsCard;
        this.Hdd = hdd;
        this.Screen = screen;
        this.Batt = batt;
    }

    public string Model
    {
        get { return this.model; }
        set 
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be empty!");
            }
            this.model = value; 
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set 
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be empty!");
            }
            this.manufacturer = value; 
        }
    }

    public string Processor
    {
        get { return this.processor; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be empty!");
            }
            this.processor = value;
        }
    }

    public int Ram
    {
        get { return this.ram; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The RAM cannot be negative!");
            }
            this.ram = value;
        }
    }

    public string GraphicsCard
    {
        get { return this.graphicsCard; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be empty!");
            }
            this.graphicsCard = value;
        }
    }

    public string Hdd
    {
        get { return this.hdd; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be empty!");
            }
            this.hdd = value;
        }
    }

    public string Screen
    {
        get { return this.screen; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be empty!");
            }
            this.screen = value;
        }
    }

    public double Price
    {
        get { return this.price; }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("The price cannot be negative!");
            }
            this.price = value; 
        }
    }

    public Battery Batt
    {
        get { return this.batt; }
        set { this.batt = value; }
    }
    
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("Model: " + this.Model);
        if(this.Manufacturer != null)
        {
            result.AppendLine("Manufacturer: " + this.Manufacturer);
        }
        if(this.Processor != null)
        {
            result.AppendLine("Processor: " + this.Processor);
        }
        if(this.Ram != 0)
        {
            result.AppendLine("RAM: " + this.Ram + " GB");
        }
        if (this.GraphicsCard != null)
        {
            result.AppendLine("Graphics card: " + this.GraphicsCard);
        }
        if (this.Hdd != null)
        {
            result.AppendLine("HDD: " + this.Hdd);
        }
        if (this.Screen != null)
        {
            result.AppendLine("Screen: " + this.Screen);
        }
        if (this.Batt != null)
        {
            result.AppendLine("Battery: " + this.batt.Batt);
            result.AppendLine("Battery life: " + this.batt.BatteryLife + " hours");
        }
        string pr = string.Format("{0:0.00}", this.price);
        result.AppendLine("Price: " + pr + " lv.");

        return result.ToString();
    }
}

class Battery
{
    private string battery;
    private float batteryLife;

    public Battery(string battery, float batteryLife)
    {
        this.Batt = battery;
        this.BatteryLife = batteryLife; 
    }

    public string Batt
    {
        get { return this.battery; }
        set 
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be empty!");
            }
            this.battery = value; 
        }
    }

    public float BatteryLife
    {
        get { return this.batteryLife; }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("The battery life cannot be negative!");
            }
            this.batteryLife = value; 
        }
    }
}

class Problem2
{
    static void Main(string[] args)
    {
        Laptop lpt1 = new Laptop("Lenovo Yoga 2 Pro", 2259.00);
        Console.WriteLine(lpt1);

        Battery batt = new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5f);
        Laptop lpt2 = new Laptop("Lenovo Yoga 2 Pro", 2259.00, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8, "Intel HD Graphics 4400", "128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", batt );
        Console.WriteLine(lpt2);
    }
}