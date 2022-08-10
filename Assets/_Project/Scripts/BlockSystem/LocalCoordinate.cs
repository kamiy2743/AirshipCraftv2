using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    /// <summary>
    /// チャンク内のブロックの座標
    /// </summary>
    public class LocalCoordinate
    {
        public readonly int x;
        public readonly int y;
        public readonly int z;

        public LocalCoordinate(Vector3 position) : this((int)position.x, (int)position.y, (int)position.z) { }
        public LocalCoordinate(int x, int y, int z)
        {
            if (x < 0 || x >= ChunkModel.BlockSide) throw new System.Exception("ローカルx座標が不正です: " + x);
            if (y < 0 || y >= ChunkModel.BlockSide) throw new System.Exception("ローカルy座標が不正です: " + y);
            if (z < 0 || z >= ChunkModel.BlockSide) throw new System.Exception("ローカルz座標が不正です: " + z);

            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
