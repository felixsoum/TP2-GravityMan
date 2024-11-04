using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindAnyObjectByType<LifetimeFruits>().CollectFruit();

        Player player = collision.gameObject.GetComponent<Player>();
        player.CollectFruit();
        Destroy(gameObject);
    }
}
