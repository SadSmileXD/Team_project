using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes_Logic : MonoBehaviour
{
    string thisLayer;//������ƮLayer���� ���� ����
    string TitleText;//������Ʈ Text�� ���� �־��� ���ں���

    //<Layer�̸�>
    const string UI_GAME_START = "UI_GameStart";
    const string UI_GAME_OPTION = "UI_GameOption";
    const string UI_EXIT = "UI_exit";
    const string TITLE_TEXT = "TitleText";
    const string BACKGROUND_IMAGE = "BackGround_Image";
    
    int FontSize = 50;//��Ʈ������ �⺻�� 50
   
    RectTransform thisPos;//UI ��ġ
    Button thisButton;//������Ʈ ��ư

    Text myText;//������Ʈ Text

    Font loadedTextFont;//���ҽ��������� ��Ʈ������
    Sprite loadedImage;//���ҽ��������� �ε��� �̹��� 
    Image thisImage;// ������Ʈ �̹���

    //<���ҽ� ���>
    const string FontPath = "Image_resources/aqua";
    const string button_Image_Path = "Font_resources/Maple";
    const string BackGround_Image_Path = "Image_resources/Test";
    private void Awake()
    {
        //���ҽ� ����
        loadedImage = Resources.Load<Sprite>(FontPath);
        loadedTextFont = Resources.Load<Font>(button_Image_Path);

        //������Ʈ �Ҵ�
        myText = GetComponentInChildren<Text>();
        if (myText == null) { myText = GetComponent<Text>(); }
        thisPos = GetComponent<RectTransform>();
        thisButton =GetComponent<Button>();
        thisImage = GetComponent<Image>();

        //���� ������ Layer���ڷ� �޴´�.
        thisLayer = LayerMask.LayerToName(this.gameObject.layer);//���� ������ƮLayer�� ���ڿ��� ����

        //���� ������Ʈ ���̾ BackGround_Image�� �ƴϸ� ��Ʈ ����
        if (thisLayer != BACKGROUND_IMAGE)
        {
            myText.font = loadedTextFont;//�ε��� �ؽ�Ʈ ��Ʈ
        }

        //UI_�� �����ϴ� ���̾�� ��ư�� ������ ���̾��ε� ��ư�̹����� ��������
        if (thisLayer.StartsWith("UI_"))
        {
            thisImage.sprite = loadedImage;//��ư �̹��� ����
        }
       
    }

    void Start()
    {
        Initialize_Layer_Settings();
        Apply_UI_Text_Setting();
    }

  

   public void  Initialize_Layer_Settings()
   {
        switch (thisLayer)
        {
            case UI_GAME_START:
                TitleText = "���ӽ���";
                thisPos.anchoredPosition = new Vector2(0,0);//anchoredPosition	UI���� �θ� RectTransform + ��Ŀ ������ 2D ��ġ
                thisButton.onClick.AddListener(Game_start);
                break;
            case UI_GAME_OPTION:
                TitleText = "�ɼ�";
                thisPos.anchoredPosition = new Vector2(0, -100);
                thisButton.onClick.AddListener(Game_option);
                break;
            case UI_EXIT:
                TitleText = "����";
                thisPos.anchoredPosition = new Vector2(0, -200);
                thisButton.onClick.AddListener(Game_Exit);
                break;
            case TITLE_TEXT:
                thisPos.anchoredPosition= new Vector2(-536, 354);
                TitleText = "The Avarice";//���� Ÿ��Ʋ ���� ����
                FontSize = 250;//Ÿ��Ʋ ��Ʈ ũ��
                break;
            case BACKGROUND_IMAGE:
                Sprite loaded = Resources.Load<Sprite>(BackGround_Image_Path);//���� ��� �⺻Resources�������� �����ϹǷ� �������� ��ν� ����¦
                if (loaded != null)
                {
                    thisImage.sprite = loaded;//����̹��� ����
                    thisImage.SetNativeSize();
                }
                break;
            default:
                Debug.Log("Layer���� �߸� �Ȱ� ������ Ȯ���ʿ�");
                break;
        }

   }
    protected void Apply_UI_Text_Setting( )//UI�� Text�� size�� �����Ѵ�.
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
