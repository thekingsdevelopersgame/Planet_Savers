using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {
    public Animator ani;
    public Rigidbody2D rig;
    public SpriteRenderer player_sprite;



    public float POA ;
    public float Vel_mov;
    public float AJ;

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
            POA += Time.deltaTime * 10f;
            
            if (player_sprite.flipX)
            {
                //call to rotate the tank
            }
            else
            {

            }

        }
        else {
            POA -= Time.deltaTime * 10f;
        }
        rig.velocity = new Vector2(-Vel_mov * POA, 0f);
        //call to move the tank
        //call to volumen  sound-move of the tank
    }
}
