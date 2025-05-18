using UnityEngine;

[CreateAssetMenu(menuName = "Data/SceneData")]
public class SceneData : ScriptableObject
{
    //public SoundType soundType;  // ���⼭ ��Ӵٿ��� ���� ���� �̸����� ����
    
    [Header("��ư�̹���")]public buttonImagePath ButtonImage;
    [Header("����̹���")]public BackGroundImagePath BackImage;
    [Header("��Ʈ�̹���")]public FontPath FontImage;
    // public AudioClip clip;
}
