using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes_Logic : MonoBehaviour
{
    string thisLayer;//������ƮLayer���� ���� ����
    Button myButton;//��ư
    RectTransform thisPos;//��ġ
    Text myText;//������Ʈ Text
    String TitleText;//������Ʈ Text�� ���� �־��� ���ں���
    int FontSize=50;//��Ʈ������ �⺻�� 50
    Font loadedTextFont;//���ҽ��������� ��Ʈ������
    Sprite loadedImage;//�̹��� 
    Image myImage;
    private void Awake()
    {
        //���ҽ� ����
        loadedImage = Resources.Load<Sprite>("Image_resources/aqua");//��ư �̹��� ���ҽ� ��� �Է�
        loadedTextFont = Resources.Load<Font>("Font_resources/Maple");//�ؽ�Ʈ ��Ʈ ���ҽ� 

        //������Ʈ �Ҵ�
        myText = GetComponentInChildren<Text>() != null ? GetComponentInChildren<Text>() : GetComponent<Text>();//�ڽ� ������Ʈ�� ������ ���� ������Ʈ���� ã��
        thisPos = GetComponent<RectTransform>();
        myButton =GetComponent<Button>();
        myImage = GetComponent<Image>();


        thisLayer = LayerMask.LayerToName(this.gameObject.layer);//���� ������ƮLayer�� ���ڿ��� ����
        if (thisLayer != "BackGround_Image")//����̹����� �ƴϸ� ��Ʈ ���� ��
        {
            myText.font = loadedTextFont;//�ε��� �ؽ�Ʈ ��Ʈ
        }
        if(thisLayer.StartsWith("UI_"))
        {
            myImage.sprite = loadedImage;//��ư �̹��� ����
        }
       
    }

    void Start()
    {
        Setting();
        UI_Text_Setting();
    }

  

   public void  Setting()
   {
        switch (thisLayer)
        {
            case  "UI_GameStart":
                TitleText = "���ӽ���";
                thisPos.anchoredPosition = new Vector2(0,0);//anchoredPosition	UI���� �θ� RectTransform + ��Ŀ ������ 2D ��ġ
                myButton.onClick.AddListener(Game_start);
                break;
            case "UI_GameOption":
                TitleText = "�ɼ�";
                thisPos.anchoredPosition = new Vector2(0, -100);
                myButton.onClick.AddListener(Game_option);
                break;
            case "UI_exit":
                TitleText = "����";
                thisPos.anchoredPosition = new Vector2(0, -200);
                myButton.onClick.AddListener(Game_Exit);
                break;
            case "TitleText":
                thisPos.anchoredPosition= new Vector2(-536, 354);
                TitleText = "The Avarice";//���� Ÿ��Ʋ ���� ����
                FontSize = 250;//Ÿ��Ʋ ��Ʈ ũ��
                break;
            case "BackGround_Image":
                Sprite loaded = Resources.Load<Sprite>("Image_resources/Test");//���� ��� �⺻Resources�������� �����ϹǷ� �������� ��ν� ����¦
                if (loaded != null)
                {
                    myImage.sprite = loaded;//����̹��� ����
                    myImage.SetNativeSize();
                }
                break;
            default:
                break;
        }

   }
    protected void UI_Text_Setting( )//UI�� Text�� size�� �����Ѵ�.
    {
        if(myText !=null)
        {
            myText.text = TitleText;
            myText.fontSize = FontSize;
        }
   
    }

    protected void Game_Exit()
    {
        Debug.Log("EXIT");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ��� ���� ����
        #endif

        Application.Quit();
    }
   protected void Game_option()
   {
        Debug.Log("OPTION");
    }
   protected void Game_start()
   {
        Debug.Log("START");
        SceneManager.LoadScene("Character selection");
    }


}
