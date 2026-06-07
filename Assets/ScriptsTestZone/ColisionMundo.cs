using UnityEngine;

public class ColisionMundo : MonoBehaviour
{
    [System.Serializable]
    public class Pared
    //Create a Class/ a structure with specific properties
    //add value to the labels on Inspector to create Fucking walls
    //Need a test to get used to the workflow
    {
        public float xMin;
        public float xMax;
        public float yMin;
        public float yMax;
    }

    public static ColisionMundo instancia;
    // crear una variable publica "instancia" facilita la llamada al script "ColisionMundo". 
    // Con instancia → busca directo, desde cualquier script
    // ColisionMundo.instancia.EstaDentroDeUnaPared(x, y);

    public Pared[] paredes;

    void Start()
    {
        instancia = this;
    }

    public bool EstaDentroDeUnaPared(float px, float py)
    {
        foreach (Pared p in paredes)
        {
            if (px > p.xMin && px < p.xMax && py > p.yMin && py < p.yMax)
                return true;
        }
        return false;
    }

    void OnDrawGizmos()
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