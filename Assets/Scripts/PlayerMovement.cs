using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float timeToMove = 0.2f; 
    [SerializeField] private GameObject raycastObjUp;
    [SerializeField] private GameObject raycastObjDown;
    [SerializeField] private GameObject raycastObjLeft;
    [SerializeField] private GameObject raycastObjRight;
    public GoldManager goldMan;
    
    private bool canMove = false;
    private bool isMoving = false;
    private Vector2 origPosition = Vector2.zero;
    private Vector2 targetPosition = Vector2.zero;
    
    void FixedUpdate()
    {
        if (!isMoving) 
        {
            //get moving direction and start a coroutine with it and the appropriate raycast object
            if (Input.GetKey(KeyCode.W)) {StartCoroutine(MovePlayer(Vector2.up,    raycastObjUp));    }
            if (Input.GetKey(KeyCode.A)) {StartCoroutine(MovePlayer(Vector2.left,  raycastObjLeft));  }
            if (Input.GetKey(KeyCode.S)) {StartCoroutine(MovePlayer(Vector2.down,  raycastObjDown));  }
            if (Input.GetKey(KeyCode.D)) {StartCoroutine(MovePlayer(Vector2.right, raycastObjRight)); }
        }
    }

    private IEnumerator MovePlayer(Vector2 moveDirection, GameObject raycastObj)
    {
        //check if theres a collision in the moving direction
        if (rayCheckForCollision(moveDirection, raycastObj, "Wall") || goldMan.inCutscene) { canMove = false; }
        else { canMove = true; }

        if (canMove)
        {
            //slows down the player depending on the amount of gold carries
            if (goldMan.goldCountCurrent < 40) { timeToMove = 0.2f; }
            else if (goldMan.goldCountCurrent is > 41 and < 70) { timeToMove = 0.25f; }
            else if (goldMan.goldCountCurrent is > 71 and < 90) { timeToMove = 0.3f; }
            else if (goldMan.goldCountCurrent is > 91 and < 130) { timeToMove = 0.35f; }
            else if (goldMan.goldCountCurrent is > 131 and < 160) { timeToMove = 0.4f; }
            else if (goldMan.goldCountCurrent is > 161 and < 210) { timeToMove = 0.45f; }
            else if (goldMan.goldCountCurrent > 211) { timeToMove = 0.5f; }
            
            float elapsedTime = 0;
            isMoving = true;
        
            origPosition = transform.position;
            targetPosition = origPosition + moveDirection;
            
            // smoothly moves the player to the next tile
            while(elapsedTime < timeToMove) 
            {
                transform.position = Vector2.Lerp(origPosition, targetPosition, (elapsedTime/timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        
            transform.position = targetPosition;
            isMoving = false;    
        }
    }

    private bool rayCheckForCollision(Vector2 currentPos, GameObject raycastObj, string compareTag)
    {
        RaycastHit2D rayHit = Physics2D.Raycast(raycastObj.transform.position, currentPos);

        //check if theres a collision in the moving direction
        if (rayHit.collider != null && rayHit.distance <= 0.1 && rayHit.collider.CompareTag(compareTag))
            return true;
        
        return false;
    }
}
