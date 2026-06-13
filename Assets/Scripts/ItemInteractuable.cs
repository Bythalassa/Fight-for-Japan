using UnityEngine;

public class objetoInteractuable : MonoBehaviour
{

    //Fix (el jump en el radio de la lampara (add radius/))

    public Espadachin player;
    public float timeToRespawn = 2.0f;
    public float distanceToInteract = 1.0f;
    //yo quiero que sea menor el radio de interaccion

    private float timeRespawn;
    private bool interactuable = true;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    { 

        // 2/3 de esta logica tiene que remplazarse 

        // se actualiza cada frame 
        // si la distancia es menor a la distancia de interaccion y no esta en el suelo
        // detecta la interaccion y lo prende a true 

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

        /*
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= distanceToInteract && !player.estaEnSuelo)
        {
            interactuable = false;
            sprite.enabled = false;
            timeRespawn = 0.0f;

            player.Jump(); // el salto actúa como "obtener" el item
        }
        */ //necesita cambiarse a reacciona a un ataque

    }
}
