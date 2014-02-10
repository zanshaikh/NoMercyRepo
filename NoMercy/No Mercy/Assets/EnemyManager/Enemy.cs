using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	CharacterController controller;
	public float speed = 8f;
	public int hp = 50;
	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (hp <= 0) {
			Destroy (this.gameObject);		
		}
	}

	public void loseHealth(int howMuchLost){
		hp -= howMuchLost;
	}


}
