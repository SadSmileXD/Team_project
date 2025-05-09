using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainTitleMusic : MonoBehaviour
{
    Dontdestroy_Audio Play;
    string Audiopath = "Audio_resources/hebi";
    protected void Start()
    {
        if(Dontdestroy_Audio.Instance != null)
        {
            Dontdestroy_Audio.Instance.ChangeAudioClip(Audiopath);
        }
         
    }
    
}
