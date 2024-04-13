using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip soundClip;

    [Range(0f, 1f)] public float volume;
    [Range(0f, 1f)] float pitch;

    public bool loop;

    [HideInInspector] public AudioSource source;
}