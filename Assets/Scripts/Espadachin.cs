using UnityEngine;

public class Espadachin : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float Health;
    public float Speed;

    private bool estaEnSuelo = true;
    private float velocidadY = 0f;
    public float gravedad = 9.8f;
    public float fuerzaSalto = 5f;

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

    void ManejarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            velocidadY = fuerzaSalto;
            estaEnSuelo = false;
        }

        // Aplicar gravedad
        velocidadY -= gravedad * Time.deltaTime;
        transform.position += new Vector3(0, velocidadY * Time.deltaTime, 0);

        // Suelo en Y = 0 (ajusta este valor a tu escena)
        if (transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            velocidadY = 0f;
            estaEnSuelo = true;
        }
    }

    //funcion de target damage a enemy sombra
    //+ do damage con key x
    //ataque con espada




}