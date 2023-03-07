using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsPacmanMovement : MonoBehaviour
{
    //Velocidad de PacMan
    public float speed = 0.4f;

    //Referencia al Rigidbody del jugador
    private Rigidbody2D theRB;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Rigidbody
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Si pulso la tecla izquierda
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //Movemos al personaje en esa direcci�n
            theRB.velocity = new Vector2(-speed, 0f);
        }
        //Si pulso la tecla derecha
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //Movemos al personaje en esa direcci�n
            theRB.velocity = new Vector2(speed, 0f);
        }
        //Si pulso la tecla abajo
        if(Input.GetKey(KeyCode.DownArrow))
        {
            //Movemos al personaje en esa direcci�n
            theRB.velocity = new Vector2(0f, -speed);
        }
        //Si pulso la tecla arriba
        if(Input.GetKey(KeyCode.UpArrow))
        {
            //Movemos al personaje en esa direcci�n
            theRB.velocity = new Vector2(0f, speed);
        }
    }
}
