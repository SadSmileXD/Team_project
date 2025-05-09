using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWinodw : MonoBehaviour
{
    string thisObjectName;
    Button button;
  public  static  Text thisText;
    private void Awake()
    {
        thisObjectName = this.gameObject.name;
        button = GetComponent<Button>();

    }
    void Start()
    {
      
        switch (thisObjectName)
        {
            case "Yes":
                button.onClick.AddListener(NextStage);
                break;
            case "No":
                button.onClick.AddListener(activefalse);
                break;
            case "Job_Text":
               
                thisText = GetComponent<Text>();
                thisText.text = Select.Instance.SelectChatator.ToString();
                break;
            case "Button":
                button.onClick.AddListener(activetrue);
                break;
            default:
               
                Debug.Log("�̸� Ȯ�� ��");
                break;
        }

        

    }
    void NextStage()
    {
        Debug.Log("������������ ��");
    }
    void activefalse()
    {
        var obj=GameObject.Find("YesOrNo_UI");
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }
    void activetrue()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var obj in allObjects)
        {
            if (obj.name == "YesOrNo_UI")
            {
                obj.SetActive(true);
                var obT=GameObject.Find("Job_Text");
                thisText= obT.GetComponent<Text>();
                thisText.text = Select.Instance.SelectChatator.ToString();
                Debug.Log("������Ʈ�� Ȱ��ȭ�߽��ϴ�!");
            }
        }
        
    }

}
