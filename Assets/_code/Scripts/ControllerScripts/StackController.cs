using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    public static StackController Instance;
    public List<GameObject> BlockList = new List<GameObject>();
    [SerializeField]
    private GameObject initialCube;
    private GameObject lastCubeStacked;
    public GameObject Player;
    public static bool finishLineCrossed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        lastCubeStacked = initialCube;
        BlockList.Add(initialCube); 
    }
    public void StackCubes(GameObject _gameObject)
    {
        BlockList.Add(_gameObject);
        Vector3 cubePosition = new Vector3(lastCubeStacked.transform.position.x, 
                                           lastCubeStacked.transform.position.y + 2.6f,
                                           lastCubeStacked.transform.position.z);
        Player.transform.position = cubePosition;
        _gameObject.transform.position = cubePosition;
        _gameObject.transform.SetParent(gameObject.transform);
        lastCubeStacked = BlockList[BlockList.Count-1];
        
    }
    public void RemoveCube(GameObject _gameObject)
    {
        
        Debug.Log("cubes are :" + BlockList.Count);
        BlockList.Remove(_gameObject);
        _gameObject.transform.parent = null;
        if(BlockList.Count != 0)
        {
          lastCubeStacked = BlockList[BlockList.Count - 1];
          Debug.Log("cubes are after removal :" + BlockList.Count);
        }
        if (BlockList.Count == 0)
        {
            LevelManager.instance.OnLevelComplete(BlockList.Count);
        }
    }
   
}
