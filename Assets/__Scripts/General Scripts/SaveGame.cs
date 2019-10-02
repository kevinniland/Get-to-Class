using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// This class is marked as static as this prevents multiple versions of the save from being created
public static class SaveGame { 
    public static void SavePlayerData(PlayerMovement playerMovement) {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        string saveFilePath = Application.persistentDataPath + "/GetToClass.save";
        FileStream fileStream = new FileStream(saveFilePath, FileMode.Create);

        PlayerSaveData playerSaveData = new PlayerSaveData(playerMovement);

        binaryFormatter.Serialize(fileStream, playerSaveData);
        fileStream.Close();
    }

    public static PlayerSaveData LoadPlayerData() {
        string saveFilePath = Application.persistentDataPath + "/GetToClass.save";

        if (File.Exists(saveFilePath)) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(saveFilePath, FileMode.Open);

            PlayerSaveData playerSaveData = binaryFormatter.Deserialize(fileStream) as PlayerSaveData;
            fileStream.Close();

            return playerSaveData;
        } else {
            Debug.Log("ERROR: Save file not found. Please try again.");
            return null;
        }
    }
}
