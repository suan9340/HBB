using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool shuttingDown = false;
    private static object locker = new object();
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (shuttingDown)
            {
                Debug.Log("[Singleton] Instance" + typeof(T) + "already CHOIed. Returning null.");
                return null;
            }

            lock (locker)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        GameObject _temp = new GameObject(typeof(T).ToString());
                        _instance = _temp.AddComponent<T>();
                    }
                    //DontDestroyOnLoad(_instance);
                }
            }

            return _instance;
        }
    }

    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }

    private void OnDestroy()
    {
        shuttingDown = true;
    }
}
