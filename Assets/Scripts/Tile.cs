using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private Material defaultMaterial;
    private Material highlightedMaterial;
    private Material neighbourMaterial;
    private Vector3 defaultLocation;
    private float ascendingValue = 0.1f;
    private float ascendingHeight = 10f;
    private float neighbourHeight;
    private GameObject text;
    private TextMesh t;

    private int x;
    private int y;
    private bool highlighted = false;
    private bool neighbour = false;
    private bool ascending = false;
    private bool ascended = false;
    private bool descended = false;
    private bool descending = false;

    public void Start() {
        defaultLocation = gameObject.transform.position;
        neighbourHeight = ascendingHeight / 2.0f;

    }

    public void Update() {

        var meshRenderer = gameObject.GetComponent<MeshRenderer>();

        if (highlighted || neighbour) {

            if (highlighted) {

                meshRenderer.material = highlightedMaterial;
            } else if (neighbour) {

                meshRenderer.material = neighbourMaterial;
            }

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
            Vector3 targetLocation = currentLocation;

            if (highlighted) {

                targetLocation.y = ascendingHeight;
            } else if (neighbour) {

                targetLocation.y = neighbourHeight;
            }

            Vector3 newLocation = Vector3.Lerp(currentLocation, targetLocation, ascendingValue);

            gameObject.transform.position = newLocation;
            t.transform.localPosition = newLocation;

            if (targetLocation == currentLocation) {

                ascending = false;
                ascended = true;
            }

        } else if (descending) {

            Vector3 currentLocation = gameObject.transform.position;

            Vector3 newLocation = Vector3.Lerp(currentLocation, defaultLocation, ascendingValue);

            gameObject.transform.position = newLocation;
            t.transform.localPosition = newLocation;

            if (currentLocation == defaultLocation) {

                descending = false;
                descended = true;
            }

        }

        highlighted = false;
        neighbour = false;
    }

    public void ConfigTile(int x, int y, int tileNumber) {

        this.x = x;
        this.y = y;

        text = new GameObject();
        t = text.AddComponent<TextMesh>();
        text.name = "tile_" + tileNumber + "_text";

        t.text = x + ", " + y;
        t.fontSize = 10;
        t.color = Color.black;

        t.transform.localEulerAngles += new Vector3(90, 0, 0);
        t.transform.localPosition += gameObject.transform.position;

        Renderer textRenderer = t.GetComponent<Renderer>();
        
        Vector3 offset = new Vector3(textRenderer.bounds.size.x / 2, 0f, textRenderer.bounds.size.y / 2);
        t.transform.localPosition -= offset;
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

    public void SetNeighbour(bool value) {

        neighbour = value;
    }

    public void AddMaterials(Material defaultMaterial, Material highlightedMaterial, Material neighbourMaterial) {

        this.defaultMaterial = defaultMaterial;
        this.highlightedMaterial = highlightedMaterial;
        this.neighbourMaterial = neighbourMaterial;
    }
}
