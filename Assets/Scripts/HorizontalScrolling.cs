using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScrolling : MonoBehaviour
{

    [SerializeField] float scrollingRate;

    private Rigidbody2D rigidbody2D = null;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.right * scrollingRate;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
