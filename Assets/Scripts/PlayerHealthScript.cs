using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;							// The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);	// The colour the damageImage is set to, to flash.

	Animator anim;
	PlayerMobilityScript playerMovement;
	bool isDead;
	bool damaged;

	void Awake () {
		anim = GetComponent <Animator> ();
		playerMovement = GetComponent <PlayerMobilityScript> ();
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
