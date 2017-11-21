using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConectionPlataforms : MonoBehaviour {

   
    public Transform startT;
    public Transform endT;

	
	void OnDrawGizmosSelected ()
    {
      

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(startT.position , endT.position);
    }
}
