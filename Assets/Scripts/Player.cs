using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private const string isRunningKey = "isRunning";
    private const string isJumpingKey = "isJumping";
    private const string isDeadKey = "isDead";
    private const string isAttackingKey = "isAttacking";
    private const string GroundLayer = "Ground";
    private const string LadderLayer = "Ladder";
    [SerializeField] string EnemyLayer = "Enemy";
    [SerializeField] string ObstacleLayer = "Obstacles";

    private Animator animatorController = null;
    private CapsuleCollider2D playerCollider = null;
    private BoxCollider2D playerFeetCollider = null;
    private Movement movement = null;

    private bool isClimbing = false;
    private int nbKeyPressedToClimb = 0;
    private Vector2 currentVelocity = Vector2.zero;
    private Vector2 currentClimbVelocity = Vector2.zero;

    [SerializeField] HealthStateSO health;
    [SerializeField] PlayerDataSO playerData;


    void Start()
    {
        animatorController = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponentInChildren<BoxCollider2D>();
        movement = GetComponent<Movement>();
    }


    void Update()
    {
        if (health.IsDead) { return; }

        movement.MovePlayer(currentVelocity);
        UpdatePlayerClimbingState();
    }

    private void UpdatePlayerClimbingState()
    {
        UpdateClimbState();
        if (isClimbing)
        {
            movement.HandleClimbState(currentClimbVelocity);
        }
        AnimateClimbing(isClimbing);
        UpdatePlayerGravity(isClimbing);
    }
    private void UpdateClimbState()
    {
        var isOnLadder = IsOverlappingLadder();
        if (isOnLadder && nbKeyPressedToClimb > 0)
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
            nbKeyPressedToClimb = 0;
        }
    }

    private void UpdatePlayerGravity(bool shouldTurnOffGravity)
    {
        if (shouldTurnOffGravity)
        {
            movement.TurnOffGravity();
        }
        else
        {
            movement.TurnOnGravity();
        }
    }

    private bool IsOverlappingLadder()
    {
        return playerFeetCollider.IsTouchingLayers(LayerMask.GetMask(LadderLayer));
    }

    private void AnimateClimbing(bool shouldClimb)
    {
        animatorController.SetBool("isClimbing", shouldClimb);
    }

    //INPUT
    public void OnMove(InputValue value)
    {
        Debug.Log("onMove");
        if (health.IsDead) { return; }
        var moveVector = value.Get<Vector2>();
        currentVelocity = moveVector;
        HanleRunState(moveVector);

        SetPlayerDirection(moveVector);
    }

    private void HanleRunState(Vector2 velocity)
    {
        var isRunning = velocity.x != 0;
        animatorController.SetBool(isRunningKey, isRunning);
    }

    private void SetPlayerDirection(Vector2 velocity)
    {
        var scale = transform.localScale;
        var velocityX = math.abs(velocity.x);
        if (velocityX > 0)
        {
            var direction = Mathf.Sign(velocity.x);
            scale.x = direction * math.abs(scale.x);
            transform.localScale = scale;
        }
    }

    public void OnFire()
    {
        Attack();
    }

    private void Attack()
    {
        animatorController.SetTrigger(isAttackingKey);
    }

    public void OnJump()
    {
        var shouldJump = playerFeetCollider.IsTouchingLayers(LayerMask.GetMask(GroundLayer));
        if (shouldJump)
        {
            animatorController.SetTrigger(isJumpingKey);
            movement.Jump();
        }
    }

    public void OnClimb(InputValue value)
    {
        var moveVector = value.Get<Vector2>();
        currentClimbVelocity = moveVector;
        nbKeyPressedToClimb++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerHelper.AreLayerMatching(collision.collider.gameObject.layer, EnemyLayer))
        {
            Debug.Log("collision with " + collision.gameObject.layer);
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerHelper.AreLayerMatching(collision.gameObject.layer, ObstacleLayer))
        {
            Debug.Log("collision with " + collision.gameObject.layer);
            Die();
        }
    }

    private void Die()
    {
        health.IsAlive = false;
        OnPlayerDeath();
    }

    private void OnPlayerDeath()
    {
        animatorController.SetTrigger(isDeadKey);
    }

}
