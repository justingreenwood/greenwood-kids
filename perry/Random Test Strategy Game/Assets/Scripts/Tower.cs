using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    List<GameObject> archers = new List<GameObject>();
    [SerializeField] int maxArchers = 4;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RemoveUnit(int i, GameObject target)
    {
        target.SetActive(true);
        archers.RemoveAt(i);
    }

    public void AddUnit(GameObject target)
    {
        if (archers.Count < maxArchers)
        {
            target.SetActive(false);
            archers.Add(target);
        }
    }






}
