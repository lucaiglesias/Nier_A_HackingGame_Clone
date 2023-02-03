using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> bulletList = new List<GameObject>();
    int poolIndex;

    public static BulletPool Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetPoolObject()
    {
        //if (poolIndex == bulletList.Count)
        //{
        //    poolIndex = 0;
        //}

        poolIndex %= bulletList.Count; //same thing as the 'if' above

        return bulletList[poolIndex++];
    }
}
