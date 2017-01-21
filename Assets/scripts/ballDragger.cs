using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ballDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	Vector3 startPos;
	public Camera mainCamera;
	public Canvas mainCanvas;

	void Start()
	{
		startPos = transform.position;
		Debug.Log (startPos);
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 mouseVector = mainCamera.ScreenToWorldPoint ((Vector3)eventData.position + (Vector3.forward * eventData.pointerDrag.transform.parent.transform.position.z));
		transform.position = new Vector3 (mouseVector.x, mouseVector.y, mouseVector.z /* + eventData.pointerDrag.transform.parent.transform.localPosition.z*/);
		Debug.Log (eventData.pointerDrag.transform.parent.transform.position.z);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPos;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
