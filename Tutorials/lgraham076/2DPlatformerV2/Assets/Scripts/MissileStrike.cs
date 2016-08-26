using UnityEngine;
using System.Collections;

public class MissileStrike : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
