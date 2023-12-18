using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [SerializeField] GameObject _character;
    public DataToSave data = new DataToSave();
  
    private void SaveData()
    {
        var scene = SceneManager.GetActiveScene();

        data = new DataToSave(scene.buildIndex, transform.position, _character.name);

        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(_character.name, json);

        //Сохранить в файле в Ассетах
        string path = Path.Combine(Application.persistentDataPath, "GameDATA.json");
        Debug.Log(path);

        File.WriteAllText(path, json);

        Debug.Log("Saved: " + json);
    }
    private void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "GameDATA.json");

        data = JsonUtility.FromJson<DataToSave>(File.ReadAllText(path));

        SceneManager.LoadScene(data.SceneIndex);

        _character.transform.position = data.Position;

        Debug.Log("Loaded: " + data.Name + "at position" + data.Position);
    }

    public void Save()
    {
        SaveData();
    }
    public void Load()
    {
        LoadData();
    }
}



[Serializable]
public class DataToSave
{
    public int SceneIndex;
    public Vector3 Position;
    public string Name;

    public DataToSave() { }
    public DataToSave(int sceneInd, Vector3 position, string name)
    {
        SceneIndex = sceneInd;
        Position = position;
        Name = name;
    }

}