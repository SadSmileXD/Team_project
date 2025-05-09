using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceChartor : MonoBehaviour
{
    public Chatator chatator;
    Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(asdsadas);
    }
    void asdsadas()
    {
        Select.Instance.SelectChatator=chatator;
    }
}
