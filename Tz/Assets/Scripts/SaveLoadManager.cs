using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ISaveLoader
{
    void LoadData();
    void SaveData();
}

public sealed class SaveLoadManager : MonoBehaviour
{

   
        private readonly ISaveLoader[] saveLoaders = {
        new InventorySaveLoader(),
    };


    [ContextMenu("Load Game")]
    public void LoadGame()
        {
            Repository.LoadState();

            foreach (var saveLoader in this.saveLoaders)
            {
                saveLoader.LoadData();
            }
        }
    [ContextMenu("Save Game")]
    public void SaveGame()
        {
            foreach (var saveLoader in this.saveLoaders)
            {
                saveLoader.SaveData();
            }

            Repository.SaveState();
        }
    }
