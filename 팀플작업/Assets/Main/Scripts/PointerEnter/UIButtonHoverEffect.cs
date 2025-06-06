using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverEffect : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    RectTransform m_RectTransform;//오브젝트 RectTransform
    Vector3 originalScale;//원래 사이즈
    bool isHovered = false;
   
    Color m_Color;//지금 현재 컬러값 저장할 변수
    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        originalScale = m_RectTransform.localScale;
     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHovered) return;
        
         
            m_RectTransform.localScale = originalScale * 1.1f;
            isHovered = true;
            Debug.Log("Enter");
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isHovered) return;
        m_RectTransform.localScale = originalScale;
        isHovered = false;
        Debug.Log("Exit");
    }
}
