using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Allows you to save player data to a file
public class CollectiblesSaveData : MonoBehaviour {
    #region public variables
    public int collectiblesCollected;
    #endregion

    public CollectiblesSaveData(int collectiblesCollected) {
        this.collectiblesCollected = collectiblesCollected;
    }
}
