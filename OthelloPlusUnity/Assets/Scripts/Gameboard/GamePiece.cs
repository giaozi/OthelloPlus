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
    }
    public GamePiece(PieceColor _pieceColor, Tile _tile)
    {
        pieceColor = _pieceColor;
        tile = _tile;
    }
}
