using UnityEngine;

public class EnemySombra : MonoBehaviour
{
    public float vida = 100f;

    public void RecibirDamage(float damage)
    {
        vida -= damage;

        if (vida <= 0f)
        {
            Destroy(gameObject);
        }
    }
}