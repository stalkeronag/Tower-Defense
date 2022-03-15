using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SavePosition : ISaveable
{
    [SerializeField] private Vector3 position;
    private float[] vector3;
    [SerializeField] private string path;
    public SavePosition(string path, Vector3 position)
    {
       this.path = path;
       this.position = position;
       vector3 =new float[3];
       vector3[0] = position.x;
       vector3[1] = position.y;
       vector3[2] = position.z;
    }
    public void UodatePosition(Vector3 position)
    {
           this.position = position;
           vector3[0] = position.x;
           vector3[1] = position.y;
           vector3[2] = position.z;
    }
   public void Save()
   {
        using(var fileStream = File.Open(path,FileMode.OpenOrCreate,FileAccess.Write))
        {
            var serializer  =new XmlSerializer(typeof(float[]));
            serializer.Serialize(fileStream,vector3);
        }
   }
   public void Load()
   {
       if(!Directory.Exists(path))
        {
            return;
        }
        using(var fileStream = File.Open(path,FileMode.Open,FileAccess.Read))
        {
            var serializer  =new XmlSerializer(typeof(float[]));
            vector3 = serializer.Deserialize(fileStream) as float[];
        }
        position.x = vector3[0];
        position.y = vector3[1];
        position.z = vector3[2];
   }
}
