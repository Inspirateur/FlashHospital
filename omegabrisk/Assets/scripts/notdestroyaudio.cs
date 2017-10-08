using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notdestroyaudio : MonoBehaviour {

    private static notdestroyaudio instance = null;
    public static notdestroyaudio Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
