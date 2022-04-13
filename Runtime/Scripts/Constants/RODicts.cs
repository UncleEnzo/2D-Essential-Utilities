using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using static Nevelson.Utils.Enums;

namespace Nevelson.Utils
{
    public static class RODicts
    {
        public static ReadOnlyDictionary<Direction, float> DirectionRotation = new ReadOnlyDictionary<Direction, float>(new Dictionary<Direction, float>()
        {
           { Direction.UP_LEFT, 0},
           { Direction.UP_RIGHT, 270},
           { Direction.LEFT, 45},
           { Direction.RIGHT, -135},
           { Direction.UP, -45},
           { Direction.DOWN, 135},
           { Direction.DOWN_LEFT, 90},
           { Direction.DOWN_RIGHT, 180},
        });

        public static ReadOnlyDictionary<Direction, Vector2> DirectionVectorCardinal = new ReadOnlyDictionary<Direction, Vector2>(new Dictionary<Direction, Vector2>()
        {
            { Direction.LEFT, Vector2.left },
            { Direction.RIGHT, Vector2.right },
            { Direction.UP, Vector2.up },
            { Direction.DOWN, Vector2.down },
            { Direction.NONE, Vector2.zero},
        });
        public static ReadOnlyDictionary<Direction, Vector2> DirectionVector = new ReadOnlyDictionary<Direction, Vector2>(new Dictionary<Direction, Vector2>()
        {
            { Direction.LEFT, Vector2.left },
            { Direction.RIGHT, Vector2.right },
            { Direction.UP, Vector2.up },
            { Direction.DOWN, Vector2.down },
            { Direction.UP_LEFT, new Vector2(-1,1) },
            { Direction.UP_RIGHT, new Vector2(1,1) },
            { Direction.DOWN_LEFT, new Vector2(-1,-1) },
            { Direction.DOWN_RIGHT, new Vector2(1,-1)},
            { Direction.NONE, Vector2.zero},
        });

        public static ReadOnlyDictionary<Direction, Direction> OppositeDirections = new ReadOnlyDictionary<Direction, Direction>(new Dictionary<Direction, Direction>()
        {
            { Direction.UP, Direction.DOWN },
            { Direction.UP_LEFT, Direction.DOWN_RIGHT },
            { Direction.LEFT, Direction.RIGHT },
            { Direction.DOWN_LEFT, Direction.UP_RIGHT },
            { Direction.DOWN, Direction.UP },
            { Direction.DOWN_RIGHT, Direction.UP_LEFT },
            { Direction.RIGHT, Direction.LEFT },
            { Direction.UP_RIGHT, Direction.DOWN_LEFT },
            { Direction.NONE, Direction.NONE },
        });

        public static ReadOnlyDictionary<Direction, OppositeDirs> OppositeDirectionNeighbors = new ReadOnlyDictionary<Direction, OppositeDirs>(new Dictionary<Direction, OppositeDirs>()
        {
            { Direction.UP, new OppositeDirs(Direction.DOWN_LEFT, Direction.DOWN, Direction.DOWN_RIGHT) },
            { Direction.UP_LEFT, new OppositeDirs(Direction.DOWN, Direction.DOWN_RIGHT, Direction.RIGHT) },
            { Direction.LEFT, new OppositeDirs(Direction.UP_RIGHT, Direction.RIGHT, Direction.DOWN_RIGHT) },
            { Direction.DOWN_LEFT, new OppositeDirs(Direction.UP, Direction.UP_RIGHT, Direction.RIGHT) },
            { Direction.DOWN, new OppositeDirs(Direction.UP_LEFT, Direction.UP, Direction.UP_RIGHT) },
            { Direction.DOWN_RIGHT, new OppositeDirs(Direction.UP, Direction.UP_LEFT, Direction.LEFT) },
            { Direction.RIGHT, new OppositeDirs(Direction.UP_LEFT, Direction.LEFT, Direction.DOWN_LEFT) },
            { Direction.UP_RIGHT, new OppositeDirs(Direction.DOWN, Direction.DOWN_LEFT, Direction.LEFT) },
            { Direction.NONE, new OppositeDirs(Direction.NONE, Direction.NONE, Direction.NONE) },
        });

        public struct OppositeDirs
        {
            public Direction dirOppositeLeftNeighbor;
            public Direction dirOpposite;
            public Direction dirOppositeRightNeighbor;

            public OppositeDirs(Direction dirOppositeLeftNeighbor, Direction dirOpposite, Direction dirOppositeRightNeighbor) : this()
            {
                this.dirOppositeLeftNeighbor = dirOppositeLeftNeighbor;
                this.dirOpposite = dirOpposite;
                this.dirOppositeRightNeighbor = dirOppositeRightNeighbor;
            }
        }
    }
}