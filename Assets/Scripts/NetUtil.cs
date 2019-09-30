using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class NetUtil
{
    /// <summary>
    ///对象转换为byte 数组
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static byte[] ObjectToByteArray<T>(T obj)
    {
        if (obj == null)
        {
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
    /// <summary>
    /// 将byte[] 数组转换为System.object
    /// </summary>
    /// <param name="arrBytes"></param>
    /// <returns></returns>
    public static T ByteArrayToObject<T>(byte[] arrBytes)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arrBytes, 0, arrBytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            var obj = bf.Deserialize(ms);
            return (T)obj;
        }
    }
}
