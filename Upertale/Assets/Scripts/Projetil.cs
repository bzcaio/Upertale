using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f;

    void Start()
    {
        Destroy(gameObject, tempoDeVida); // Destroi o projétil após um tempo
    }

    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime); // Move o projétil
    }
}