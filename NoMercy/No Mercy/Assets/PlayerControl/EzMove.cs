using UnityEngine;
using System.Collections;

public class EzMove : BetaMovement {


	
	// Update is called once per frame
	public override void Update () {
		Moving ("Horizontal", "Vertical", "JumpEz");
		ShootCalc("FireEz", "BulletParentPrefab");
		base.Update ();
	}
}
