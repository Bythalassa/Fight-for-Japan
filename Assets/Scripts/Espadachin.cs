using UnityEngine;

public class Espadachin : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float Health;
    public float Speed;

    public bool estaEnSuelo = true;
    private float velocidadY = 0f;
    public float gravedad = 9.8f;
    public float fuerzaSalto = 5f;
    public float alturaPiso = -2.5f;
   
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoverPlayer();
        ManejarSalto();
    }

    void MoverPlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(x, 0, 0).normalized;
        transform.position += direction * Speed * Time.deltaTime;
    }

    /*
    */
    void ManejarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
            Jump();

        velocidadY -= gravedad * Time.deltaTime;
        transform.position += new Vector3(0, velocidadY * Time.deltaTime, 0);

        if (transform.position.y <= alturaPiso)
        {
            transform.position = new Vector3(transform.position.x, alturaPiso, transform.position.z);
            velocidadY = 0f;
            estaEnSuelo = true;
        }
    }

    public void Jump()
    {
        if (!estaEnSuelo) return; // evita doble salto si se llama externamente
        velocidadY = fuerzaSalto;
        estaEnSuelo = false;
    }


    //agregar funcion de ataque melee y hacer el ataque con KEY.X
    //EL ATAQUE ES CON ESPADA




}