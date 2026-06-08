using UnityEngine;

public class objetoInteractuable : MonoBehaviour
{

    //Fix (el jump en el radio de la lampara (add radius/))

    public Espadachin player;
    public float timeToRespawn = 2.0f;
    public float distanceToInteract = 4.0f;

    private float timeRespawn;
    private bool interactuable = true;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!interactuable)
        {
            timeRespawn += Time.deltaTime;

            if (timeRespawn >= timeToRespawn)
            {
                interactuable = true;
                sprite.enabled = true;
            }
            return;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= distanceToInteract && player.SaltoEjecutado)
        {
            interactuable = false;
            sprite.enabled = false;
            timeRespawn = 0.0f;

            player.Jump(); // el salto actúa como "obtener" el item
        }
    }
}
