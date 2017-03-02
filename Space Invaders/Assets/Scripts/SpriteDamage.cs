using UnityEngine;
using System.Collections;

//
// We visualize the damage with sprites
//
public class SpriteDamage : MonoBehaviour {

	// array of sprites to show at the different health levels
	// first is most damaged, last is 100% healthy
	public Sprite[] damageSprites;

 	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// sprite is damaged
	void OnDamaged(float normalisedHealth) {
        // Mathf.FloorToInt() returns the largest integer smaller to or equal to f
        int spriteIndex = Mathf.FloorToInt(normalisedHealth * (damageSprites.Length - 0.01f));
		spriteRenderer.sprite = damageSprites[spriteIndex];
	}

}
