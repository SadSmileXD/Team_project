using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Leein;
using UnityEngine.UI;
using static UnityEditor.Progress;
using Unity.VisualScripting;
namespace Custom.CustomResource
{
    public static class FolderPaths
    {
        public const string Imagepaths = "Image_resources";
        public const string FontPaths = "Font_resources";
        public const string ScriptableObjectPath = "SceneData";
        public const string AudioPath = "Audio_resources";
    }

    public static class CustomResourceLoad  
    {
        public static AudioClip LoadAudioClip(this string _Str, string resourceName)
        {
            var item = Resources.Load<AudioClip>(FolderPaths.AudioPath + "/" + resourceName);
            if (item == null)
            {
                Debug.LogError($"[ResourceLoader] Failed to load: {resourceName}");
            }
            else
            {
                Debug.Log($"[ResourceLoader] Loaded audio clip: {resourceName}");
            }
            return item;
        }

        public static AudioClip LoadAudioClip(this string resourceName)
        {
            var item = Resources.Load<AudioClip>(FolderPaths.AudioPath + "/" + resourceName);
            if (item == null)
            {
                Debug.LogError($"[ResourceLoader] Failed to load: {resourceName}");
            }
            else
            {
                Debug.Log($"[ResourceLoader] Loaded audio clip: {resourceName}");
            }
            return item;
        }

        public static Font LoadFont(this string _Str, string resourceName)
        {
            var item = Resources.Load<Font>(FolderPaths.FontPaths+"/"+ resourceName);
            if (item == null)
            {
                Debug.LogError($"[ResourceLoader] Failed to load: {resourceName}");
            }
            else
            {
                Debug.Log($"�ε�� ���ҽ� �̸�: {resourceName}");
            }
            return item;
        }
        public static Font LoadFont(this string resourceName)
        {
            var item = Resources.Load<Font>(FolderPaths.FontPaths + "/" + resourceName);
            if (item == null)
            {
                Debug.LogError($"[ResourceLoader] Failed to load: {resourceName}");
            }
            else
            {
                Debug.Log($"�ε�� ���ҽ� �̸�: {resourceName}");
            }
            return item;
        }
        

        public static Sprite LoadSprite(this string resourceName)
        {
            var item = Resources.Load<Sprite>(FolderPaths.Imagepaths + "/" + resourceName);
            if (item == null)
            {
                Debug.LogError($"[ResourceLoader] Failed to load: {resourceName}");
            }
            else
            {
                Debug.Log($"�ε�� ���ҽ� �̸�: {resourceName}");
            }
            return item;
        }
        public static Sprite LoadSprite(this string _Str, string resourceName)
        {
            var item = Resources.Load<Sprite>(FolderPaths.Imagepaths + "/" + resourceName);
            if (item == null)
            {
                Debug.LogError($"[ResourceLoader] Failed to load: {resourceName}");
            }
            else
            {
                Debug.Log($"�ε�� ���ҽ� �̸�: {resourceName}");
            }
            return item;
        }
        public static ScriptableObject Loadscriptobject(this string _Str,string resourceName)
        {
            var item = Resources.Load<SceneData>(FolderPaths.ScriptableObjectPath + "/" + resourceName);
            if (item == null)
            {
                Debug.LogError($"[ResourceLoader] Failed to load: {resourceName}");
            }
            else
            {
                Debug.Log($"�ε�� ���ҽ� �̸�: {resourceName}");
            }
            return item;
        }
    }
    
}

