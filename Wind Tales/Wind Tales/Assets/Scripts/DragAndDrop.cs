using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	private bool selected;
	private bool isOver = false;
	public GameObject Canvas;


	// Use this for initialization
	void Start()
	{
		Camera.main.gameObject.transform.position = Canvas.transform.position;
		Camera.main.orthographicSize = Canvas.transform.position.y;

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && isOver)
		{
			selected = true;
			Debug.Log("selected");
		}
		if (selected)
		{
			Vector2 cursorPOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector2(cursorPOS.x, cursorPOS.y);
		}
		if (Input.GetMouseButtonUp(0))
		{
			selected = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("enter");
		isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("leave");
		isOver = false;
	}
}
