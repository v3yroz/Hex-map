using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private Material defaultMaterial;
    private Material highlightedMaterial;
    private Material neighbourMaterial;
    private Vector3 defaultLocation;
    private float ascendingValue = 0.5f;
    private float neighbourValue;

    private int x;
    private int y;
    private bool highlighted = false;
    private bool ascending = false;
    private bool ascended = false;
    private bool descended = false;
    private bool descending = false;

    public void Start() {
        defaultLocation = gameObject.transform.position;
        neighbourValue = ascendingValue / 2.0f;

    }

    public void Update() {

        var meshRenderer = gameObject.GetComponent<MeshRenderer>();

        if (highlighted) {

            meshRenderer.material = highlightedMaterial;
            if (!ascending && !ascended) {

                ascending = true;
                descended = false;
                descending = false;
            }
        } else {

            meshRenderer.material = defaultMaterial;
            if (ascending || ascended) {

                ascending = false;
                ascended = false;
                descending = true;
            }
        }

        if (ascending) {

            Vector3 currentLocation = gameObject.transform.position;
            Vector3 targetLocation = new Vector3(currentLocation.x, defaultLocation.y + 10f, currentLocation.z);
            Vector3 newLocation = Vector3.Lerp(currentLocation, targetLocation, ascendingValue * Time.deltaTime);
            gameObject.transform.position = newLocation;

            if (targetLocation == currentLocation) {

                ascending = false;
                ascended = true;
            }

        } else if (descending) {

            Vector3 currentLocation = gameObject.transform.position;
            Vector3 newLocation = Vector3.Lerp(currentLocation, defaultLocation, ascendingValue * Time.deltaTime);
            gameObject.transform.position = newLocation;

            if (currentLocation == defaultLocation) {

                descending = false;
                descended = true;
            }

        }

        highlighted = false;
    }

    public void ConfigTile(int x, int y) {

        this.x = x;
        this.y = y;
    }

    public int GetX() {

        return x;
    }

    public int GetY() {

        return y;
    }

    public void SetHighlighted(bool value) {

        highlighted = value;
    }

    public void AddMaterials(Material defaultMaterial, Material highlightedMaterial, Material neighbourMaterial) {

        this.defaultMaterial = defaultMaterial;
        this.highlightedMaterial = highlightedMaterial;
        this.neighbourMaterial = neighbourMaterial;
    }
}
