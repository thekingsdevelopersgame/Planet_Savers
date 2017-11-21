using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMovAnyPos : MonoBehaviour {
    // Nuesta Plataforma
    public Transform plataforma;
    // Puntos De paso De la Plataforma
    public Transform[] Posisiones;
    // Velocidad de la Plataforma
    public float Velocity;

    // Indicador de La Siguiente plataforma
    public int next_point = 0;
	

	void Start () {
        // Setear Plataforma en la Posicion 1
        if (plataforma != null && Posisiones != null) {
            foreach (Transform a in Posisiones) {
                a.parent = null;
            }
            plataforma.position = Posisiones[0].position;
            if (Posisiones.Length - 1  >= next_point + 1) { 
            next_point += 1;
            }
        }
	}


    void FixedUpdate()
    {
        // Cambiar de Posicion Si ah llegado al destino
        if (plataforma.position == Posisiones[next_point].position) {
            if (Posisiones.Length - 1 >= next_point + 1)
            {
                next_point += 1;
            } else if(Posisiones.Length -1 == next_point) {
                next_point = 0;
            }
        }
        // Desplazamiento
        if (plataforma != null && Posisiones != null)
        {
           plataforma.position = Vector3.MoveTowards(plataforma.position, Posisiones[next_point].position, Velocity * Time.deltaTime);

        }
    }
}
