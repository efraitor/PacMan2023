using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    //Velocidad inicial del fantasma
    public float speed = 4f;
    //Necesitamos un array de posiciones llamado Waypoints(puntos de ruta). Cada fantasma puede tener un n�mero de puntos de ruta distintos
    public Transform[] waypoints;
    //Inicializo la posici�n en la que se encuentra el fantasma en la posici�n 0 del array. Luego este valor ir� variando
    int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Distancia al punto de ruta, entre la posici�n actual y el punto de ruta hacia el que se est� dirigiendo
        float distanceToWaypoint = Vector2.Distance((Vector2)transform.position, (Vector2)waypoints[currentWaypoint].position);

        //Si la distancia hasta el punto de ruta es menor que 0.1 es que he llegado a la posici�n
        if(distanceToWaypoint < 0.1f)
        {
            //Si el n�mero del punto en el que est� el fantasma es menor que los que hay guardados
            if(currentWaypoint < waypoints.Length - 1)
            {
                //Avanzamos al siguiente punto
                currentWaypoint++;
            }
            //Si por el contrario el n�mero del punto en el que est� el fantasma es igual o mayor que los que hay guardados
            else
            {
                //Reseteamos al primer punto de los guardados
                currentWaypoint = 0;
            }

            //Nueva direcci�n para calcular la animaci�n si cambiamos de direcci�n: hacia donde va - donde est� ahora
            Vector2 newDirection = waypoints[currentWaypoint].position - transform.position;
            //Cambiamos las animaciones
            GetComponent<Animator>().SetFloat("DirX", newDirection.x);
            GetComponent<Animator>().SetFloat("DirY", newDirection.y);
        }
        //Y si no ha llegado al destino el fantasma
        else
        {
            //Creo un vector para moverme desde donde est� el fanstama ahora mismo, hasta el siguiente Waypoint a una velocidad dada
            Vector2 newPos = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            //Hacemos que se mueva a la posici�n que le toca
            GetComponent<Rigidbody2D>().MovePosition(newPos);
        }
    }

    //Reacci�n de los fantasmas al choque con otros objetos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto contra el que ha chocado est� etiquetado como Player(MsPacman)
        if(collision.CompareTag("Player"))
        {
            //Destruye a MsPacman(obteniendo de este GameObject su c�digo, para poder coger de este el m�todo MsPacmanDead())
            collision.gameObject.GetComponent<MsPacmanMovement>().MsPacmanDead();
        }
    }
}
