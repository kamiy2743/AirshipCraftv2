using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSystem
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private GameObject blockObjectPrefab;

        // Start is called before the first frame update
        void Start()
        {
            var world = new WorldData();

            foreach (var chunkData in world.ChunkDataArray)
            {
                foreach (var blockData in chunkData.BlockDataArray)
                {
                    var blockGameObject = Instantiate(blockObjectPrefab);
                    var blcokObject = new BlockObject(blockData, blockGameObject);
                }
            }
        }
    }
}
