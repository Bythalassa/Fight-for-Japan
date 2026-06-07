using UnityEngine;
using UnityEngine.UIElements; 

public class ColisionMundo : MonoBehaviour
{
    [System.Serializable]
    public class Pared
    //Create a Class/ a structure with specific properties
    //add value to the labels on Inspector to create walls.
    {
        public float xMin; 
        public float xMax;
        public float yMin;
        public float yMax;
    }

    public static ColisionMundo instancia;
    // create a public static BC: rompe la barrera del GameObject:
    // No llamas al Método:  EstaDentroDeUnaPared desde GameObject : objeto → script → método
    // sino : Clase/Script -> NombreVariable -> Método: EstaDentroDeUnaPared -> función para personajes

    public Pared[] paredes = new Pared[10];
    // un array en vez de una Lista porque: los datos no cambian durante el juego

    void Start()
    {
        instancia = this;
        //Sin instancia = this, ColisionMundo.instancia sería null.
        //instancia se crea en null y se asgina el valor en Start
    }

    private void Update()
    {
        GameObject Espadachin= GameObject.Find("Espadachin");
        Vector3 posPlayer = Espadachin.transform.position;

        bool resultado = EstaDentroDeUnaPared(posPlayer.x, posPlayer.y);
    }


    public bool EstaDentroDeUnaPared(float px, float py)
    {
        foreach (Pared p in paredes)
        {
            if (px > p.xMin && px < p.xMax && py > p.yMin && py < p.yMax)
                return true;
        }
        return false;

        /*La Función : EstaDentroDeUnaPared — recibe una posición X = px y Y = py
         * Desde el update se le pasa la posición del Player con Vector3 posPlayer
         * luego se especifica su valor en (x,y).
         * y revisa cada pared del array compuesta por X = xMax/xMin y Y = yMax/yMin.
        
        Verificación para cada pared en el array de paredes
         if (px > p.xMin && px < p.xMax && py > p.yMin && py < p.yMax).
         si (posPlayer.x es mayor al valor min y maximo de x  
         && si posPlayer.y es mayor al valor min y maximo de y ). 
         ENTONCES si colisiona.
            sino no colisiona.
         */

    }

    void OnDrawGizmos()
    /* Un Gizmo es una herramienta visual de depuración que solo se ve en el editor para
     visualizar información: rangos de detección, colisiones, waypoints, etc.
    este metodo es especial para dibujarlos.*/ 

    /*usamos los parametros del inspector xMin, xMax, yMin, yMaX para crearlos */
    {
        if (paredes == null) return;
        Gizmos.color = Color.blue;
        foreach (Pared p in paredes)
        {
            Gizmos.DrawLine(new Vector3(p.xMin, p.yMin), new Vector3(p.xMax, p.yMin));
            Gizmos.DrawLine(new Vector3(p.xMax, p.yMin), new Vector3(p.xMax, p.yMax));
            Gizmos.DrawLine(new Vector3(p.xMax, p.yMax), new Vector3(p.xMin, p.yMax));
            Gizmos.DrawLine(new Vector3(p.xMin, p.yMax), new Vector3(p.xMin, p.yMin));
        }
    }
}