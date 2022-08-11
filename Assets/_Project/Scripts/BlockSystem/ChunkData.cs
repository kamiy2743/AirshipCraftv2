using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class ChunkData
    {
        public const int BlockSide = 4;

        public readonly ChunkCoordinate chunkCoordinate;

        private BlockData[] blockDataArray = new BlockData[BlockSide * BlockSide * BlockSide];

        public ChunkData(ChunkCoordinate cc)
        {
            chunkCoordinate = cc;

            for (int x = 0; x < BlockSide; x++)
            {
                for (int y = 0; y < BlockSide; y++)
                {
                    for (int z = 0; z < BlockSide; z++)
                    {
                        var lc = new LocalCoordinate(x, y, z);
                        var bc = new BlockCoordinate(cc, lc);
                        SetBlockData(lc, new BlockData(bc));
                    }
                }
            }
        }

        private int ToIndex(LocalCoordinate lc)
        {
            return (lc.y * BlockSide * BlockSide) + (lc.z * BlockSide) + lc.x;
        }

        private void SetBlockData(LocalCoordinate lc, BlockData blockData)
        {
            blockDataArray[ToIndex(lc)] = blockData;
        }

        public BlockData GetBlockData(LocalCoordinate lc)
        {
            return blockDataArray[ToIndex(lc)];
        }
    }
}
