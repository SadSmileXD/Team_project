using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes_Logic : MonoBehaviour
{
    string thisLayer;//오브젝트Layer값을 받을 변수
    Button myButton;//버튼
    RectTransform thisPos;//위치
    Text myText;//오브젝트 Text
    String TitleText;//오브젝트 Text에 값을 넣어줄 문자변수
    int FontSize=50;//폰트사이즈 기본값 50
    Font loadedTextFont;//리소스폴더에서 폰트가져옴
    Sprite loadedImage;//이미지 
    Image myImage;
    private void Awake()
    {
        //리소스 빌드
        loadedImage = Resources.Load<Sprite>("Image_resources/aqua");//버튼 이미지 리소스 경로 입력
        loadedTextFont = Resources.Load<Font>("Font_resources/Maple");//텍스트 폰트 리소스 

        //컴포넌트 할당
        myText = GetComponentInChildren<Text>() != null ? GetComponentInChildren<Text>() : GetComponent<Text>();//자식 오브젝트에 없으면 현재 오브젝트에서 찾기
        thisPos = GetComponent<RectTransform>();
        myButton =GetComponent<Button>();
        myImage = GetComponent<Image>();


        thisLayer = LayerMask.LayerToName(this.gameObject.layer);//현재 오브젝트Layer를 문자열로 저장
        if (thisLayer != "BackGround_Image")//배경이미지가 아니면 폰트 지정 ㄱ
        {
            myText.font = loadedTextFont;//로드한 텍스트 폰트
        }
        if(thisLayer.StartsWith("UI_"))
        {
            myImage.sprite = loadedImage;//버튼 이미지 설정
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
                TitleText = "게임시작";
                thisPos.anchoredPosition = new Vector2(0,0);//anchoredPosition	UI에서 부모 RectTransform + 앵커 기준의 2D 위치
                myButton.onClick.AddListener(Game_start);
                break;
            case "UI_GameOption":
                TitleText = "옵션";
                thisPos.anchoredPosition = new Vector2(0, -100);
                myButton.onClick.AddListener(Game_option);
                break;
            case "UI_exit":
                TitleText = "종료";
                thisPos.anchoredPosition = new Vector2(0, -200);
                myButton.onClick.AddListener(Game_Exit);
                break;
            case "TitleText":
                thisPos.anchoredPosition= new Vector2(-536, 354);
                TitleText = "The Avarice";//메인 타이틀 제목 설정
                FontSize = 250;//타이틀 폰트 크기
                break;
            case "BackGround_Image":
                Sprite loaded = Resources.Load<Sprite>("Image_resources/Test");//폴더 경로 기본Resources폴더에서 시작하므로 하위폴더 경로시 알잘짝
                if (loaded != null)
                {
                    myImage.sprite = loaded;//배경이미지 설정
                    myImage.SetNativeSize();
                }
                break;
            default:
                break;
        }

   }
    protected void UI_Text_Setting( )//UI에 Text와 size를 설정한다.
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
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 실행 중지
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
