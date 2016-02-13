using UnityEngine;

namespace Movement
{
	public class SetTargetOnClick : MonoBehaviour
	{
	
		public Component compToMove;
		private IObjectToMove objToMove;

		void Awake ()
		{
			if (compToMove != null) {
				objToMove = compToMove.GetComponent<IObjectToMove> ();
			} else {
				Debug.LogError ("SetTargetOnClick.compToMove should be set to the Component that should be moved when clicking");
			}
		}

		void OnMouseDown ()
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
		
			Physics.Raycast (ray, out hit);
		
			if (hit.collider.gameObject == gameObject) {
				Vector3 newTarget = hit.point;
				objToMove.Target = newTarget;
			}
		}
	}
}
