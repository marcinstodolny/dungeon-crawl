﻿using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Interactive : Entity
    {
        protected Interactive(Square square) : base(square)
        {

        }
        public void RemoveFromBoard()
        {
            Square.Interactive = null;
            Square.Status = SquareStatus.Floor;
        }
    }
}