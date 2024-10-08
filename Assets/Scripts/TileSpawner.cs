using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    [SerializeField] private GameObject tile;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material neighbourMaterial;
    [SerializeField] private float tileOffset = 3;
    [SerializeField] private float maxTilesX;
    [SerializeField] private float maxTilesY;

    private Vector3 currentSpawnPoint;
    private int tileCounter = 0;
    private MeshRenderer meshRenderer;
    private Mesh tileMesh;
    private List<GameObject> tileList;
    private float tileSizeX;
    private float tileSizeY;

    void Start() {
        
        meshRenderer = tile.GetComponent<MeshRenderer>();
        tileMesh = tile.GetComponent<MeshFilter>().sharedMesh;

        tileSizeX = meshRenderer.bounds.size.x;
        tileSizeY = meshRenderer.bounds.size.z;

        tileList = new List<GameObject>();
        currentSpawnPoint = new Vector3(0, 1, 0);

        for (int i = 1; i <= maxTilesX; i++) {

            for (int j = 1; j <= maxTilesY; j++) {

                GameObject newTile = new GameObject();

                newTile.transform.name = "tile_" + tileCounter;
                newTile.transform.localScale = new Vector3(5, 5, 5);
                newTile.transform.localRotation = tile.transform.localRotation;

                newTile.AddComponent<MeshFilter>();
                var newTileMeshFilter = newTile.GetComponent<MeshFilter>();
                newTileMeshFilter.mesh = tileMesh;

                newTile.AddComponent<MeshRenderer>();
                var newTileMeshRenderer = newTile.GetComponent<MeshRenderer>();
                newTileMeshRenderer.sharedMaterial = defaultMaterial;

                newTile.AddComponent<MeshCollider>();
                newTile.GetComponent<MeshCollider>().sharedMesh = tileMesh;

                newTile.AddComponent<Tile>();
                Tile tileScript = newTile.GetComponent<Tile>();

                tileScript.AddMaterials(defaultMaterial, highlightedMaterial, neighbourMaterial);


                tileList.Add(newTile);
                newTile.transform.position = new Vector3(currentSpawnPoint.x, currentSpawnPoint.y, currentSpawnPoint.z);
                tileScript.ConfigTile(i - 1, j - 1, tileCounter);

                currentSpawnPoint.z += tileSizeY / 2 + tileOffset;
                tileCounter++;
            }

            currentSpawnPoint.x += tileSizeX / 2 + tileOffset;
            if (i % 2 == 0) {

                currentSpawnPoint.z = 0;
            } else {

                currentSpawnPoint.z = (tileSizeY / 2 + tileOffset) / 2;
            }

        }
    }

    public List<GameObject> GetList() {

        return tileList;
    }
}
