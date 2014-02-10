using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public CharacterController controller;
	public float speed = 8f;
	public int hp = 50;
	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	public virtual void Update () {




		if (hp <= 0) {
			Destroy (this.gameObject);		
		}
	}

	public void loseHealth(int howMuchLost){
		hp -= howMuchLost;
	}

	protected void Movement(float speed){

	}

	protected void Attack(int damage){

	}


}
