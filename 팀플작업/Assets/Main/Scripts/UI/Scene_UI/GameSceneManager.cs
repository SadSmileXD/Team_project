using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Custom.CustomComponent;

public class GameSceneManager : MonoBehaviour
{
    public GameObject ParentsOBJ;
    GameObject[] children; 
    //<Layer�̸�>
    public struct UILayerNames
    {
        public const string UI_GAME_START = "UI_GameStart";
        public const string UI_GAME_OPTION = "UI_GameOption";
        public const string UI_EXIT = "UI_exit";
        public const string TITLE_TEXT = "TitleText";
        public const string BACKGROUND_IMAGE = "BackGround_Image";
    }

    //<���ҽ� ���>
    public struct ResourcePaths
    {
        public const string FontPath= "Image_resources";
        public const string ButtonImagePath="Font_resources";
        public const string BackGroundImagePath = "Image_resources";
        public const string SceneDataPath = "SceneData";
    }

    string LayerName;//������ƮLayer���� ���� ����
    string TitleText;//������Ʈ Text�� ���� �־��� ���ں���
    int FontSize = 50;//��Ʈ������ �⺻�� 50

    RectTransform rectTransform;//UI ��ġ
    Button button;//������Ʈ ��ư
    Text text;//������Ʈ Text
    Font loadedTextFont;//���ҽ��������� ��Ʈ������
    Sprite loadedImage;//���ҽ��������� �ε��� �̹��� 
    Image image;// ������Ʈ �̹���
    
    SceneData m_Data;//��ũ��Ʈ������Ʈ <-- ���ҽ�������
    void Findchildren()
    {
        int i = 0;
        var FindObj = GetComponentsInChildren<ComponentEnum>();
        foreach (var obj in FindObj)
        {
            if (obj != null)
            {
                children[i++] = obj.GetComponent<GameObject>();
            }
        }
        foreach (var obj in children)
        {
            Debug.Log($"������Ʈ �̸� :{obj.name}");
        }
    }
    private void Awake()
    {
        //������Ʈ �Ҵ�
        GetComponent();
        ResourceBuild();
        SetLayerName();
        ApplyUIByLayerName();
    }

    void ApplyUIByLayerName()
    {
        //���� ������Ʈ ���̾ BackGround_Image�� �ƴϸ� ��Ʈ ����
        if (LayerName != UILayerNames.BACKGROUND_IMAGE)
        {
            text.font = loadedTextFont;//�ε��� �ؽ�Ʈ ��Ʈ
        }

        //UI_�� �����ϴ� ���̾�� ��ư�� ������ ���̾��ε� ��ư�̹����� ��������
        if (LayerName.StartsWith("UI_"))
        {
            image.sprite = loadedImage;//��ư �̹��� ����
        }
    }
    void SetLayerName()
    {
        //���� ������ Layer���ڷ� �޴´�.
        LayerName = LayerMask.LayerToName(gameObject.layer);//���� ������ƮLayer�� ���ڿ��� ����
    }
    void ResourceBuild()  //���ҽ� ����
    {
        var TestPath = ResourcePaths.SceneDataPath+"/"+ DataName.SceneOneData.ToString();//<-enum���� ���濹��
        m_Data = Resources.Load<SceneData>(TestPath);
        if(m_Data == null)
        { 
            Debug.LogError($"{m_Data}");
            return;
        }

        var FontImagePath = ResourcePaths.FontPath + "/" + m_Data.FontImage.ToString();
        loadedImage = Resources.Load<Sprite>(FontImagePath);
        if (loadedImage == null) 
        {
            Debug.LogError($"{loadedImage}");
            return;
        }

        var ButtonImagePath = ResourcePaths.ButtonImagePath+ "/" + m_Data.ButtonImage.ToString();
        loadedTextFont = Resources.Load<Font>(ButtonImagePath);
        if (loadedTextFont == null) 
        { 
            Debug.LogError($"{loadedTextFont}");
            return;
        }

    }

    void GetComponent()
    {
        text =gameObject.SafeGetComponentInChildren<Text>("Text");
        rectTransform = gameObject.SafeGetComponent<RectTransform>("RectTransform");
        button = gameObject.SafeGetComponent<Button>("Button");
        image = gameObject.SafeGetComponent<Image>("Image");
    }

    void Start()
    {
        Initialize_Layer_Settings();
        Apply_UI_TextSetting();
    }

    public void  Initialize_Layer_Settings()
   {
        switch (LayerName)
        {
            case UILayerNames.UI_GAME_START:
                SetupLayer("���ӽ���", new Vector2(0, 0), Game_start);
                break;
            case UILayerNames.UI_GAME_OPTION:
                SetupLayer("�ɼ�", new Vector2(0, -100), Game_option);
                break;
            case UILayerNames.UI_EXIT:
                SetupLayer("����", new Vector2(0, -200), Game_Exit);
                break;
            case UILayerNames.TITLE_TEXT:
                SetupTitleText();
                break;
            case UILayerNames.BACKGROUND_IMAGE:
                SetupBackgroundImage();
                break;
            default:
                Debug.Log("Layer���� �߸� �Ȱ� ������ Ȯ���ʿ�");
                break;
        }

   }
    
    void SetupLayer(string title, Vector2 position, UnityEngine.Events.UnityAction buttonAction)
    {
        TitleText = title;
        rectTransform.anchoredPosition = position;  // UI ��ġ ����
        button.onClick.AddListener(buttonAction);  // ��ư Ŭ�� �̺�Ʈ ����
    }

    protected void Apply_UI_TextSetting( )//UI�� Text�� size�� �����Ѵ�.
    {
        if(text !=null)
        {
            text.text = TitleText;
            text.fontSize = FontSize;
        }
   
    }
    void SetupTitleText()
    {
        rectTransform.anchoredPosition = new Vector2(-536, 354);
        TitleText = "The Avarice";//���� Ÿ��Ʋ ���� ����
        FontSize = 250;//Ÿ��Ʋ ��Ʈ ũ��
    }
    void SetupBackgroundImage()
    {
        var BackGroundImagePath = ResourcePaths.BackGroundImagePath+"/" + m_Data.BackImage.ToString();
        var Load = Resources.Load<Sprite>(BackGroundImagePath);
        if (Load != null)
        {
            image.sprite = Load;//����̹��� ����
            image.SetNativeSize();
        }
        else
        {
            Debug.LogError("GameSceneManager->SetupBackgroundImage�Լ� error");
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
