using UnityEngine;

public class Espadachin : MonoBehaviour
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

        transform.position += direction * Speed * Time.deltaTime;

    }

}
