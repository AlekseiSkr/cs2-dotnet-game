using _Models.Sprites;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace cs2_dotnet_game;
public class Data
{
    private const string SAVE_GAME_PATH = "stats.json";

    public PlayerStats player {  get; set; }

    public void SaveGame()
    {
        string serializedText = JsonConvert.SerializeObject(this);
        Trace.WriteLine(serializedText);
        File.WriteAllText(SAVE_GAME_PATH, serializedText);
    }

    public static Data LoadGame()
    {
        if (!File.Exists(SAVE_GAME_PATH))
            return new Data()
            { 
                player = new PlayerStats()
            };
        var fileContents = File.ReadAllText(SAVE_GAME_PATH);
        return JsonConvert.DeserializeObject<Data>(fileContents);
    }
}