using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public enum Panel
{
   Error,
   Subscribe,
   Generator
}

public class PanelManager : MonoBehaviour
{
    Dictionary<Panel, GameObject> dictionary = new();
    GameObject clone = null;

    static PanelManager instace;
    
    public static PanelManager instance { get { return instace; } }

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
            
    }

    public void Load(Panel panel, string message)
    {
        if (dictionary.TryGetValue(panel, out clone) == false)
        {
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));

           
            clone.name = clone.name.Replace("(Clone)", "");

            dictionary.Add(panel, clone);
        }
        else
        {
            clone = dictionary[panel];

            clone.SetActive(true);
        }

        if (clone.GetComponent<ErrorPanel>() == true)
        {
            clone.GetComponent<ErrorPanel>().SetText(message);
        }

    }

  
}

