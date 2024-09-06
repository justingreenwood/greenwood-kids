using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{

    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        if(myLight.spotAngle > minimumAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }

        myLight.intensity -= lightDecay * Time.deltaTime;
        
    }

    public void Restore(float intensityAmount, float restoreAngle) 
    { 

        myLight.intensity = intensityAmount;
        myLight.spotAngle = restoreAngle;

    }
}
