using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;  // Dano do projétil
    public float velocidade = 10f; // Velocidade do projétil
    public float tempoDeVida = 3f; // Tempo de vida do projétil

    void Start()
    {
        Destroy(gameObject, tempoDeVida); // Destroi o projétil após um tempo
    }

    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime); // Move o projétil
    }

    // Detecta colisão com outros objetos
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o projétil colidiu com o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aplica o dano no jogador
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject); // Destroi o projétil após a colisão
        }
        else
        {
            Destroy(gameObject); // Destroi o projétil se colidir com qualquer outra coisa
        }
    }
}
