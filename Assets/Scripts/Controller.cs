using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField] private Camera mainCamera;
    [SerializeField] private TileSpawner spawner;

    public void Update() {

        //Skrypt do myszki żeby podświetliło kafelek i sąsiadów

        Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 100)) {
            
            if (hit.transform) {

                Tile targetedTile = hit.transform.gameObject.GetComponentInChildren<Tile>();
                
                targetedTile.SetHighlighted(true);

                List<GameObject> allTiles = spawner.GetList();

                int tileX = targetedTile.GetX();
                int tileY = targetedTile.GetY();

                foreach (GameObject tile in allTiles) {

                    var tileScript = tile.GetComponentInChildren<Tile>();

                    if (tileScript.GetX() % 2 == 0 || tileScript.GetX() == 0) {

                        if (tileScript.GetX() == tileX - 1 || tileScript.GetX() == tileX + 1) {

                            if (tileScript.GetY() == tileY + 1 || tileScript.GetY() == tileY) {

                                tileScript.SetNeighbour(true);
                            }
                        } else if (tileScript.GetX() == tileX) {

                            if (tileScript.GetY() == tileY + 1 || tileScript.GetY() == tileY - 1) {

                                tileScript.SetNeighbour(true);
                            }
                        }

                    } else {

                        if (tileScript.GetX() == tileX - 1 || tileScript.GetX() == tileX + 1) {

                            if (tileScript.GetY() == tileY - 1 || tileScript.GetY() == tileY) {

                                tileScript.SetNeighbour(true);
                            }
                        } else if (tileScript.GetX() == tileX) {

                            if (tileScript.GetY() == tileY + 1 || tileScript.GetY() == tileY - 1) {

                                tileScript.SetNeighbour(true);
                            }
                        }
                    }
                }
            }
        }

    }
}
