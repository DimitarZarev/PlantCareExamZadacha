using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class FloweringPlant : Plant
{
    private string color;

    public string Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
        }
    }

    public FloweringPlant(int id, string name, double humidityLevel, double fertilityLevel, string color) : base(id, name, "flower", humidityLevel, fertilityLevel)
    {
        this.Color = color;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Name: {Name}");
        sb.AppendLine($"Type: {Type}");
        sb.AppendLine($"Humidity Level: {HumidityLevel:f2} %");
        sb.AppendLine($"Fertility Level: {FertilityLevel:f2} %");
        sb.AppendLine($"Color: {Color}");

        return sb.ToString().Trim();
    }
}
