using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;

public class TreePlant : Plant
{
    private int height;

    public int Height
    {
        get
        {
            return height;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Height should be positive!");
            }
            height = value;
        }
    }

    public TreePlant(int id, string name, double humidityLevel, double fertilityLevel, int height)
        : base(id, name, "tree", humidityLevel, fertilityLevel)
    {
        this.Height = height;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Name: {Name}");
        sb.AppendLine($"Type: {Type}");
        sb.AppendLine($"Humidity Level: {HumidityLevel:f2} %");
        sb.AppendLine($"Fertility Level: {FertilityLevel:f2} %");
        sb.AppendLine($"Height: {Height}");
        return sb.ToString().Trim();
    }
}

