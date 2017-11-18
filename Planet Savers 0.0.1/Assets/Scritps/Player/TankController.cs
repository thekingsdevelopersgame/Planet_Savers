using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {
    public Animator ani;
    public Rigidbody2D rig;
    public SpriteRenderer player_sprite;
    public Animation walking;


    public Animator fxani;
    public AudioSource fxsound_source;
    public float POA ;
    public float Vel_mov;
    public float AJ;
    public string direccion;
    public bool onFloor;

    /*
     Realizar Movimiento
     Llamar a animacion
     Llamar a Fx    
         */

    private void FixedUpdate()
    {
        
        // Ir a Izquierda
        if (Input.GetKey(KeyCode.A))
        {
                if (Vel_mov > 0f) {
                    Vel_mov *= -1f;
                }
                transform.Translate(new Vector2(Vel_mov * Time.deltaTime, 0f));
            if (direccion == "izquierda")
            {
                if (POA < 100f) { 
                    POA += Time.deltaTime * 100f;
                }

            }
            else if (POA > 0f )
            {

                POA -= Time.deltaTime * 200f;
            }
            else
            {
                POA = 0f;
                ani.SetBool("Isright", false);
                direccion = "izquierda";
                ani.SetTrigger("rotate");
            }
        }

        // Ir a Derecha
        if (Input.GetKey(KeyCode.D))
        {
            if (Vel_mov < 0f)
            {
                Vel_mov *= -1f;
            }
            transform.Translate(new Vector2(Vel_mov * Time.deltaTime, 0f));
            if (direccion == "derecha")
            {
                if (POA < 100f)
                {
                    POA += Time.deltaTime * 100f;
                    
                }

            }
            else if (POA > 0f)
            {

                POA -= Time.deltaTime * 200f;
            }
            else {
                POA = 0f;
                direccion = "derecha";
                ani.SetBool("Isright", true);
                ani.SetTrigger("rotate");
            }
        }
        else if (POA > 0f && !Input.GetKey(KeyCode.A))
        {

            POA -= Time.deltaTime * 200f;
        }
        else if (POA < 0f ) {
            POA = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            rig.AddForce(new Vector2(0f, 250f), ForceMode2D.Impulse);
            onFloor = false;
        }
        else {
             //transform.Translate(new Vector2((Vel_mov * (POA / 100f))*Time.deltaTime, 0f));
           
            if (POA < 10f) {
                fxsound_source.volume = 0.05f;
            }
            else
           fxsound_source.volume = (POA/200f);
        //call to move the tank
        ani.speed = 1f + (POA / 50f);
            fxani.speed = 1f + 2*(POA / 50f);
            //call to volumen  sound-move of the tank
        }
 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jumps"))
        {
            onFloor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jumps"))
        {
            onFloor = false;
        }
    }

}
