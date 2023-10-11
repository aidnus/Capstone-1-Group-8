using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPiece : MonoBehaviour
{

    public Path currentPath; 
    int pathPosition;

    public int steps;

    public bool isMoving;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving) {
            steps = Random.Range(1, 7);
            Debug.Log("Dice Rolled: " + steps);
            
            if (pathPosition + steps < currentPath.tilesList.Count - 1) {
                StartCoroutine(Move());
            }

            else {
                Debug.Log("Rolled Number is too high!");
            }


        }
    }

    private void Start () {
        currentPath = FindObjectOfType<Path>();
        pathPosition = 0;
        
    }

    IEnumerator Move()
    {
        if (isMoving) {
            yield break;
        }
        isMoving = true; 

        while (steps > 0) {
            Vector3 nextTile = currentPath.tilesList[pathPosition + 1].position;
            while (MoveToNextNode(nextTile)) {
                
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--; 
            pathPosition++; 
        }


        isMoving = false;
        
    }

    bool MoveToNextNode(Vector3 goal) {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 5f * Time.deltaTime));
    }

}
