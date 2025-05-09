using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharatorSelectAudio : MonoBehaviour
{
 
    string Audiopath = "Audio_resources/eve";
    protected void Start()
    {
        if (Dontdestroy_Audio.Instance != null)
        {
            Dontdestroy_Audio.Instance.ChangeAudioClip(Audiopath);
        }
    }
}
