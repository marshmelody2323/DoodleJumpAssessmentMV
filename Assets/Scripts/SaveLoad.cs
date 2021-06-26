using UnityEngine;
using UnityEngine.UI;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static SaveData data;

    private static string filePath = Application.streamingAssetsPath + "/highscore.awesome";

    public static void Load()
    {
        // Check if the streaming assets folder exists... if it doesn't, make it
        if (!Directory.Exists(Application.streamingAssetsPath))
            Directory.CreateDirectory(Application.streamingAssetsPath);

        if (File.Exists(filePath))
        {
            // Get the river from the ram to the file
            using (FileStream stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                // Open the dam gates to let the data through
                BinaryFormatter formatter = new BinaryFormatter();
                data = (SaveData)formatter.Deserialize(stream); 

                // Close the dam
                stream.Close();
            }
        }
        else
        {
            data = new SaveData();
        }
    }

    public static void Save()
    {
        Score score = GameObject.FindObjectOfType<Score>();
        Debug.Log("this score + name = " + score.ScoreValue + score.NameInput);
        Debug.Log("data score + name = " + data.score + data.playerName);
        //if (data.score < score.ScoreValue)
        {
            data = new SaveData();
            data.score = score.ScoreValue;
            // Set the player name here
            

            InputField field = GameObject.FindObjectOfType<InputField>();
            score.NameInput = field.text;
            data.playerName = score.NameInput;


            // Check if the streaming assets folder exists... if it doesn't, make it
            if (!Directory.Exists(Application.streamingAssetsPath))
                Directory.CreateDirectory(Application.streamingAssetsPath);

            // Get the river from the ram to the file
            using (FileStream stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                // Open the dam gates to let the data through
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);

                // Close the dam
                stream.Close();
            }
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int score = 0;
    public string playerName = "";
}