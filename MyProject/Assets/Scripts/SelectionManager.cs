using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public bool SelectionMode;
    public Selectable Selected;
	// Update is called once per frame
	void Update () {
	    if (SelectionMode)
	    {
	        if (Input.GetMouseButtonDown(0))
	        {
	            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	            RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                    if (hit.collider != null)
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
	    }
	}

    public void SetSelectionMode(bool mode)
    {
        SelectionMode = mode;
    }
}
