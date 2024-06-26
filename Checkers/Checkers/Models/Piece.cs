﻿using Checkers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Piece
    {
        public Color Color { get; }
        public Enums.Type Type { get; set; }
        public Piece() 
        {
            Color = Color.None;
            Type = Enums.Type.None;
        }

        public Piece(Color pieceColor, Enums.Type pieceType = Enums.Type.Normal)
        {
            Color = pieceColor;
            Type = pieceType;
        }
    }
}
