using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GamePiece 
{
    public enum PieceColor { Empty, White, Black }

    public PieceColor pieceColor = PieceColor.Empty;
    public Vector2Int boardLocation;
    public Tile tile = null;



    public string name;

    public GamePiece(PieceColor _pieceColor)
    {
        pieceColor = _pieceColor;

        if(_pieceColor == PieceColor.White)  
            tile = Resources.Load<Tile>("Tiles/Tile_White");
        if (_pieceColor == PieceColor.Black)
            tile = Resources.Load<Tile>("Tiles/Tile_Black");
        if (_pieceColor == PieceColor.Empty)
            tile = null;
    }

}
