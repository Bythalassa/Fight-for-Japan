using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Compita : MonoBehaviour
{
    //se mueve 8 direcciones
    // Esta apagadpo hasta apretar key D
    //Cooldown de uso para no impedir que no use Espadachin por lo menos 2 ataques seguidos

    public float speed;
    public float Health;

    private bool CanUse = false;
    public float timeToRespawn = 6.0f;
    private float timeRespawn;
    private SpriteRenderer compita;

    private void Start()
    {

    } 


    private void Update()
    {
       
        if (!CanUse) { compita.enabled = false; }
        else { compita.enabled = true; }

        if (LeerInteraccion()) { CanUse = true; }

        if (!CanUse) 
        {
            timeRespawn += Time.deltaTime;

            if (timeRespawn >= timeToRespawn)
            {
                compita.enabled = true;
            }
            return;
        }
    }

    bool LeerInteraccion()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            CompitaMoves();

        }
        return true;
    }

    private void CompitaMoves()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(x, 0, 0).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
    
    // ataque melee

    // falta script exterior probablemente del multiplicador de daño + key SpaceBar



}
