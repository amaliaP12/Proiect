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
             if (!File.Exists(filePath))
             {
                 // Creează fișierul dacă nu există
                 File.Create(filePath).Close();  
             }
            //opțiuni pentru formatul json
             var options = new JsonSerializerOptions { WriteIndented = true };
             //serializare obiect în json
             var json = JsonSerializer.Serialize(data, options);
             //scriere json în fisier
             File.WriteAllText(filePath, json);
             Console.WriteLine($"Datele au fost salvate în {filePath}");
         }
         //captura erori la salvare 
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
            //verificare exitență fisier
            if (File.Exists(filePath))
            {
                //citire conținut fișier
                var json=File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
        }
        //capturare erori la incarcare
        catch (Exception e)
        {
            Console.WriteLine($"Eroare la incarcarea datelor: {e.Message}");
        }
        //în cazul existenței erorilor, se va returna valoarea implicită
        return default(T);
    }
}

