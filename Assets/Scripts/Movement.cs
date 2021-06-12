using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int speed = 1;

    [SerializeField] int climbSpeed = 1;
    private Rigidbody2D playerRigidBody = null;

    [SerializeField]
    float forceJump = 1;

    [SerializeField] float initialGravity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        initialGravity = playerRigidBody.gravityScale;
    }


    public void MovePlayer(Vector2 moveVector)
    {
        var climbVector = new Vector2(moveVector.x * speed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = climbVector;
    }

    public void HandleClimbState(Vector2 moveVector)
    {
        var climbVector = new Vector2(playerRigidBody.velocity.x, moveVector.y * climbSpeed);
        playerRigidBody.velocity = climbVector;
    }

    public void Jump()
    {
        var jumpV = new Vector2(0, forceJump);

        playerRigidBody.AddForce(jumpV, ForceMode2D.Impulse);
    }

    public void TurnOnGravity()
    {
        playerRigidBody.gravityScale = initialGravity;
    }

    public void TurnOffGravity()
    {
        playerRigidBody.gravityScale = 0f;
    }
}
