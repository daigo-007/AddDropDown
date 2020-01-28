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
public class DisplayButtonScript : MonoBehaviour
{
    private GameObject view;
    private GameObject button;
    private Text targetText;
    private GameObject text;

    // Start is called before the first frame update
    void Start()
    {

        view = GameObject.Find("/Canvas/Panel/view");

        view.SetActive(false);

    }

    void Update()
    {

    }
    public void OnClick()
    {
        //Text view_text = text.GetComponent<Text>();

        //view_text.text = "sssss";
        if (view.activeSelf)
        {
            view.SetActive(false);

        }
        else
        {
            view.SetActive(true);



        }

    }
   
}
