using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class DeathTrackerTO
{
    public string objectId;
    public string Name;
    public int Count;
    public int Lives;
    public string createdAt;
    public string updatedAt;

}

[Serializable] public class DeathTrackerResults
{
    public DeathTrackerTO[] results;
}



