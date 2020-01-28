using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Unity.Editor;
using System.Web;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Text;
public class InitializeDropDown : MonoBehaviour
{
    [SerializeField]
    public  Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearOptions();
        dropdown.options.Add(new Dropdown.OptionData { text = "日本語" });
        dropdown.options.Add(new Dropdown.OptionData { text = "English" });
        dropdown.options.Add(new Dropdown.OptionData { text = "中文" });
        dropdown.options.Add(new Dropdown.OptionData { text = "한국어" });
        dropdown.options.Add(new Dropdown.OptionData { text = "español" });
        dropdown.options.Add(new Dropdown.OptionData { text = "Português" });
        dropdown.options.Add(new Dropdown.OptionData { text = "italiano" });
        dropdown.options.Add(new Dropdown.OptionData { text = "Deutsch" });
        dropdown.options.Add(new Dropdown.OptionData { text = "Français" });
        dropdown.options.Add(new Dropdown.OptionData { text = "русский" });
        dropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  string TranslateDescription(string text)
    {
        Encoding enc = Encoding.GetEncoding("utf-8");
        string url = "https://script.google.com/macros/s/AKfycbyqLAsXWHrcSdqwLOIrF6Hv-ZBP3SV7CAcrao8ZfNwtBIp3mWA/exec";
        string request_lang = GetCurrentLanguage();
        if (request_lang == "ja") return text;
        var query = "?text=" + text + "&source=ja&target=" + request_lang;
        var posUrl = url + query;
        var req = WebRequest.Create(posUrl);
        var res = req.GetResponse();
        Stream st = res.GetResponseStream();
        StreamReader sr = new StreamReader(st, enc);
        string getText = sr.ReadToEnd();
        return getText;
    }
    public string GetCurrentLanguage()
    {
        switch (dropdown.value)
        {
            case 0:
                return "ja";
            case 1:
                return "en";
            case 2:
                return "zh-cn";
            case 3:
                return "ko";
            case 4:
                return "es";
            case 5:
                return "pt";
            case 6:
                return "it";
            case 7:
                return "de";
            case 8:
                return "fr";
            case 9:
                return "ru";
            default:
                return "en";

        }
    }
}
