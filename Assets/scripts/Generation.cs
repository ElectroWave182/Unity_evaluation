using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Generation: MonoBehaviour
{
	private System. Random r;
	private Transform
		elements,
		invocations
	;
	private Transform []
		animaux,
		nourriture
	;
	
	
    public void Start ()
    {
		// Initialisation des attributs
		
		r = new System. Random ();
		
		elements = transform. Find ("elements");
		invocations = transform. Find ("invocations");
		
		
		// Animaux possibles
		
		Transform cerf = elements. Find ("cerf");
		Transform renard = elements. Find ("renard");
		
		this. animaux = new Transform [] {cerf, renard};
		
		
		// Nourriture possible
		
		Transform pizza = elements. Find ("pizza");
		Transform steak = elements. Find ("steak");
		
		this. nourriture = new Transform [] {pizza, steak};
		
		
		// Invocations toutes les secondes
		
        InvokeRepeating ("lancerInvocation", 0, 1);
    }
	
	
	public void lancerInvocation ()
	{
		this. invoquer (this. animaux);
		this. invoquer (this. nourriture);
	}
	
	
	private void invoquer (Transform [] entitesPossibles)
	{
		// Invocation d'une entité
		
		Debug. Log ("Entité invoquée");
		
		// Type aléatoire
		Transform entite = entitesPossibles [(int) Math. Round (r. NextDouble ())];
		
		Transform invocation = Instantiate (entite);
		
		
		// Rangement dans sa catégorie (animal ou nourriture)
		
		if (entitesPossibles == this. animaux)
		{
			invocation. SetParent (this. invocations. Find ("animaux"));
		}
		else if (entitesPossibles == this. nourriture)
		{
			invocation. SetParent (this. invocations. Find ("nourriture"));
		}
		
		
		// Position aléatoire
		
		float x = Convert. ToSingle (r. NextDouble () * 2 - 1) * Joueur. limiteX;
		float z = Convert. ToSingle (r. NextDouble () * 2 - 1) * Joueur. limiteZ;
		
		invocation. position = new Vector3 (x, 0, z);
		
		
		// Orientation aléatoire
		
		float y = Convert. ToSingle ((int) (r. NextDouble () * 4) * 90);
		
		invocation. eulerAngles = new Vector3 (0, y, 0);
		
		
		invocation. gameObject. SetActive (true);
	}
}
