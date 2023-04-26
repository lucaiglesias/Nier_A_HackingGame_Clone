using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Linq;
using System;

public class DeathTracker : MonoBehaviour
{
    [SerializeField] TMP_Text enemyDeathText;
    public int i = 0;
    string teste = "Oi";
    string id = "9tNhKFSoR7";

    public IEnumerator CreateDeathTracker()
    { 
        using (var request = new UnityWebRequest("https://parseapi.back4app.com/classes/DeathTracker", "POST")) 
        { 
            request.SetRequestHeader("X-Parse-Application-Id", Secrets.ApplicationId); 
            request.SetRequestHeader("X-Parse-REST-API-Key", Secrets.RestApiKey); 
            request.SetRequestHeader("Content-Type", "application/json"); 
            var json = "{\"Name\": \""+teste+"\",\"Count\": 0, \"Lives\" : 0}"; 
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success) 
            { 
                Debug.LogError(request.error); 
                yield break;
            } 
            Debug.Log(request.downloadHandler.text); 
        } 
    }

    public IEnumerator GetDeathTracker() 
    {
        string uri = "https://parseapi.back4app.com/classes/DeathTracker/?where={\"Name\":\"Enemy\"}";
        //string uri = "https://parseapi.back4app.com/classes/DeathTracker/?where={\"Name\":\""+teste+"\"}"; 
        using (var request = UnityWebRequest.Get(uri)) 
        { 
            request.SetRequestHeader("X-Parse-Application-Id", Secrets.ApplicationId); 
            request.SetRequestHeader("X-Parse-REST-API-Key", Secrets.RestApiKey);
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest(); 
            if (request.result != UnityWebRequest.Result.Success) 
            { 
                Debug.LogError(request.error); 
                yield break; 
            } 
            Debug.Log(request.downloadHandler.text); 
            DeathTrackerResults results = JsonUtility.FromJson<DeathTrackerResults>(request.downloadHandler.text);


            //var matches = Regex.Matches(request.downloadHandler.text, "\"Count\":(\\d+)", RegexOptions.Multiline); 
            //enemyDeathText.text = matches.First().Groups[1].Value; 
            enemyDeathText.text = results.results.First().Count.ToString();
        } 
    }

    public IEnumerator IncEnemyDeathTracker()
    {
        byte[] MyData = BitConverter.GetBytes(i);
        using (var request = new UnityWebRequest("https://parseapi.back4app.com/classes/DeathTracker/"+id+"", "PUT"))
        {
            request.SetRequestHeader("X-Parse-Application-Id", Secrets.ApplicationId);
            request.SetRequestHeader("X-Parse-REST-API-Key", Secrets.RestApiKey);
            request.SetRequestHeader("Content-Type", "application/json");
            var json = "{\"Count\": "+i+"}";
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }
            Debug.Log(request.downloadHandler.text);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //string regex = "";
        
        if(Input.GetKeyUp(KeyCode.Q)) 
        {
            StartCoroutine(CreateDeathTracker());
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            StartCoroutine(GetDeathTracker());
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            i++;
            StartCoroutine(IncEnemyDeathTracker());
        }
        


    }
}
