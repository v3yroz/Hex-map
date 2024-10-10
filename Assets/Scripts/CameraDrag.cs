using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour {

    [SerializeField] private float dragSpeed = 2;

    //Tu się kamera przesuwa
    
    public void Update() {

        if (Input.GetMouseButton(1)) {

            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;

            transform.Translate(-newPosition);
        }  
    }

    public void SetInitialCameraPosition(Vector2 rtCorner) {

        Vector3 startPoint = new Vector3(rtCorner.x / 2, 50f, rtCorner.y / 2);
        transform.position = startPoint;
    }
}
