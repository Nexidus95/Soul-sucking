using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMapSetter : MonoBehaviour
{
    public string currentMapName;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().currentMap = currentMapName;
    }
}