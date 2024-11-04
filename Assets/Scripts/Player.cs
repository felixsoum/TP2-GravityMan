using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] string nextLevelName;

    private Vector3 originalPosition;
    Camera playerCamera;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    private int fruitCounter;

    internal void CollectFruit()
    {
        // Après avoir collecté 5 fruits
        if (++fruitCounter == 5)
        {
            // Si la variable nextLevelName est vide
            if (string.IsNullOrEmpty(nextLevelName))
            {
                // Fin du jeu
                FindAnyObjectByType<TMP_Text>().color = Color.yellow;
            }
            else
            {
                // Sinon aller à une autre scène
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }

    internal void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Invoke(nameof(RespawnPlayer), 0.5f);
    }

    private void RespawnPlayer()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = originalPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        playerCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Faire une copie de la position de la camera
        var cameraPos = playerCamera.transform.position;
        // Modifier le x pour s'aligner avec le joueur (en x seulement)
        cameraPos.x = transform.position.x;
        // Remettre la nouvelle position dans la camera
        playerCamera.transform.position = cameraPos;

        // 1 is on pese a droite, -1 a gauche, sinon 0
        float x = Input.GetAxisRaw("Horizontal");

        var velocity = rb.velocity;
        velocity.x = 2f * x;
        rb.velocity = velocity;

        if (x != 0)
        {
            // on pese a droite, x = 1, alors 1 < 0 = false
            // on pese a gauche, x = -1, alors -1 < 0 = true
            spriteRenderer.flipX = x < 0;

            //if (x > 0)
            //{
            //    spriteRenderer.flipX = false;
            //}
            //else
            //{
            //    spriteRenderer.flipX = true;
            //}
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }
    }
}
