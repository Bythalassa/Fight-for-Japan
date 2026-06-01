using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public float Health;
    public float Speed;

    public float MaxTime = 10;
    public float currentTime;

    public bool isAbilityAblive = true;
    void Start()
    {

    }
    void Update()
    {
        if (!isAbilityAblive)
        {
            TimerToDoSmt();
        }
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

    public void Shoot()
    {
        //Input.mouse
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position); 
        direction.z = 0;
        direction.Normalize();


        /*if(Input.GetMouseButtonDown(0))
        {
          GameObject bullet = Instantiate(/*BulletPrefab ,  transform.position,Quaternion.identity);   
          bullet.transform.up = direction;
        }
              */  
                }

   
    public void SimpleAttack()
    {
        if (isAbilityAblive)
        {
            //->hago lo que tenga que hacer
            isAbilityAblive = false;
        }
    }
    public void TimerToDoSmt()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= MaxTime)
        {
            //-> ejecutar algo
            isAbilityAblive = true;

            currentTime = 0;
        }
    }
}