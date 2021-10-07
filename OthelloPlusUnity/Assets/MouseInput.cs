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
            Debug(GetMousePosition();)


    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint;
                   
        {
            Vector3 _mousePosition = Input.mousePosition;

           return grid.WorldToCell(_mousePosition)

        }
    }

    /*ClickedOnTile ()
    {

        Debug.Log("clicked on " + )

    }*/
}
