using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        string language = "";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            language = "en";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            language = "fr";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            language = "es";
        }

        if (!string.IsNullOrWhiteSpace(language))
        {
            Localization.CurrentLanguage = language;
            FindObjectsOfType<TextLocalizer>().ToList().ForEach(x=>x.Localize());
        }
    }
}
