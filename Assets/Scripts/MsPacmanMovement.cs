using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsPacmanMovement : MonoBehaviour
{
    //Velocidad de PacMan
    public float speed = 0.4f;

    //Referencia al Rigidbody del jugador
    private Rigidbody2D theRB;
    //Referencia al Animator del jugador
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Rigidbody
        theRB = GetComponent<Rigidbody2D>();
        //Inicializamos el Animator
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Si pulso la tecla izquierda
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //Movemos al personaje en esa dirección
            theRB.velocity = new Vector2(-speed, 0f);
        }
        //Si pulso la tecla derecha
        if(Input.GetKey(KeyCode.RightArrow))
        {
            //Movemos al personaje en esa dirección
            theRB.velocity = new Vector2(speed, 0f);
        }
        //Si pulso la tecla abajo
        if(Input.GetKey(KeyCode.DownArrow))
        {
            //Movemos al personaje en esa dirección
            theRB.velocity = new Vector2(0f, -speed);
        }
        //Si pulso la tecla arriba
        if(Input.GetKey(KeyCode.UpArrow))
        {
            //Movemos al personaje en esa dirección
            theRB.velocity = new Vector2(0f, speed);
        }

        //ANIMATIONS
        //Dependiendo del valor de la velocidad del Rigidbody en X, MsPacman mirará a la derecha o a la izquierda
        anim.SetFloat("DirX", theRB.velocity.x);//Accedemos al Animator de MsPacman, y aplicando un cambio en su parámetro DirX, conseguimos el cambio en la animación
        //Para la Y aplicaríamos exactamente lo mismo que para la X
        anim.SetFloat("DirY", theRB.velocity.y);
    }

    //Método para hacer que MsPacman muera
    public void MsPacmanDead()
    {
        //Destruimos a MsPacman
        Destroy(gameObject);
    }
}
