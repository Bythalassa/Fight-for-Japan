using UnityEngine;
using UnityEngine.InputSystem;


public class Compita : MonoBehaviour
{
    //Debug.Log() en cada paso clave para ver qué valor tiene cada variable en cada momento.

    public float speed;
    public float Health;

    private bool isAvailable;
    public int timeToRespawn = 6;
    private float timeRespawn;
    private SpriteRenderer compita;

    /*


    
     */

    private void Start()
    {
        compita = GetComponent<SpriteRenderer>();
        compita.enabled = false;
        isAvailable = false;
    } 


    private void Update()
    {
        //Añadir en espadachin: (si compita.enable = true entonces Espadachin.enable false)
        
        LeerInteraccion();
        CompitaMoves();

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

    /*customizar :
    add compita.enable && accion de ataque 1 (do damage) && hacia la direccion presionada
    limitar boton de direcciones a arrows
    por ahora solo que aparezca luego se hila lo demás  */

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
            Debug.Log("isAvailable antes  del toggle: " + isAvailable);
            if (timeRespawn >= timeToRespawn)
            {
                isAvailable = !isAvailable;

                Debug.Log("isAvailable después del toggle: " + isAvailable);
                //rpta isAvailable después del toggle: False

                if (isAvailable)
                {
                    compita.enabled = true;
                    //Debug.Log("timeRespawn is " + timeRespawn); 0
                    //si se resetea pero cuando se persiona f es true -> nada lo cambia a false !isAvailable
                }

                else if (!isAvailable)
                {
                    compita.enabled = false;
                    timeRespawn = 0;
                }
            }
        }

    }

    bool CompitaMoves()
    {

        float x = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(x, 0, 0).normalized;
        transform.position += direction * speed * Time.deltaTime;
        //limitar movimiento a arrows. 

        return true;
    }

}
