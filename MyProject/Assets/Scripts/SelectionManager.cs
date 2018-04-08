using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    public bool SelectionMode;
    public Selectable Selected;

    public PlayerScript Player;
	// Update is called once per frame
	void Update () {
	    if (SelectionMode)
	    {
	        if (Input.GetMouseButtonDown(0))
	        {
	            Ray ray = Game.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);
	            RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                    if (hit.collider != null && EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject())
                    {
                        var gameObject = hit.collider.gameObject;
                        var selectable = gameObject.GetComponent<Selectable>();
                        if (selectable != null)
                        {
                            if (selectable.Equals(Selected))
                            {
                                Selected.IsSelected = false;
                                Selected.OnDeselected();
                                Selected = null;
                            }
                            else
                            {
                                if (Selected != null)
                                {
                                    Selected.IsSelected = false;
                                    Selected.OnDeselected();
                                }
                                selectable.OnSelected();
                                Selected = selectable;
                                selectable.IsSelected = true;
                            }

                        }

                    }
            }
            else if (Input.GetMouseButtonDown(1))
	        {
	            Ray ray = Game.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);
	            RaycastHit hit;
	            if (Physics.Raycast(ray, out hit))
	                if (hit.collider != null && EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject())
	                {
	                    var gameObject = hit.collider.gameObject;
	                    var selectable = gameObject.GetComponent<Selectable>();
	                    if (selectable != null && selectable.gameObject.GetComponentInChildren<Resource>() == null && Selected.GetComponentInChildren<Resource>()!=null)
	                    {
	                        var resource = Selected.gameObject.GetComponentInChildren<Resource>();
                            resource.transform.SetParent(selectable.gameObject.transform);
	                        resource.gameObject.transform.position = selectable.gameObject.transform.position;
                            resource.gameObject.transform.Translate(0,1,0);
                            Selected.OnDeselected();
	                        Selected = null;
	                    }
	                }

	        }

	        if (Input.GetKeyDown(KeyCode.G) && Selected != null)
	        {
	            Player.transform.position = Selected.transform.position;
                Player.transform.Translate(0, 1.5f, 0);
	        }
	    }
	}

    public void SetSelectionMode(bool mode)
    {
        SelectionMode = mode;
    }
}
