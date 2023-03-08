using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    //Velocidad inicial del fantasma
    public float speed = 4f;
    //Necesitamos un array de posiciones llamado Waypoints(puntos de ruta). Cada fantasma puede tener un número de puntos de ruta distintos
    public Transform[] waypoints;
    //Inicializo la posición en la que se encuentra el fantasma en la posición 0 del array. Luego este valor irá variando
    int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Distancia al punto de ruta, entre la posición actual y el punto de ruta hacia el que se está dirigiendo
        float distanceToWaypoint = Vector2.Distance((Vector2)transform.position, (Vector2)waypoints[currentWaypoint].position);

        //Si la distancia hasta el punto de ruta es menor que 0.1 es que he llegado a la posición
        if(distanceToWaypoint < 0.1f)
        {
            //Si el número del punto en el que está el fantasma es menor que los que hay guardados
            if(currentWaypoint < waypoints.Length - 1)
            {
                //Avanzamos al siguiente punto
                currentWaypoint++;
            }
            //Si por el contrario el número del punto en el que está el fantasma es igual o mayor que los que hay guardados
            else
            {
                //Reseteamos al primer punto de los guardados
                currentWaypoint = 0;
            }

            //Nueva dirección para calcular la animación si cambiamos de dirección: hacia donde va - donde está ahora
            Vector2 newDirection = waypoints[currentWaypoint].position - transform.position;
            //Cambiamos las animaciones
            GetComponent<Animator>().SetFloat("DirX", newDirection.x);
            GetComponent<Animator>().SetFloat("DirY", newDirection.y);
        }
        //Y si no ha llegado al destino el fantasma
        else
        {
            //Creo un vector para moverme desde donde está el fanstama ahora mismo, hasta el siguiente Waypoint a una velocidad dada
            Vector2 newPos = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            //Hacemos que se mueva a la posición que le toca
            GetComponent<Rigidbody2D>().MovePosition(newPos);
        }
    }

    //Reacción de los fantasmas al choque con otros objetos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto contra el que ha chocado está etiquetado como Player(MsPacman)
        if(collision.CompareTag("Player"))
        {
            //Destruye a MsPacman(obteniendo de este GameObject su código, para poder coger de este el método MsPacmanDead())
            collision.gameObject.GetComponent<MsPacmanMovement>().MsPacmanDead();
        }
    }
}
