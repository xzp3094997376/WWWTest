using UnityEngine;

public class NetMgr : MonoBehaviour
{
    public static NetMgr instanse = null;
    private void Awake()
    {
        instanse = this;
    }
    /// <summary>
    /// get请求
    /// </summary>
    public void GetRequest(string url)
    {

    }
    public void PostRequest(string url)
    {

    }

}
