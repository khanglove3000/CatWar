using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
public class CatManager : MonoBehaviour
{

    [SerializeField] protected Transform optionContainner;
    [SerializeField] protected GameObject catPrefabs;
    private Queue<GameObject> catPool = new Queue<GameObject>();
    [SerializeField] private int CatPoolSize = 10;

    private void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CatPrefabs(catPrefabs);
        }  
    }
    void CatPrefabs(GameObject CatPrefabs)
    {
        for (int i = 0; i < CatPoolSize; i++)
        {
            GameObject laser = LeanPool.Spawn(CatPrefabs);
            catPool.Enqueue(laser);
        }

    }
}
