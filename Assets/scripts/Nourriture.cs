using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Nourriture: MonoBehaviour
{
	private float tempsDebut;
	
	
	public void Start ()
	{
		tempsDebut = Time. time;
	}
	
	
	// Destruction après 15 s. depuis la création de l'objet
	
    public void Update ()
    {
        if (Time. time - this. tempsDebut > 15)
		{
			Debug. Log ("Nourriture détruite");
			Destroy (gameObject);
		}
    }
}
