using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSSelector : MonoBehaviour
{

    // Draggable inspector reference to the Image GameObject's RectTransform.
    public RectTransform selectionBox;

    // This variable will store the location of wherever we first click before dragging.
    private Vector2 initialClickPosition = Vector2.zero;

	[SerializeField]
	private Texture selectTexture;

	Vector3 v1 = Vector3.zero;
	Vector3 v2 = Vector3.zero;

    private Vector3 downMousePosition;


	private bool mouseDown;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
			mouseDown = true;
            downMousePosition = Input.mousePosition;
            RaycastHit hit1;
            Physics.Raycast(Camera.main.ScreenPointToRay(downMousePosition), out hit1);
            v1 = hit1.point;
        }
        else if (Input.GetMouseButtonUp(0))
        {
			mouseDown = false;
            RaycastHit hit2;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit2);
            v2 = hit2.point;
            Debug.Log("Final " + v1 + " - " + v2);
            //Unit[] allUnits = GetAllUnits();
            // foreach (Unit unit in allUnits)
            // {
            //     Vector3 pos = unit.transform.position;
            //     //is inside the box
            //     if (Mathf.Max(v1.x, v2.x) >= pos.x && Mathf.Min(v1.x, v2.x) <= pos.x
            //         && Mathf.Max(v1.z, v2.z) >= pos.z && Mathf.Min(v1.z, v2.z) <= pos.z)
            //     {
            //         //selecte the unit
            //         //Selecte(unit);
            //     }
            // }

        }

		if(mouseDown){
            RaycastHit hit2;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit2);
            v2 = hit2.point;
            Debug.Log("Em Desenho" + v1 + " - " + v2);
			
		}
    }

    void OnGUI()
    {
		// Debug.Log(v1 + " - " + v2);
        // if (v1 != Vector3.zero && v2 != Vector3.zero)
        // {
            GUI.DrawTexture(new Rect(v1.x, v1.y, v2.x - v1.x, v2.y - v1.y), selectTexture); // -
        // }
    }
}
