using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Joueur: MonoBehaviour
{
	private const float vitesse = 0.02f;
	private const float zoomCamera = 0.013f;
	public  const float limiteX = zoomCamera * 1920;
	public  const float limiteZ = zoomCamera * 1080;
	public  const float limiteY = 35;
	
	public static bool
		energie,
		grand
	;
	
	
	public void Start ()
	{
		Joueur. energie = false;
		Joueur. grand = false;
	}
	
	
    public void Update ()
    {
		// Déplacement seulement si le joueur ne sort pas du cadre
		
        float hautBas      = Input. GetAxis ("Vertical");
		float gaucheDroite = Input. GetAxis ("Horizontal");
		Vector3 translationX = Vector3. right * gaucheDroite * Joueur. vitesse;
		Vector3 translationZ = Vector3. forward * hautBas * Joueur. vitesse;
		
		if
		(
			Math. Abs (transform. position. x + translationX. x) < Joueur. limiteX &&
			Math. Abs (transform. position. z + translationZ. z) < Joueur. limiteZ
		)
		{
			transform. Translate (translationX + translationZ);
		}
    }
	
	
	public void OnCollisionEnter (Collision infos)
	{
		// Nous regardons d'abord la catégorie de l'objet touché (animal ou nourriture)
		
		GameObject objetCollisionne = infos. gameObject;
		
		switch (objetCollisionne. transform. parent. name)
		{
			case "animaux":
				Debug. Log ("Contact avec un animal");
				
				// Si le joueur est grand, il projette l'animal dans le ciel
				if (Joueur. grand)
				{
					Rigidbody corps = objetCollisionne. GetComponent <Rigidbody> ();
					corps. AddForce (0, 100, 0, ForceMode. Impulse);
				}
				
				break;
				
			case "nourriture":
				Debug. Log ("Contact avec de la nourriture");
				
				// La pizza recharge l'énergie du joueur
				if (objetCollisionne. name == "pizza(Clone)")
				{
					Joueur. energie = true;
				}
				
				// Le steak fait grandir le joueur
				else if (objetCollisionne. name == "steak(Clone)" && ! Joueur. grand)
				{
					transform. localScale *= 2;
					Joueur. grand = true;
				}
				
				Destroy (objetCollisionne);
				break;
		}
	}
}
