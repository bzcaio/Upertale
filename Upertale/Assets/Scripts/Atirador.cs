using UnityEngine;

public class Atirador : MonoBehaviour
{
    public GameObject projetilPrefab;  // Prefab do projétil
    public Transform pontoDeDisparo;   // Local de spawn do projétil
    public Transform jogador;          // Referência ao jogador
    public float intervaloDeDisparo = 1f; // Tempo entre os disparos
    private float tempoUltimoDisparo;

    void Update()
    {
        if (jogador != null)
        {
            // Calcular a direção para o jogador
            Vector2 direcao = (jogador.position - transform.position).normalized;

            // Rotacionar o canhão para mirar no jogador
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo);

            // Disparar automaticamente se o tempo permitir
            if (Time.time >= tempoUltimoDisparo + intervaloDeDisparo)
            {
                Disparar(direcao);
                tempoUltimoDisparo = Time.time;
            }
        }
    }

    void Disparar(Vector2 direcao)
    {
        // Criar o projétil na posição do ponto de disparo
        GameObject projetil = Instantiate(projetilPrefab, pontoDeDisparo.position, pontoDeDisparo.rotation);

        // Aplicar movimento ao projétil (caso tenha Rigidbody2D)
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direcao * 10f; // Ajuste a velocidade conforme necessário
        }
    }
}