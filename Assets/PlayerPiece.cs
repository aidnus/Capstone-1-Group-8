using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    
    public Path currentPath; 
    int pathPosition;

    public int steps;

    bool isMoving;


    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 7);
            Debug.Log("Dice rolled: " + steps);
            
            if (pathPosition + steps < currentPath.tilesList.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("You can't move that far!");
            }
        }
            
        
    }
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            Vector3 nextTile = currentPath.tilesList[pathPosition + 1].position;
            while(MoveToNextTile(nextTile))
            {
                yield return null;
            }
            steps--;
            pathPosition++;
            
        }

        isMoving = false;
    }

    bool MoveToNextTile(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
