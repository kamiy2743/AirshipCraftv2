using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    /// <summary>
    /// ワールド内のブロックの座標
    /// </summary>
    public class BlockCoordinate
    {
        public readonly int x;
        public readonly int y;
        public readonly int z;

        public BlockCoordinate(Vector3 position) : this((int)position.x, (int)position.y, (int)position.z) { }
        public BlockCoordinate(int x, int y, int z)
        {
            if (x < 0 || x >= WorldModel.BlockSideXZ) throw new System.Exception("x座標が不正です: " + x);
            if (y < 0 || y >= WorldModel.BlockSideY) throw new System.Exception("y座標が不正です: " + y);
            if (z < 0 || z >= WorldModel.BlockSideXZ) throw new System.Exception("z座標が不正です: " + z);

            this.x = x;
            this.y = y;
            this.z = z;
        }

        public BlockCoordinate(ChunkCoordinate cc, LocalCoordinate lc) : this(
            cc.x * ChunkModel.BlockSide + lc.x,
            cc.y * ChunkModel.BlockSide + lc.y,
            cc.z * ChunkModel.BlockSide + lc.z
        )
        { }

        public static implicit operator Vector3(BlockCoordinate bc)
        {
            return new Vector3(bc.x, bc.y, bc.z);
        }

        public ChunkCoordinate ToChunkCoordinate()
        {
            return new ChunkCoordinate(
                x / ChunkModel.BlockSide,
                y / ChunkModel.BlockSide,
                z / ChunkModel.BlockSide
            );
        }

        public LocalCoordinate ToLocalCoordinate()
        {
            return new LocalCoordinate(
                x % ChunkModel.BlockSide,
                y % ChunkModel.BlockSide,
                z % ChunkModel.BlockSide
            );
        }
    }
}
