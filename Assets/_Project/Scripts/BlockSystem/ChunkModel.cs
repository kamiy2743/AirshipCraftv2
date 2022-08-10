using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class ChunkModel
    {
        public const int BlockSide = 4;

        public readonly ChunkCoordinate chunkCoordinate;

        private BlockModel[] blockModels = new BlockModel[BlockSide * BlockSide * BlockSide];

        public ChunkModel(ChunkCoordinate cc)
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
                        SetBlockModel(lc, new BlockModel(bc));
                    }
                }
            }
        }

        private int ToIndex(LocalCoordinate lc)
        {
            return (lc.y * BlockSide * BlockSide) + (lc.z * BlockSide) + lc.x;
        }

        private void SetBlockModel(LocalCoordinate lc, BlockModel blockModel)
        {
            blockModels[ToIndex(lc)] = blockModel;
        }

        public BlockModel GetBlockModel(LocalCoordinate lc)
        {
            return blockModels[ToIndex(lc)];
        }
    }
}
