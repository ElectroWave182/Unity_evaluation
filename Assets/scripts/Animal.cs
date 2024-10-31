using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;


public class Animal: MonoBehaviour
{
	private const float vitesse = 5;
	
	private Transform leJoueur;
	private Vector3 translation;
	
	
    public void Start ()
    {
		translation = Vector3. forward * Animal. vitesse;
		leJoueur = transform. root. Find ("elements"). Find ("joueur");
    }
	
	
    public void Update ()
    {
		// Si l'animal sort du cadre, l'on inverse son mouvement
		
		if
		(
			Math. Abs (transform. position. x) > Joueur. limiteX ||
			Math. Abs (transform. position. z) > Joueur. limiteZ
		)
		{
			transform. Rotate (0, 180, 0);
		}
		
        transform. Translate (this. translation * Time. deltaTime);
		
		
		// S'il va trop haut, on le détruit
		
		if (Math. Abs (transform. position. y) > Joueur. limiteY)
		{
			Destroy (gameObject);
		}
    }
	
	
	public void OnCollisionStay (Collision infos)
	{
		// Nous regardons d'abord la catégorie de l'objet touché (animal ou nourriture)
		
		GameObject objetCollisionne = infos. gameObject;
		
		if (objetCollisionne. name == "joueur" && Joueur. energie)
		{
			transform. position = this. leJoueur. position;
		}
	}
}
