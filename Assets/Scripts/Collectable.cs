using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CoinStateSO coinState;
    [SerializeField] string PlayerLayer = "Player";
    [SerializeField] int coinValue = 1;
    [SerializeField] AudioClip pickUpSound = null;

    public int Index = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerHelper.AreLayerMatching(collision.gameObject.layer, PlayerLayer))
        {
            Debug.Log("collision with " + collision.gameObject.layer);
            Collect();
        }
    }

    private void Collect()
    {
        coinState.OnCoinCollected(coinValue, this);
        AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
        Destroy(gameObject);
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
