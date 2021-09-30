using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GamePiece 
{
    PieceColor pieceColor;
    Vector2Int boardLocation;

    public enum PieceColor { White, Black}

    public string name;
    public GamePiece(PieceColor _pieceColor, Vector2Int _boardlocation)
    {
        pieceColor = _pieceColor;
        boardLocation = _boardlocation;
    }
}
