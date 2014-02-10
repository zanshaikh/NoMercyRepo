using UnityEngine;
using System.Collections;

public class RyoMove : BetaMovement {
	

	
	// Update is called once per frame
	public override void Update () {
		Moving ("Horizontal2", "Vertical2", "JumpRyo");
		ShootCalc("FireRyo", "BulletParentPrefab");
		base.Update ();
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
		if (Input.GetButtonDown (v) && Input.GetAxis (v) > 0) {
			animator.SetBool("isCrouch", true);
			print ("crouch!");
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
	

}
