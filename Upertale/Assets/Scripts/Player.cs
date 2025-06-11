using UnityEngine;
using System.Collections;  // Necessário para corrotinas

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima
    private int currentHealth;  // Vida atual

    public float invincibilityDuration = 1f; // Duração da invencibilidade após ser atingido
    private bool isInvincible = false; // Se o personagem está invencível

    public float moveSpeed = 5f; // Velocidade de movimento do jogador
    private Vector2 moveDirection; // Direção do movimento

    // Start é chamado antes da primeira atualização
    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com o valor máximo
    }

    // Update é chamado a cada frame
    void Update()
    {
        // Movimenta o jogador
        HandleMovement();
    }

    // Função para movimentar o jogador
    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A - D ou setas esquerda/direita
        float moveY = Input.GetAxisRaw("Vertical");   // W - S ou setas cima/baixo
        moveDirection = new Vector2(moveX, moveY).normalized; // Normaliza para evitar movimento mais rápido diagonal

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); // Aplica o movimento
    }

    // Função que recebe dano
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;  // Reduz a vida com base no dano recebido
            currentHealth = Mathf.Max(currentHealth, 0); // Garante que a vida não fique negativa

            // Inicia invencibilidade
            StartCoroutine(Invincibility());
            
            if (currentHealth <= 0)
            {
                Die(); // Se a vida chega a 0, chama a função de morte
            }
        }
    }

    // Método que lida com a morte do jogador
    private void Die()
    {
        Debug.Log("Você morreu!");
        // Adicione aqui o código para quando o personagem morrer (ex: reiniciar a cena, mostrar tela de game over)
    }

    // Corrotina para invencibilidade após o dano
    private IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration); // Aguarda o tempo de invencibilidade
        isInvincible = false;
    }

    // Função chamada quando o personagem colide com um projétil
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Acessa o componente Projectile e obtém o valor do dano
            int damage = collision.gameObject.GetComponent<Projectile>().damage;
            TakeDamage(damage); // Aplica o dano ao jogador
            Destroy(collision.gameObject); // Destroi o projétil
        }
    }
}
