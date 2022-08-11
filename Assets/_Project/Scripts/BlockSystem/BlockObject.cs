using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class BlockObject : System.IDisposable
    {
        public readonly BlockData BlockData;
        public readonly GameObject BlockGameObject;

        public BlockObject(BlockData blockData, GameObject blockGameObject)
        {
            BlockData = blockData;
            BlockGameObject = blockGameObject;
            BlockGameObject.transform.position = BlockData.blockCoordinate;
        }

        public void Dispose()
        {
            GameObject.Destroy(BlockGameObject);
        }
    }
}
