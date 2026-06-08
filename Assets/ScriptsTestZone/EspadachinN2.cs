using UnityEngine;

public class EspadachinN2 : MonoBehaviour
{

    public float Speed;

    void Start()
    {
        
    }

    void Update()
    {
        MovementPlayer();

    }

    public void MovementPlayer()
    {
        //AXix
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0);
        direction.Normalize();

        //→ calcula dirección → se mueve/ transform.position += direction * Speed * Time.deltaTime;

        // crea las variables para la verificación
        float nuevaX = transform.position.x + direction.x * Speed * Time.deltaTime;
        float nuevaY = transform.position.y + direction.y * Speed * Time.deltaTime;

        // Pregunta antes de moverse en X
        if (!ColisionMundo.instancia.EstaDentroDeUnaPared(nuevaX, transform.position.y))
            transform.position = new Vector3(nuevaX, transform.position.y, 0);

        // Pregunta antes de moverse en Y
        if (!ColisionMundo.instancia.EstaDentroDeUnaPared(transform.position.x, nuevaY))
            transform.position = new Vector3(transform.position.x, nuevaY, 0);

    }

}
