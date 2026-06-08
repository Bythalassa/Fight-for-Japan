using UnityEngine;


public class Espadachin : MonoBehaviour
{

    public SpriteRenderer sprite;
    public float Health;
    public float Speed;

    //Valores de Jump()
    private float altura = -0.5f;
    public float gravedad = 0.5f;
    private float velocidadY;



    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && altura <= -0.5f)
        {
            jump();
        }

        gravityController();
    }

    public void MoventPlayer()
    {
        //AXix
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0);
        direction.Normalize();

        transform.position += direction * Speed * Time.deltaTime;

    }

    void jump()
    {
        velocidadY = 12.0f;
    }
    void gravityController()
    {
        sprite.transform.localPosition = new Vector3(0.0f, altura, 0.0f);

        velocidadY -= gravedad * Time.deltaTime;

        altura += velocidadY * Time.deltaTime;

        if (velocidadY < 0.0f)
        {
            transform.position += sprite.transform.localPosition + new Vector3(0.0f, 0.5f, 0.0f);
            sprite.transform.localPosition = new Vector3(0.0f, -0.5f, 0.0f);
            altura = -0.5f;
        }

        if (altura <= -0.5f)
        {
            velocidadY = 0.0f;
            altura = -0.5f;
        }
    }








}
