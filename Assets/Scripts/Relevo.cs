using UnityEngine;
using UnityEngine.InputSystem;

public class Relevo : MonoBehaviour
{
    private bool isAvailable;
    public float timeToRespawn = 0.001f;
    private float timeRespawn;
    private SpriteRenderer compita;
    private SpriteRenderer espadachin;

    private void Start()
    {
        compita = GetComponent<SpriteRenderer>();
        espadachin = GetComponent<SpriteRenderer>();

        compita.enabled = false; 
        espadachin.enabled = false;
        isAvailable = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //Añadir en espadachin: (si compita.enable = true entonces Espadachin.enable false)

        LeerInteraccion();

        if (!isAvailable)
        {
            timeRespawn += Time.deltaTime;
            Debug.Log("compita is not Available, he is eating chifles");

            //only a debug
            if (timeRespawn >= timeToRespawn)
            {
                Debug.Log("compita can stop eating chifles if F is pressed");
            }
            return;
        }

    }

    // recomendaciones para esta logica optimizada: 
    //Compita, tener una referencia pública al SpriteRenderer de Espadachin, y viceversa
    //El relevo contradictorio — cuando compita.enabled = true, espadachin.enabled debe ser false
    //y viceversa. Siempre opuestos.

    private void LeerInteraccion()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            //Debug.Log("timeRespawn es: " + timeRespawn);
            //issue request : si el problema es que timeRespawn no llegó a 6, o si llegó a 6 pero algo más falla 
            // rpta : timeRespawn es: 6.000244  Entonces timeRespawn >= timeToRespawn es true y entra al if.       

            //c# = está definido como asociativo por la derecha && El script declara isAvailable = false
            //luego de presionar de K se actualiza el valor de la variable a = falase.
            //por lo tanto identifica isAvailable y ahora lee de izquierda a derecha  
            //es como forzar preparar limonada y servir un vaso 

            //falta optimizacion de spawn + ataque hilar dsp 

            if (timeRespawn >= timeToRespawn)
            {
                isAvailable = !isAvailable;

                if (isAvailable)
                {
                    compita.enabled = true;
                }

                else if (!isAvailable)
                {
                    compita.enabled = false;
                    timeRespawn = 0;
                }
            }
        }
    }

   







}
