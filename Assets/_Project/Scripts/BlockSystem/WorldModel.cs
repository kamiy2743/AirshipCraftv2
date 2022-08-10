using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class WorldModel
    {
        public const int ChunkSideXZ = 5;
        public const int ChunkSideY = 1;

        public const int BlockSideXZ = ChunkSideXZ * ChunkModel.BlockSide;
        public const int BlockSideY = ChunkSideY * ChunkModel.BlockSide;

        private ChunkModel[] chunkModels = new ChunkModel[ChunkSideXZ * ChunkSideXZ * ChunkSideY];

        public WorldModel()
        {
            for (int x = 0; x < ChunkSideXZ; x++)
            {
                for (int y = 0; y < ChunkSideY; y++)
                {
                    for (int z = 0; z < ChunkSideXZ; z++)
                    {
                        var cc = new ChunkCoordinate(x, y, z);
                        SetChunkModel(cc, new ChunkModel(cc));
                    }
                }
            }
        }

        private int ToIndex(ChunkCoordinate cc)
        {
            return (cc.y * ChunkSideXZ * ChunkSideXZ) + (cc.z * ChunkSideXZ) + cc.x;
        }

        private void SetChunkModel(ChunkCoordinate cc, ChunkModel chunkModel)
        {
            chunkModels[ToIndex(cc)] = chunkModel;
        }

        public ChunkModel GetChunkModel(ChunkCoordinate cc)
        {
            return chunkModels[ToIndex(cc)];
        }

        public BlockModel GetBlockModel(BlockCoordinate bc)
        {
            var cc = bc.ToChunkCoordinate();
            var lc = bc.ToLocalCoordinate();
            var chunkModel = GetChunkModel(cc);
            return chunkModel.GetBlockModel(lc);
        }
    }
}
