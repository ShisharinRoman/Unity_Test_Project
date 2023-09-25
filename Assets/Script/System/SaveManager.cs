using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Save
{
    public float                positionPlayerX;
    public float                positionPlayerY;
    public Dictionary<int, int> inventoryPlayer;
    public float                healthPlayer;    
}

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Save data;

    public void Awake()
    {
        data = new Save();
    }

    public void OnApplicationQuit()
    {
        if ( !player.activeSelf )
        {
            return;
        }
        createData();
        saveDataToFile();
    }

    private void createData()
    {
        data.positionPlayerX =  player.transform.position.x;
        data.positionPlayerY =  player.transform.position.y;
        data.inventoryPlayer =  player.GetComponent<IInventoryData>().Items;
        data.healthPlayer =     player.GetComponent<IHealthData>().Health;
    }
    private void saveDataToFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath =           Application.persistentDataPath + "/SaveData.dat";
        FileStream fileStream =     new FileStream( filePath, FileMode.Create );

        formatter.Serialize( fileStream, data );
        fileStream.Close();
    }

    public void loadDataFromFile()
    {
        string filePath = Application.persistentDataPath + "/SaveData.dat";
        if (!File.Exists( filePath ))
        {
            return;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream =     new FileStream( filePath, FileMode.Open );
        data =                      formatter.Deserialize( fileStream ) as Save;
        fileStream.Close();
        loadDataToGame();
    }

    private void loadDataToGame()
    {
        Camera.main.transform.position =                new Vector3( data.positionPlayerX, data.positionPlayerY, -10 );
        player.transform.position =                     new Vector2( data.positionPlayerX, data.positionPlayerY );
        player.GetComponent<IInventoryData>().Items =   data.inventoryPlayer;
        player.GetComponent<IHealthData>().Health =     data.healthPlayer;
    }
}