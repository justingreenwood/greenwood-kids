using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    PathFinding pathFinding;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathFinding = FindObjectOfType<PathFinding>();
    }
    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);   
        
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath)
        {
            coordinates = pathFinding.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathFinding.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
        //GameObject parent = GameObject.FindGameObjectWithTag("Path");
        //foreach (Transform child in parent.transform) 
        //{
        //    Tile tile = child.GetComponent<Tile>();

        //    if (tile.transform != null)
        //        path.Add(tile);
        //}

    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPostionFromCoordinates(pathFinding.StartCoordinates);
    }
    IEnumerator FollowPath()
    {

        //foreach (var tile in path)
        for(int i = 1; i < path.Count; i++)
        {
            var startPos = transform.position;
            //var endPos = tile.transform.position;
            var endPos = gridManager.GetPostionFromCoordinates(path[i].coordinates);
            float travelTime = 0f;

            transform.LookAt(endPos);

            while (travelTime < 1)
            {
                travelTime += speed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, travelTime);
                yield return new WaitForEndOfFrame();
            }

        }
        FinishPath();
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
