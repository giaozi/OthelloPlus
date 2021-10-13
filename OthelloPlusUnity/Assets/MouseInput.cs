using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using WebsocketConnection;

public class MouseInput : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;
    private Grid grid;
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Debug.Log("Tile Position @" + GetMouseTilePosition());
            WebsocketManager.WebsocketSendText(Input.mousePosition.ToString());
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
