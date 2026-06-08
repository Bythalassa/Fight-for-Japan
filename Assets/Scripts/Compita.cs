using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Compita : MonoBehaviour
{
    public List<Vector3> posiciones;
    public List<Vector3> startPosition;
    public float speed = 20.0f;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            addPoint(mousePosition);
        }

        if (posiciones.Count > 0) MoveObject();
    }
    private void addPoint(Vector2 point)
    {
        startPosition.Add(posiciones.Count > 0 ? posiciones[posiciones.Count - 1] : gameObject.transform.position);
        posiciones.Add(point);
    }

    private void MoveObject()
    {
        Vector3 dir = (posiciones[0] - startPosition[0]).normalized;

        transform.position = Vector3.MoveTowards(transform.position, posiciones[0], speed * Time.deltaTime);

        if (transform.position == posiciones[0])
        {
            posiciones.RemoveAt(0);
            startPosition.RemoveAt(0);
        }
    }

    //funcion de target damage a enemy sombra + c 
    // ataque melee


   // falta script exterior probablemente del multiplicador de daño + key SpaceBar




}
