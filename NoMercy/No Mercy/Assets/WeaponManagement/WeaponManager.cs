using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		///BetaMovement p = other.gameObject.GetComponent<BetaMovement>();
		//
		BetaMovement p = other.gameObject.GetComponentInChildren<BetaMovement>();
		p.hasGun = true;
		Destroy (this.gameObject);

		/*RyoMove r = other.gameObject.GetComponentInChildren<RyoMove>();
		r.hasGun = true;
		Destroy (this.gameObject);*/


	}
}
