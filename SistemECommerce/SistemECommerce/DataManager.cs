using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace SistemECommerce;

public static class DataManager
{
    //Salvare in fisier
    public static void SalvareDate<T>(string filePath,T data)
    {
        try
        {
            var options=new JsonSerializerOptions{WriteIndented=true};
            var json=JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath,json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la salvarea datelor: {ex.Message}");
        }
    }
    
    //Incarcare in fisier
    public static T? IncarcaDate<T>(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var json=File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Eroare la incarcarea datelor: {e.Message}");
        }

        return default(T);
    }
}

