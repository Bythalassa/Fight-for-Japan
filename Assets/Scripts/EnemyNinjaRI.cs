using UnityEngine;


public class EnemyNinjaRI : MonoBehaviour
{
    public float damage;

    public GameObject Target1; //add Espadachin
    public GameObject Target2; //add Compita
    public float Speed;

    public bool isAbleToAttack = true;
    public float radiusMovement;
    public float raidusAttack;

    public float cooldownAtaque = 1.5f;
    public float currentTime;


    void Start() { }

    void Update()
    {
        if (!isAbleToAttack)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= cooldownAtaque)
            {
                isAbleToAttack = true;
                currentTime = 0f;
            }
        }

        FollowTarget();
    }

    public void FollowTarget()
    {
        //Logica (que target esta más cerca)
        float distancia1 = Vector3.Distance(transform.position, Target1.transform.position); //ESPADACHIN 
        float distancia2 = Vector3.Distance(transform.position, Target2.transform.position); //COMPITA 

        GameObject targetActual = distancia1 < distancia2 ? Target1 : Target2;
        //si distancia1 es menor elige Target1, si no elige Target2.

        Vector3 targetPos = targetActual.transform.position;
        Vector3 myPos = transform.position;
        float distancia = Vector3.Distance(targetPos, myPos);
        Vector3 direction = (targetPos - myPos).normalized;
        //Guarda la posición del objetivo y la tuya,
        //luego calcula la dirección normalizada (sin magnitud) de ti hacia él.

        //Logica (ataca solo en el radio izquierdo horizontal )
        bool estaALaIzquierda = targetPos.x < myPos.x;

        /*if (Vector3.Distance(targetPos, myPos) < radiusMovement2 && estaALaIzquierda)
        if (distancia < radiusMovement)
            {
                // Solo ataca si está a la izquierda Y dentro del radio de ataque
                if (estaALaIzquierda && distancia < raidusAttack)
                {
                    if (isAbleToAttack)
                    {
                        Debug.Log("Atacando a " + targetActual.name);

                        Espadachin espadachin = targetActual.GetComponent<Espadachin>();
                        Compita compita = targetActual.GetComponent<Compita>();

                        if (espadachin != null) espadachin.Health -= damage;
                        if (compita != null) compita.Health -= damage;

                        isAbleToAttack = false;
                        currentTime = 0f; // 
                    }
            }
            else
                {   // Se mueve hacia el target (cuando no ataca o target está a la derecha)
                    transform.position += direction * Speed * Time.deltaTime;
            }
        }*/
    }
}
