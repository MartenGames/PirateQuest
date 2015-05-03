﻿using UnityEngine;
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

	//Animator anim;
	PlayerMobilityScript playerMovement;
	bool isDead;
	bool damaged;

	void Awake () {
		//anim = GetComponent <Animator> ();
		playerMovement = GetComponent <PlayerMobilityScript> ();
		currentHealth = startingHealth;
		healthSlider.value = currentHealth;
	}
	
	void Update () {
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		// Reset the damaged flag.
		damaged = false;
	}

	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;
		
		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		
		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;
		
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}

	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
		
		// Turn off any remaining shooting effects.
		//playerShooting.DisableEffects ();
		
		// Tell the animator that the player is dead.
		//anim.SetTrigger ("Die");
		
		// Turn off the movement and shooting scripts.
		playerMovement.enabled = false;
		//playerShooting.enabled = false;
	}  
}
