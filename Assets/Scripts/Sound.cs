using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume=.5f;
    [Range(.1f,3)]
    public float pitch=1f;
    [Range(0f, 1f)]
    public float spatialBlend = 1;
    public bool loop;

    public float maxDistance=100;
    public float minDistance=10;

    [HideInInspector]
    public AudioSource source;
    
}
