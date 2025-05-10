using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Chatator
{
    one=1,
    two,
    three,
    four,
}
public class Select : Singleton<Select>
{
    public  Chatator SelectChatator;
    private void Awake()
    {
        base.Awake();
        SelectChatator = new Chatator();
    }
   
}
