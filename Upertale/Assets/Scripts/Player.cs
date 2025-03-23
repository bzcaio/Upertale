using UnityEngine;

public class Movimento2D : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private Vector2 movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        movimento = new Vector2(moveX, moveY).normalized; 
    }

    void FixedUpdate()
    {
        rb.velocity = movimento * velocidade;
    }
}
