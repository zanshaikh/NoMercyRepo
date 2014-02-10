using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {
	GameObject player;
	GameObject playerChild;
	Vector3 shotLoc;
	public float damage = 10f;
	public float range = 15f;
	Vector3 newPos;
	public int dir = 0;
	Vector3 scale;
	public float bullSpeed = 15f;
	public float bullSpeedRun = 20f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("EzParent");
		playerChild = GameObject.Find ("Ez");
		shotLoc = player.transform.localPosition;
		newPos = transform.localPosition;
		//newPos = new Vector3 (shotLoc.x, shotLoc.y, 0f);
		scale = playerChild.transform.localScale;



	}
	
	// Update is called once per frame
	void Update () {

		if ((dir > 0)/* && transform.localPosition.x < (shotLoc.x + (range))*/) {
			newPos.x += (bullSpeedRun * dir)* Time.deltaTime;
			transform.localPosition = newPos;
		}
		else if((dir < 0)/* && transform.localPosition.x > (shotLoc.x - range)*/)
		        {
			newPos.x += (bullSpeedRun * dir)* Time.deltaTime;
			transform.localPosition = newPos;
		}

		else if(dir == 0f){
			if(scale.x > 0)
			{
				//if (transform.localPosition.x < (shotLoc.x + (range))) {
					newPos.x += (bullSpeed * 1f) * Time.deltaTime;
					transform.localPosition = newPos;
				//}
			}
			else if(scale.x < 0)
			{
				//if(transform.localPosition.x > (shotLoc.x - range))
				//{
				newPos.x += (bullSpeed * -1f)* Time.deltaTime;
					transform.localPosition = newPos;
				//}
			}

		}

		if(transform.localPosition.x > (shotLoc.x + range) || transform.localPosition.x < (shotLoc.x - range))
		{
			Destroy(this.gameObject);
		}



	
	}

	void OnTriggerEnter(Collider o)
	{

		Enemy e = o.gameObject.GetComponent<Enemy>();
		e.loseHealth(5);
		Destroy (this.gameObject);
	}
}
