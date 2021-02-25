using UnityEngine;

public static class Saving
{
    private static DataSaving dataSaving = new DataSaving();
    private static string json;

    public static void Save(GeneralSetup generalSetup)
    {
        dataSaving.drawLines = generalSetup.drawLines;
        dataSaving.LastOpenLevel = generalSetup.LastOpenLevel;
        dataSaving.LastUnlockedLevel = generalSetup.LastUnlockedLevel;

        json = JsonUtility.ToJson(dataSaving);
        PlayerPrefs.SetString("SaveAll", json);

        Debug.Log("SAVE");
        Debug.Log(json);
    }

    public static void Load(GeneralSetup generalSetup)
    {
        try
        {
            json = PlayerPrefs.GetString("SaveAll");
            dataSaving = JsonUtility.FromJson<DataSaving>(json);

            generalSetup.drawLines = dataSaving.drawLines;
            generalSetup.LastOpenLevel = dataSaving.LastOpenLevel;
            generalSetup.LastUnlockedLevel = dataSaving.LastUnlockedLevel;

            Debug.Log("LOAD");
            Debug.Log(json);
        }
        catch
        {
            Debug.Log("Save not found");
        }
    }

    public static void ResetSaves()
    {
        json = JsonUtility.ToJson(new DataSaving());
        PlayerPrefs.SetString("SaveAll", json);
    }
}