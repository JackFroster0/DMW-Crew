using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SingletonMonoBehaviour<T> : SerializedMonoBehaviour where T : SingletonMonoBehaviour<T>
{
    #region  Variables
    protected static bool Quitting
    {
        get; private set;
    }

    public bool destroyable;

    private static readonly object Lock = new object();
    private static T _instance;

    /// <summary>
    /// 
    /// </summary>
    public static T instance
    {
        get
        {
            if (Quitting && Application.isPlaying)
            {
                return null;
            }

            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>(true);

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString();

                        if (!_instance.destroyable && Application.isPlaying)
                        {
                            DontDestroyOnLoad(singleton);
                        }
                    }
                }
            }

            return _instance;
        }
    }

    #endregion

    #region  Methods

    protected virtual void OnEnable()
    {
        var _resources = FindObjectsOfType<T>(true);

        //If there already is one when going back to a scene, just remove it before it gets initialized
        if (_resources.Length > 1)
        {
            UnityEngine.Debug.Log("More than one object of this kind found, destroying it...");

            Destroy(gameObject);
            return;
        }

        _instance = _resources[0];

        if (!_instance.destroyable)
        {
            DontDestroyOnLoad(_instance);
        }

        OnEnableCallback();
    }

    private void OnApplicationQuit()
    {
        Quitting = true;

        OnApplicationQuitCallback();
    }

    protected virtual void LoadingScene()
    {

    }

    protected virtual void OnApplicationQuitCallback() { }

    protected virtual void OnEnableCallback() { }

    protected virtual void OnDestroy()
    {

        _instance = null;

    }

    #endregion
}
