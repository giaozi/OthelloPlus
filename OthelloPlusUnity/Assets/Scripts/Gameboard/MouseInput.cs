using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using WebsocketConnection;

public class MouseInput : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;
    private Grid grid;

    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tile hoverTile = null;

    private Vector3Int previousMousePos = new Vector3Int();

    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }
    void Update()
    {
        Vector3Int mousePos = GetMouseTilePosition();

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Debug.Log("Tile Position @" + GetMouseTilePosition());
            //WebsocketManager.WebsocketSendText(Input.mousePosition.ToString());
        }



        if (!mousePos.Equals(previousMousePos))
        {
            interactiveMap.SetTile(previousMousePos, null); // Remove old hoverTile
            interactiveMap.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

    }

    Vector3Int GetMouseTilePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);

     
    }

    /*ClickedOnTile ()
    {

        Debug.Log("clicked on " + )

    }*/
}
