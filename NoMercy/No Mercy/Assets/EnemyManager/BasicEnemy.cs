using UnityEngine;
using System.Collections;

public class NewBehaviourScript : Enemy {
	float speed = 15.0f;
	GameObject player1, player2;
	float dist1,dist2;
	float x1,x2,x3,y1,y2,y3;
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	protected void Movement(float speed){
		player1 = GameObject.Find ("EzParent");
		player2 = GameObject.Find("RyoParent");
		x1 = player1.transform.localPosition.x;
		x2 = player2.transform.localPosition.x;
		x3 = this.transform.localPosition.x;
		y1 = player1.transform.localPosition.y;
		y2 = player2.transform.localPosition.y;
		y3 = this.transform.localPosition.y;

		dist1 = Mathf.Sqrt();
		dist2 = Mathf.Sqrt();

	}
}
