using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour {

    [SerializeField] private float dragSpeed = 2;


    public void Update() {

        if (Input.GetMouseButton(1)) {

            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;
            transform.Translate(-newPosition);
        }  
    }
}
