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


public class getSpotDescription : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject gameobject;
    public string temptext;
    public InitializeDropDown dropdown;
    void Start()
    {
        gameobject = GameObject.FindGameObjectWithTag("DropDown"); 
        dropdown = gameobject.GetComponent<InitializeDropDown>();
        dropdown.dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown.dropdown);
        });
        getSpot();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getSpot()
    {

        string url = "https://6114821a.ngrok.io/api/spots/?format=";
        string q = HttpUtility.UrlEncode(string.Join(" ", ""));
        // HTTPアクセス
        var req = WebRequest.Create(url + q);
        req.Headers.Add("Accept-Language:ja,en-us;q=0.7,en;q=0.3");
        var res = req.GetResponse();
        // レスポンス(JSON)をオブジェクトに変換
        ServiceResult info;
        using (res)
        {
            using (var resStream = res.GetResponseStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(ServiceResult));
                info = (ServiceResult)serializer.ReadObject(resStream);
            }
        }
        // 結果を出力
        System.Console.WriteLine("22");
        foreach (var r in info.results)
        {
            if (r.content == "乗り換え")
            {
                text.text = dropdown.TranslateDescription(r.name);
                temptext = r.name;

            }


        }
    }
    [DataContract]
    public class ServiceResult
    {
        [DataMember]
        public string count
        { get; set; }
        [DataMember]
        public string next { get; set; }
        [DataMember]
        public string previous { get; set; }
        [DataMember]
        public List<Result> results { get; set; }

        [DataContract]
        public class Result
        {
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string latitude { get; set; }
            [DataMember]
            public string longitude { get; set; }
            [DataMember]
            public string content { get; set; }
            [DataMember]
            public string[] category { get; set; }
            [DataMember]
            public string created_at { get; set; }
            [DataMember]
            public string updated_at { get; set; }
            [DataMember]
            public string status { get; set; }
            [DataMember]
            public string[] author { get; set; }

        }
    }
    void DropdownValueChanged(Dropdown change)
    {
        text.text = dropdown.TranslateDescription(temptext);
    }
}
