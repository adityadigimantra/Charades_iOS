using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class DailogController : MonoBehaviour
{
    [System.Serializable]
    public class Language
    {
        public string language;
        public TextAsset languageFile;
    }

    [Header("Json Data and Language File")]
    public TextAsset[] JsonFiles;
    public Language[] languages;
    public string _language;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _language = PlayerPrefs.GetString("Language");
        if (_language == "")
        {
            Debug.Log("No Foriegn Language Found,switching to default English");
            _language = "English";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
