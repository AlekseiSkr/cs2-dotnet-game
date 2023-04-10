using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace cs2_dotnet_game;

public class Settings
{
    private const string SAVE_SETTINGS_PATH = "settings.json";

    public float Volume { get; set; }

    public void SaveSettings()
    {
        string serializedText = JsonConvert.SerializeObject(this);
        Trace.WriteLine(serializedText);
        File.WriteAllText(SAVE_SETTINGS_PATH, serializedText);
    }

    public static Settings LoadSettings()
    {
        var fileContents = File.ReadAllText(SAVE_SETTINGS_PATH);
        return JsonConvert.DeserializeObject<Settings>(fileContents);
    }
}
