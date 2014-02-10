using UnityEngine;
using System.Collections;

public class BetaMovement : MonoBehaviour {
	
	public Animator animator;
	public int health = 100;
	public int maxHealth = 110;
	public float dir;
	public bool faceL = false;
	public Vector3 scale = new Vector3(1f,1f,0f);
	public CharacterController controller;
	public Vector3 newPos = new Vector3(0f, 0f, 0f);
	public float moveSpeed = 10f;
	public float jumpHeight = .4f;
	public float gravity = -1f;
	public int jumps = 0;
	public bool hasGun = false;
	public Quaternion bullRot;
	public float bullDir;
	public Vector3 bulletStart;


	// Use this for initialization
	void Start () {
		controller = transform.parent.GetComponent<CharacterController>();
		animator = this.gameObject.GetComponent<Animator>();
		newPos.x = transform.localPosition.x;
		newPos.y = transform.localPosition.y;
		bullRot = new Quaternion (0f, 0f, 269.5139f, 0f);
	}
	
	// Update is called once per frame
	public virtual void Update () {




		


		if (bullDir < 0 && !faceL) {
			faceL = true;
			scale.x *= -1.0f;
			transform.localScale = scale;
		} 
		else if (bullDir > 0 && faceL) {
			faceL = false;
			scale.x *= -1.0f;
			transform.localScale = scale;
		}
		
		
		
		
		newPos.y += gravity*Time.deltaTime;
		//transform.localPosition = newPos;
		controller.Move (newPos);

	}
	
	void ManageHealth(int h)
	{
		health += h;
		if (health >= maxHealth) {
			health = maxHealth;
		}
		if (health <= 0) {
			health = 0;
			print ("DIE!!!!!!!!!!!!!!!!!!!!!");	
			animator.SetTrigger("setDie");
		}
		print (health);
	}
	protected void Moving(string h, string v, string j){
		if (Input.GetAxis(h) != 0) {
			animator.SetBool("isWalking", true);		
		}
		if (Input.GetButtonUp (h) || Input.GetAxis(h) == 0) {
			animator.SetBool("isWalking", false);		
		}
		
		if (animator.GetBool ("isCrouch")) {
			moveSpeed = 5f;		
		} else
			moveSpeed = 10f;
		bullDir = Input.GetAxis(h)*Time.deltaTime * moveSpeed;
		newPos.x = bullDir;
		//newPos.y += Input.GetAxis ("Vertical")*Time.deltaTime * moveSpeed;
		
		if(Input.GetButtonDown(j) && jumps < 1)
		{
			animator.SetTrigger("startJump");
			newPos.y = jumpHeight;
			jumps += 1;
			print ("Jumped!");
			
			
			
		}
		if (Input.GetButtonDown (v) && Input.GetAxis (v) < 0) {
			animator.SetBool("isCrouch", true);
			if((Input.GetAxis(h) != 0) && animator.GetBool("isCrouch"))
			{
				animator.SetBool("isCrouchWalk", true);
			}
			else if(Input.GetAxis (h) == 0 || Input.GetButtonUp (h)){
				animator.SetBool ("isCrouchWalk", false);
			}
			
		}
		if (Input.GetButtonUp (v) || Input.GetAxis (v) == 0) {
			animator.SetBool("isCrouch", false);	
			animator.SetBool ("isCrouchWalk", false);
		}

		if (controller.isGrounded) {
			jumps = 0;
		}
	}

	protected void ShootCalc(string f, string bulletName){
		if (hasGun) {
			if(Input.GetButton (f)){
				if(animator.GetBool("isCrouch")){
					if(transform.localScale.x > 0f)
						bulletStart = new Vector3(transform.parent.localPosition.x + 1f, transform.parent.localPosition.y + 0.7f, 0f);
					else if(transform.localScale.x < 0f)
						bulletStart = new Vector3(transform.parent.localPosition.x - 1f, transform.parent.localPosition.y + 0.7f, 0f);
				}
				else{
					if(transform.localScale.x > 0)
						bulletStart = new Vector3(transform.parent.localPosition.x + 1f, transform.parent.localPosition.y + 1f, 0f);
					else if(transform.localScale.x < 0)
						bulletStart = new Vector3(transform.parent.localPosition.x - 1f, transform.parent.localPosition.y + 1f, 0f);
				}
				GameObject instance = (GameObject)Instantiate(Resources.Load(bulletName, typeof(GameObject)), bulletStart, bullRot);
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
		

	}
}
