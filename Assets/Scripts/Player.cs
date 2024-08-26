using UnityEngine;
[RequireComponent(typeof(Player))]

public class Player : MonoBehaviour
{
    private int _coinsAmount = 0;
    private Coin _coin;

    public void CollectCoin()
    {
        _coinsAmount++;
        Debug.Log("coin collected");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            CollectCoin();
            coin.DestroyAfterCapture();
        }
    }
}
