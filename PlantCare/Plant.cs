using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

public abstract class Plant
{
    private int id;

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    private string name;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value.Length < 3 || value.Length == 30)
            {
                throw new ArgumentException("Name should be between 3 and 30 characters!");
            }
            name = value;
        }
    }

    private string type;

    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Type should be between 3 and 30 characters!");
            }
            type = value;
        }
    }

    private List<CareItem> careItems;

    private double humidityLevel;

    public double HumidityLevel
    {
        get
        {
            return humidityLevel;
        }
        set
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentException("Humidity Level should be between 0 and 1!");
            }
            humidityLevel = value;
        }
    }


    private double fertilityLevel;

    public double FertilityLevel
    {
        get
        {
            return fertilityLevel;
        }
        set
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentException("Fertility Level should be between 0 and 1!");
            }
            fertilityLevel = value;
        }
    }

    public Plant(int id, string name, string type, double humidityLevel, double fertilityLevel)
    {
        this.Id = id;
        this.Name = name;
        this.Type = type;
        this.HumidityLevel = humidityLevel;
        this.fertilityLevel = fertilityLevel;
        //Inicializirane na list
        this.careItems = new List<CareItem>();
    }

    public void AddCareItem(CareItem careItem)
    {
        careItems.Add(careItem);
    }

    public int TotalCaresDone()
    {
        return careItems.Count(x => x.Status == true);
    }

    public bool Water(double percent)
    {
        double newHumidityLevel = humidityLevel + percent;
        if (humidityLevel>1)
        {
            return false;
        }
        humidityLevel = newHumidityLevel;
        return true;
    }

    public bool Fertilize(double percent)
    {
       double newFertilityLevel = fertilityLevel+ percent;
        if (newFertilityLevel>1)
        {
            return false;
        }
        fertilityLevel=newFertilityLevel;
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Name: {Name}");
        sb.AppendLine($"Type: {Type}");
        sb.AppendLine($"Humidity Level: {HumidityLevel:f2} %");
        sb.AppendLine($"Fertility Level: {FertilityLevel:f2} %");

        return sb.ToString().Trim();
    }
}
