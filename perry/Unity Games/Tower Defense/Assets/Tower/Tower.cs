using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    //[SerializeField] GameObject topMesh;
    //[SerializeField] GameObject bottomMesh;
    //[SerializeField] GameObject bolt;



    [SerializeField] float delayTime = 1f;

    private void Start()
    {
        //bolt.SetActive(false);
        //topMesh.SetActive(false);
        //bottomMesh.SetActive(false);

        StartCoroutine(BuildTower());
    }

    public bool CreateTower(Tower tower, Vector3 pos)
    {
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null)
        {
            return false;
        }
        if(bank.CurrentBalance < cost)
        {
            return false;
        }
        else
        {
            bank.Withdraw(cost);
            Instantiate(tower.gameObject, pos, Quaternion.identity);
            return true;
        }

    }

    IEnumerator BuildTower()
    {

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayTime);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }


        //bottomMesh.SetActive(true);
        //yield return new WaitForSeconds(delayTime);
        //topMesh.SetActive(true);
        //yield return new WaitForSeconds(delayTime);
        //bolt.SetActive(true);
    }

}
