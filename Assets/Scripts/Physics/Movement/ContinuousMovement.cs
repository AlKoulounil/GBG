using UnityEngine;
using System.Collections;

public class ContinuousMovement : MonoBehaviour, IObjectToMove {
	
	private Vector3 mTarget;

	public float speed;
	public float verticalOffset;
	//public Rigidbody rb;

	void Awake() {
		//rb = GetComponent<Rigidbody> ();
	}


	public Vector3 Target
	{
		get{ return mTarget + new Vector3(0, verticalOffset, 0); }set
		{
			mTarget = value + new Vector3(0, verticalOffset, 0);
			
			StopCoroutine("Movement");
			StartCoroutine("Movement", mTarget);
		}
	}
	


	IEnumerator Movement (Vector3 target)
	{

		transform.LookAt (target);
		while(Vector3.Distance (transform.position, target) > Time.deltaTime * speed)
		{
			transform.position = transform.position + transform.forward * Time.deltaTime * speed;
			
			yield return null;
		}
		transform.position = target;
	}
}
