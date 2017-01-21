using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class sideCannonDrag : MonoBehaviour, IDropHandler
{
	public Sprite loadedCannon;
	public Sprite unloadedCannon;
    public GameObject inGameCannon;

    public boatCannons cannonScript;

    void Start()
    {
        cannonScript = inGameCannon.GetComponent<boatCannons>();
    }
        
	public void OnDrop(PointerEventData eventData)
	{
		GetComponent<Image> ().sprite = loadedCannon;
        cannonScript.ReloadComplete();
	}

    public void CannonShot()
    {
        GetComponent<Image>().sprite = unloadedCannon;
    }
}
