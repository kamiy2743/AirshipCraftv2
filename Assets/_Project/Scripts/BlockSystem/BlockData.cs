using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class BlockData
    {
        public readonly BlockCoordinate blockCoordinate;

        public BlockData(BlockCoordinate bc)
        {
            blockCoordinate = bc;
        }
    }
}
