using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class ConceptBubble : MonoBehaviour
{
    private Dictionary<string, Sprite> spriteList;
		// Use this for initialization
	void Start ()
	{
        spriteList = new Dictionary<string, Sprite>();

        string[] rawList = AssetDatabase.FindAssets("t:Sprite");
        
        foreach(string guid in rawList)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string filename = Path.GetFileName(path);
            string spritename = Path.GetFileNameWithoutExtension(path);
            
            spriteList.Add(spritename, Resources.Load<Sprite>("Art/Concepts/" + spritename));
        }
        List<string> namelist = new List<string>(spriteList.Keys);

        foreach(string name in namelist)
        {
            Sprite sprite = spriteList[name];

            if(sprite == null)
            {
                spriteList.Remove(name);
            }
        }
	}
	
		// Update is called once per frame
	void Update ()
	{
        
	}

    public bool changeConcept(string spriteName)
    {
        Sprite sprite;

        if(!spriteList.TryGetValue(spriteName, out sprite))
        {
            return false;
        }
        else
        {
            var concept = transform.Find("Concept");

            if( concept != null)
            {
                Sprite nuSprite = sprite;
                concept.GetComponent<Image>().sprite = nuSprite;
            }
            return true;
        }
    }
}
