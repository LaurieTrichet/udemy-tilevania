using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    private Rigidbody2D enemyRigidbody = null;
    private BoxCollider2D directionCollider = null;
    private PolygonCollider2D enemyCollider = null;
    private const string GroundLayer = "Ground";
    public bool isActivated = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        directionCollider = GetComponent<BoxCollider2D>();
        enemyCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCollider.enabled = isActivated;
        enemyRigidbody.velocity = Vector2.right * speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( LayerHelper.AreLayerMatching(collision.gameObject.layer, GroundLayer))
        {
            var scale = transform.localScale;
            scale.x = -scale.x;
            transform.localScale = scale;
            speed = -speed;
        }
    }


}
