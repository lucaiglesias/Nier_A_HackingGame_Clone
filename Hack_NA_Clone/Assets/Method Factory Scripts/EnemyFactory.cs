using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{

    //SINGLETON
    //public static EnemyFactory Instance { get; private set;} //Solution Renaud
    private static EnemyFactory _instance;
    public static EnemyFactory Instance { get { return _instance; } }

    private List<GameObject> weakMonsters = new List<GameObject>();
    private List<GameObject> strongMonsters = new List<GameObject>();
    private int maxWeakMonsters = 90;
    private int maxStrongMonsters = 30;

    //GameObject spawnedMonster;

    [SerializeField] private GameObject weakMonster;
    [SerializeField] private GameObject strongMonster;
    

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
    }

    public GameObject CreateWeakEnemy()
    {
        //ObjectPool
        GameObject spawnedMonster = new GameObject();
        for (int i = 0; i < weakMonsters.Count; i++)
        {
            if (!weakMonsters[i].activeInHierarchy)
            {
                weakMonsters[i].SetActive(true);
                spawnedMonster = weakMonsters[i];
                break;
            }
        }
        return spawnedMonster;

        //return Instantiate(weakMonster); //Solution Renaud
    }
    public GameObject CreateStrongEnemy()
    {
        //ObjectPool
        GameObject spawnedMonster = new GameObject();
        for (int i = 0; i < strongMonsters.Count; i++)
        {
            if (!strongMonsters[i].activeInHierarchy)
            {
                strongMonsters[i].SetActive(true);
                spawnedMonster = strongMonsters[i];
                break;
            }
        }
        return spawnedMonster;
        //return Instantiate(strongMonster); //Solution Renaud
    }

    void Start()
    {
            GameObject newWeakMonster;
            GameObject newStrongMonster;

        for (int i = 0; i < maxWeakMonsters; i++)
        {
            newWeakMonster = Instantiate(weakMonster);
            weakMonsters.Add(newWeakMonster);
            newWeakMonster.SetActive(false);
        }
        for (int i = 0; i < maxStrongMonsters; i++)
        {
            newStrongMonster = Instantiate(strongMonster);
            strongMonsters.Add(newStrongMonster);
            newStrongMonster.SetActive(false);
        }
    }
}
