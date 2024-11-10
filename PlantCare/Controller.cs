using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Controller
{
    private readonly Dictionary<int, Plant> plants;

    public Controller()
    {
        plants = new Dictionary<int, Plant>();
    }

    public string AddCareItem(List<string> args)
    {
        int plantId = int.Parse(args[0]);
        string name = args[1];
        bool status = bool.Parse(args[2]);
        CareItem careItem = new CareItem(name, status);
        var care = plants.FirstOrDefault(x => x.Value.Name == name).Value;
        if (!plants.ContainsKey(plantId))
        {
            return $"Plant not found!";
        }
        plants[plantId].AddCareItem(careItem);
        return $"Created Care {name} for {plantId}!";
    }

    public string AddPlant(List<string> args)
    {
        int plantId = int.Parse(args[0]);
        string name = args[1];
        double humidityLevel = double.Parse(args[2]);
        double fertilityLevel = double.Parse(args[3]);
        string type = args[4];

        if (plants.ContainsKey(plantId))
        {
            return $"Plant with ID {plantId} already exists!";
        }

        if (type == "flower")
        {
            string color = args[5];
            Plant flower = new FloweringPlant(plantId, name, humidityLevel, fertilityLevel, color);
            plants.Add(plantId, flower);
           
        }
        if (type == "tree")
        {
            int height = int.Parse(args[5]);
            Plant tree = new TreePlant(plantId, name, humidityLevel, fertilityLevel, height);
            plants.Add(plantId, tree);
         
        }
        return $"Created Plant {name} with ID {plantId}";
    }

    public string GetTotalCaresByPlantId(List<string> args)
    {
        int plantId = int.Parse(args[0]);
        if (!plants.ContainsKey(plantId))
        {
            return $"Plant not found!";
        }
        int totalCares = plants[plantId].TotalCaresDone();
        
        if (totalCares ==0)
        {
            return $"Total cares for plant {plantId}: 0";
        }
        return $"Total cares for plant {plantId}: {totalCares}";
        
    }

    public string WaterPlantById(List<string> args)
    {
        int id = int.Parse(args[0]);
        double percent = double.Parse(args[1]);
        var plant = plants[id].Water(percent);
        Plant searchPlant = plants.FirstOrDefault(x => x.Equals(plant)).Value;
        if (searchPlant == null)
        {
            return $"Plant {id} could not be watered!";
        }
        plants[id].Water(percent);
        return $"Plant  {id} was watered succsessfully!";
    }

    public string FertilizePlantById(List<string> args)
    {
        int id = int.Parse(args[0]);
        double percent = double.Parse(args[1]);
        var plant = plants[id].Fertilize(percent);
        Plant searchPlant = plants.FirstOrDefault(x => x.Equals(plant)).Value;
        if (searchPlant == null)
        {
            return $"Plant {id} could not be fertilized!";
        }
        plants[id].Fertilize(percent);
        return $"Plant  {id} was fertilized succsessfully!";
    }

    public string GetTallestTree(List<string> args)
    {
        var maxTree = plants.Values.OfType<TreePlant>().ToList();

        if (maxTree.Count ==0)
        {
            return $"No trees found!";
        }
        var resultH = maxTree.OrderByDescending(x => x.Height).FirstOrDefault();
        return resultH.ToString();
    }

}