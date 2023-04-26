using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Localizer : MonoBehaviour
{
    string language = "";

    // Update is called once per frame
    void Update()
    {   
    }

    public void HandleInputData(int val)
    {
        if(val == 0)
        {
            language = "en";
            Debug.Log("English selected");
        }
        if(val == 1)
        {
            language = "es";
            Debug.Log("Spanish selected");
        }
        if (val == 2)
        {
            language = "pt";
            Debug.Log("Portuguese selected");
        }
        if (val == 3)
        {
            language = "fr";
            Debug.Log("French selected");
        }
        if (val == 4)
        {
            language="it";
            Debug.Log("Italian selected");
        }
        
        if (string.IsNullOrEmpty(language)) { }

        Localization();
    }

    private void Localization()
    {
        //Linha
        string[] languages = File.ReadAllLines("C:\\Users\\luca_\\source\\repos\\Localization\\Localization\\dicionario.csv");


        //Coluna
        string[] keys = languages[0].Split(';');


        //Create dictionary area
        IDictionary<string, IDictionary<string, string>> localization = new Dictionary<string, IDictionary<string, string>>();


        //
        for (int i = 1; i < keys.Length; i++)
        {
            localization.Add(keys[i], new Dictionary<string, string>());

            for (int j = 1; j < languages.Length; j++)
            {
                string[] language = languages[j].Split(';');
                localization[keys[i]].Add(language[0], language[i]);
            }
        }


    }
}
