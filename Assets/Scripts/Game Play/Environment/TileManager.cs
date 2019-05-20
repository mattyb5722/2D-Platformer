using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public static TileManager instance = null;

    private float endOfTiles = -1.6f;
    private float lastHeigth = -1f;
    private Vector3 screenEdge;

    private List<GameObject> tiles = new List<GameObject>();
    private GameObject [] tileSets;
    public GameObject startingBlock;

    private Camera mainCamera;

    // Use this for initialization
    void Awake () {
        if (instance == null) { instance = new TileManager(); } 
        else { Destroy(gameObject); }

        mainCamera = Camera.main;
        tileSets = GameObject.FindGameObjectsWithTag("Ground");
        spawnStartingBlock();
    }


    private void spawnStartingBlock() {
        GameObject temp = Instantiate(startingBlock);
        temp.transform.position = new Vector3(-8f, lastHeigth, 0);
        tiles.Add(temp);
    }


    public void Update() {
        screenEdge = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        if (endOfTiles < screenEdge.x) {
            SpawnTile();
        }

        foreach (GameObject tileSet in tiles) {
            if (tileSet != null) {
                float childLength = 0;

                foreach (Transform child in tileSet.transform) {
                    if (child.tag == "Tile") {
                        childLength += 1;
                    }
                }
                childLength *= .8f;

                if (tileSet.transform.position.x + childLength < (-1 * screenEdge.x) + (2 * mainCamera.transform.position.x)) { // Left border of the screen
                    Destroy(tileSet);
                }
            }
        }
    }

    private void SpawnTile() {
        float y = Random.Range(lastHeigth - 2f, lastHeigth + 2f);
        y = Mathf.Clamp(y, lastHeigth - 2f, lastHeigth + 2f);
        y = Mathf.Clamp(y, -1 * screenEdge.y, screenEdge.y-4);

        int i = Random.Range(0, tileSets.Length - 1);
        GameObject newTile = Instantiate(tileSets [i]);

        float gap = Random.Range(1f, 4f);

        newTile.transform.position = new Vector3(endOfTiles + gap, y);
        tiles.Add(newTile);

        float j = 0;
        foreach (Transform child in newTile.transform) {
            if (child.tag == "Tile") { j += 1; }
        }
        j *= .8f;
        endOfTiles += j + gap;
        lastHeigth = y;
    }
}
