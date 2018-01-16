using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    public GameObject PickUp;

	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
	}
}
