using UnityEngine;
using System.Collections;

public class RyoMove : BetaMovement {
	

	
	// Update is called once per frame
	public override void Update () {
		Moving ("Horizontal2", "Vertical2", "JumpRyo");
		ShootCalc("FireRyo", "BulletParentPrefab");
		base.Update ();
	}
	

}
