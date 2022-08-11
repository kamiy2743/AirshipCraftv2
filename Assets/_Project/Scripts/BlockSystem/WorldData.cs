using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class WorldData
    {
        public const int ChunkSideXZ = 5;
        public const int ChunkSideY = 1;

        public const int BlockSideXZ = ChunkSideXZ * ChunkData.BlockSide;
        public const int BlockSideY = ChunkSideY * ChunkData.BlockSide;

        public IReadOnlyCollection<ChunkData> ChunkDataArray => chunkDataArray;
        private readonly ChunkData[] chunkDataArray = new ChunkData[ChunkSideXZ * ChunkSideXZ * ChunkSideY];

        public WorldData()
        {
            for (int x = 0; x < ChunkSideXZ; x++)
            {
                for (int y = 0; y < ChunkSideY; y++)
                {
                    for (int z = 0; z < ChunkSideXZ; z++)
                    {
                        var cc = new ChunkCoordinate(x, y, z);
                        SetChunkData(cc, new ChunkData(cc));
                    }
                }
            }
        }

        private int ToIndex(ChunkCoordinate cc)
        {
            return (cc.y * ChunkSideXZ * ChunkSideXZ) + (cc.z * ChunkSideXZ) + cc.x;
        }

        private void SetChunkData(ChunkCoordinate cc, ChunkData chunkData)
        {
            chunkDataArray[ToIndex(cc)] = chunkData;
        }

        public ChunkData GetChunkData(ChunkCoordinate cc)
        {
            return chunkDataArray[ToIndex(cc)];
        }

        public BlockData GetBlockData(BlockCoordinate bc)
        {
            var cc = bc.ToChunkCoordinate();
            var lc = bc.ToLocalCoordinate();
            var chunkData = GetChunkData(cc);
            return chunkData.GetBlockData(lc);
        }
    }
}
