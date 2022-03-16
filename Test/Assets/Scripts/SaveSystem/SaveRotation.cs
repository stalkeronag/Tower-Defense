using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveRotation : ISaveable
{
    private string path;
    private Vector3 position;
    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }
    public void Init(string path) => this.path = path;
    public void Save()
    {
        float[] vector3 = new float[3];
        vector3[0] = position.x;
        vector3[1] = position.y;
        vector3[2] = position.z;
        using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(float[]));
            serializer.Serialize(fs, vector3);
        }
    }
    public void Load()
    {
        float[] vector3 = new float[3];
        if (!File.Exists(path))
        {
            return;
        }
        using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(float[]));
            vector3 = serializer.Deserialize(fs) as float[];
        }
        position.x = vector3[0];
        position.y = vector3[1];
        position.z = vector3[2];
    }
}
