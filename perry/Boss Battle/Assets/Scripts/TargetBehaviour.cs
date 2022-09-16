using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public float MinHeight = 2f;
    public float MaxHeight = 10f;
    private GameObject floor;
    public float TooFar = 20f;
    GameController gameController;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(RandomPositionOverFloor(), Vector3.up, Color.yellow, 1F);

        if (Mathf.Abs(transform.position.x) > TooFar || Mathf.Abs(transform.position.y) > TooFar || Mathf.Abs(transform.position.z) > TooFar)
        {
            Destroy(gameObject);
            gameController.PlayerScored();
        }


    }
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        floor = GameObject.FindGameObjectWithTag("Floor");
        transform.position = RandomPositionOverFloor();
    }

    private Vector3 RandomPositionOverFloor()
    {
        var bounds = floor.GetComponent<Renderer>().bounds;
        var centerX = bounds.center.x;
        var centerZ = bounds.center.z;
        var sizeX = bounds.size.x;
        var sizeZ = bounds.size.z;
        var minX = centerX - (sizeX / 2) + 0.5f;
        var maxX = centerX + (sizeX / 2) - 0.5f;
        var minZ = centerX - (sizeZ / 2) + 0.5f;
        var maxZ = centerZ + (sizeZ / 2) - 0.5f;
        var randomPosition = new Vector3(Random.Range(minX, maxX),
            Random.Range(MinHeight, MaxHeight), Random.Range(minZ, maxZ));
        return randomPosition;
    }
}
