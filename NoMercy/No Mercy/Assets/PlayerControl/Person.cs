using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	
	Vector3 newPos = new Vector3(0f, 0f, 0f);
	public float moveSpeed = 10f;
	CharacterController controller;
	public float jumpHeight = .4f;
	public float gravity = -1f;
	int jumps = 0;
	public bool hasGun = false;
	Quaternion bullRot;
	float bullDir;
	float hp = 100f;

	
	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
		newPos.x = transform.localPosition.x;
		newPos.y = transform.localPosition.y;
		bullRot = new Quaternion (0f, 0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

		bullDir = Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed;
		newPos.x = bullDir;
		//newPos.y += Input.GetAxis ("Vertical")*Time.deltaTime * moveSpeed;
		
		if(Input.GetButtonDown("Jump") && jumps < 1)
		{

				newPos.y = jumpHeight;
				jumps += 1;
				print ("Jumped!");
				

			
		}
		
		if (!(controller.isGrounded)) {
			newPos.y += gravity*Time.deltaTime;	
		}
		
		if (controller.isGrounded) {
			jumps = 0;
			print("isGrounded");
		}

		if (hasGun) {
			if(Input.GetButton ("Fire1")){

				GameObject instance = (GameObject)Instantiate(Resources.Load("BulletPrefab", typeof(GameObject)), transform.localPosition, bullRot);
				BulletManager bull = instance.GetComponent<BulletManager>();
				if(bullDir > 0)
				{
					bull.dir = 1;
				}
				else if(bullDir < 0)
				{
					bull.dir = -1;
				}
					
			}		
		}
		//transform.localPosition = newPos;
		controller.Move (newPos);


	}
	
	
}
