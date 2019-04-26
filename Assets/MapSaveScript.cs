using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSaveScript : MonoBehaviour
{
    public Tilemap Tilemap;
    public String Mapname;
    public int X;
    public int Y;
    void Start()
    {
        string path = "Assets/SavedMaps/" + Mapname + ".txt";

        Tile[] tiles = TilemapExtensions.GetTiles<Tile>(Tilemap);
        String serialMapString = "";
        int cnt = tiles.Length;
        foreach (Tile tile in tiles)
        {
            serialMapString = serialMapString + tile.sprite.name;
            if (--cnt != 0)
            {
                serialMapString = serialMapString + ";";
            }
            Debug.Log(serialMapString);
        }

        File.WriteAllText(path, string.Empty);


        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(X + ";" + Y + ";");
        writer.Write(serialMapString);
        writer.Close();

        AssetDatabase.ImportAsset(path);
    }
}
