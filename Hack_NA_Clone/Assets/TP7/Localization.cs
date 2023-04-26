using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Icons;

public class Localization : MonoBehaviour
{
    public static string CurrentLanguage = "en";
    
    //Linha
    static string languages = File.ReadAllText("D:\\Nier_A_HackingGame_Clone\\Hack_NA_Clone\\Assets\\TP7\\Dictionary.json");

    //StringsData stringsData;

    static IDictionary<string, IDictionary<string, string>> languageDictionary = null;


    public static string GetString(string key)
    {
        if(languageDictionary == null)
        {
            LoadValues();
        }
        return languageDictionary[CurrentLanguage][key];
    }

    public static void LoadValues()
    {
        languageDictionary = new Dictionary<string, IDictionary<string, string>>();
        StringsData stringsData = JsonUtility.FromJson<StringsData>(languages);
        //languageDictionary = new Dictionary<string,LanguageData>();
        languageDictionary.Add("en", new Dictionary<string, string>());
        languageDictionary.Add("fr", new Dictionary<string, string>());
        languageDictionary.Add("es", new Dictionary<string, string>());


        foreach (LanguageData languageData in stringsData.strings)
        {
            languageDictionary["en"].Add(languageData.key, languageData.en);
            languageDictionary["fr"].Add(languageData.key, languageData.fr);
            languageDictionary["es"].Add(languageData.key, languageData.es);
        }
    }


}

