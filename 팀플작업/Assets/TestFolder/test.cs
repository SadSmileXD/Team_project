using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public static test instance;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        if(spriteRenderer ==null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
      
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �ִٸ� �ߺ� ����
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject); // �� ������Ʈ�� �� ��ȯ �ÿ��� ����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TestB");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("dsds");
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            this.spriteRenderer.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            this.spriteRenderer.enabled = true;
        }
    }
}
