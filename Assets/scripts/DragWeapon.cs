using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWeapon : MonoBehaviour
{
	private GameObject forDrag = null;
	
	
	void OnMouseDrag()
	{
		
		//Screen.showCursor = false;
	}
     
	void OnMouseDown()
	{
		
         
	}
     
	void OnMouseUp()

	{

		//
		//Screen.showCursor = true;
         
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			Debug.Log("hit");

			if (hit.collider != null)
			{
				Debug.Log(hit.collider.gameObject.name);
				//hit.collider.attachedRigidbody.AddForce(Vector2.up);
				forDrag = hit.collider.gameObject;
			}
//			else
//			{
//				forDrag = null;
//			}
		}

		if (Input.GetMouseButton(0) && forDrag != null)
		{
			Debug.Log("drag!");
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			forDrag.GetComponent<Transform>().position = new Vector3(pos.x, pos.y, 0f);	
		}
	}
}
