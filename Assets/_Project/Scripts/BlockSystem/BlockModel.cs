using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class BlockModel
    {
        public readonly BlockCoordinate blockCoordinate;

        public BlockModel(BlockCoordinate bc)
        {
            blockCoordinate = bc;
        }
    }
}
