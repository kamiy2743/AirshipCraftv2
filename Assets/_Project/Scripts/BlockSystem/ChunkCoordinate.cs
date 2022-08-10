using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    /// <summary>
    /// ワールド内のチャンクの座標
    /// </summary>
    public class ChunkCoordinate
    {
        public readonly int x;
        public readonly int y;
        public readonly int z;

        public ChunkCoordinate(Vector3 position) : this((int)position.x, (int)position.y, (int)position.z) { }
        public ChunkCoordinate(int x, int y, int z)
        {
            if (x < 0 || x >= WorldModel.ChunkSideXZ) throw new System.Exception("チャンクx座標が不正です: " + x);
            if (y < 0 || y >= WorldModel.ChunkSideY) throw new System.Exception("チャンクy座標が不正です: " + y);
            if (z < 0 || z >= WorldModel.ChunkSideXZ) throw new System.Exception("チャンクz座標が不正です: " + z);

            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
