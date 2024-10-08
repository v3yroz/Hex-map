using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField] private Camera mainCamera;

    public void Update() {

        Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 100)) {
            
            if (hit.transform) {

                Tile targetedTile = hit.transform.gameObject.GetComponentInChildren<Tile>();
                
                targetedTile.SetHighlighted(true);
            }
        }
    }
}
