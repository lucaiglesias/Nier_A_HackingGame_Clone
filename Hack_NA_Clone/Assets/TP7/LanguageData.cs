using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LanguageData
{
    public string key;
    public string en;
    public string fr;
    public string es;
}

[Serializable]
public class StringsData
{
    public LanguageData[] strings;
}
