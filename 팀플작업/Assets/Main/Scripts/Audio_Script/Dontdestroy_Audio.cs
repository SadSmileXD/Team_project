using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dontdestroy_Audio : Singleton<Dontdestroy_Audio>
{
    AudioSource m_Source;
    
    private void Awake()
    {
        base.Awake();
        m_Source=GetComponentInChildren<AudioSource>();
        
    }
   
   public void ChangeAudioClip(string AudioPath)
    {
        var Clip= Resources.Load<AudioClip>(AudioPath);
        m_Source.clip = Clip;
        m_Source.Play();

    }
  
}
