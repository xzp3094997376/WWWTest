using System.Collections;
using UnityEngine;

public class TestWWW : MonoBehaviour
{
    string url = "http://itvlab.ccnu.edu.cn/injson.php?id=10001&startdate=1568949069000&enddate=1568949182355&score=88";
    // Use this for initialization
    void Start()
    {
        //www = new WWW("http://192.168.3.6:8998/TestScore.php?userName=未来立体&userEmail=qq@163.com");
        // www = new WWW("http://itvlab.ccnu.edu.cn/injson.html?id=100001&startdate=1561537917000&enddate=1561537937000&score=89");
        //www = new WWW("http://192.168.3.6:8998/TestScore.php?userName=未来立体&userEmail=qq@163.com");
        //http://itvlab.ccnu.edu.cn/injson.html?id=100001&startdate=1561537917000&enddate=1561537937000&score=89
    }
    string reqLog = "please click 。。。。";
    string reqURL = "requeset url:  ";
    string reqReturn = "return value";
    private void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(100, 100));


        GUILayout.Label("req ip(edit):  ", GUILayout.Height(30), GUILayout.Width(200));
        url = GUILayout.TextField(url, GUILayout.Height(50));
        //TextField(url, GUILayout.Height(50));
        if (GUILayout.Button("send", GUILayout.Width(200), GUILayout.Height(80)))
        {
            StartCoroutine(Test());
        }

        GUILayout.TextField(reqLog, GUILayout.Height(100)/*, GUILayout.Width(100)*/);
        GUILayout.TextField(reqURL, GUILayout.Height(100)/*, GUILayout.Width(100)*/);
        GUILayout.TextField(reqReturn, GUILayout.Height(200)/*, GUILayout.Width(100)*/);
    }

    IEnumerator Test()
    {
        //string url = WWW.EscapeURL("http://itvlab.ccnu.edu.cn/injson.php?id=10001&startdate=1568863361000&enddate=1568863501793&score=65");
        //string url = "http://192.168.3.6:8998/TestScore.php?id=10001查&startdate=1568863361000尚&enddate=1568863501793君&score=65";
        //url = "http://10.222.3.78/injson.php?id=10001&startdate=1568949069000&enddate=1568949182355&score=88";
        //url = "http://itvlab.ccnu.edu.cn/injson.php?id=10001&startdate=1568949069000&enddate=1568949182355&score=88";
        //url = url.Replace("http://localhost/", "");
        //url = "";
        //url = "www.baidu.com";
        //UnityWebRequest uwp = UnityWebRequest.Get(url);
        //Uri uri = new Uri(url);
        //WWW www = new WWW(uri.AbsoluteUri);
        //Debug.Log("url before:  " + url);
        //url = "www.pec"

        #region GUI显示
        reqLog = "please click send button。。。。";
        reqURL = "request url:  " + url;
        reqReturn = string.Empty;
        #endregion

        WWW www = new WWW(url);
        //uwp.timeout = 10;
        reqLog = "waiting 。。。。";
        yield return www;
        //yield return uwp.SendWebRequest();
        //if (uwp.isNetworkError || uwp.isHttpError)
        //{
        //    Debug.Log(uwp.error);
        //}
        //else
        //{ 
        //    Debug.Log("image arrived");
        //}
        reqLog = "net log  " + www.error;
        reqURL = "return url:  " + www.url;
        reqReturn = "return value：    " + www.text;

        //Debug.Log("error:  " + www.error);
        //Debug.Log("return:  " + www.text);
        //Debug.Log("url after:   " + www.url);
        // Debug.Log("URI:   " + uri.AbsoluteUri);
        //websocket
    }

    /// <summary>
    /// get请求
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public WWW Get(string url)
    {
        WWW www = new WWW(url);
        return www;
    }

    public WWW Post<T>(string url, T postData)
    {
        byte[] data = NetUtil.ObjectToByteArray<T>(postData);
        WWW www = new WWW(url, data);
        return www;
    }

    public static string HandleCopyPaste(int controlID)
    {
        if (controlID == GUIUtility.keyboardControl)
        {
            if (Event.current.type == UnityEngine.EventType.KeyUp && (Event.current.modifiers == EventModifiers.Control || Event.current.modifiers == EventModifiers.Command))
            {
                if (Event.current.keyCode == KeyCode.C)
                {
                    Event.current.Use();
                    TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
                    editor.Copy();
                }
                else if (Event.current.keyCode == KeyCode.V)
                {
                    Event.current.Use();
                    TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
                    editor.Paste();
#if UNITY_5_3_OR_NEWER || UNITY_5_3
                    return editor.text; //以及更高的unity版本中editor.content.text已经被废弃，需使用editor.text代替
#else
                    return editor.content.text;
#endif
                }
                else if (Event.current.keyCode == KeyCode.A)
                {
                    Event.current.Use();
                    TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
                    editor.SelectAll();
                }
            }
        }
        return null;
    }
    /// <summary>
    /// TextField复制粘贴的实现
    /// </summary>
    public static string TextField(string value, params GUILayoutOption[] options)
    {
        int textFieldID = GUIUtility.GetControlID("TextField".GetHashCode(), FocusType.Keyboard) + 1;
        if (textFieldID == 0)
            return value;

        //处理复制粘贴的操作
        value = HandleCopyPaste(textFieldID) ?? value;

        return GUILayout.TextField(value, options);
    }
}
public class NetData
{
    public string url;//url地址
    public object data;
    public NetData(string _url, object _data)
    {
        data = _data;
        url = _url;
    }

}
