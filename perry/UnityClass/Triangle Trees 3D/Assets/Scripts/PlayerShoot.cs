using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GameObject newGameObject;
    [SerializeField] GameObject prefab;
    Vector3 newPosition;
    Quaternion newRotation;
    void Start()
    {
        
    }

    
    void Update()
    {
        CreateWeapon();

    }

    private void CreateWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            newRotation = transform.rotation;
            newPosition = transform.position;
            newPosition.z += 1f;
            newRotation =  Quaternion.Euler(newPosition.x,newPosition.y + 90,newRotation.z);  
            newGameObject = Instantiate(prefab, newPosition, newRotation);
            newGameObject.SetActive(true);
        }
    }
}
