using System.Collections.Generic;
using UnityEngine;

/*TODO:
Add another cubes
*/

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    
    public List<GameObject> Cubes = new List<GameObject>();
    
    private int _maxCount;

    private float minPositionX = -2.5f;
    private float maxPositionX = 2.5f;

    private void Start()
    {
        FirstGenerate();
    }

    private void OnEnable()
    {
        Bourds.OnGameOver += FirstGenerate;
    }

    private void FirstGenerate()
    {
        foreach (var cube in Cubes)
        {
            Destroy(cube);
        }
        
        Cubes.Clear();
        _maxCount = 6;

        for (int i = 0; i <= _maxCount; i++)
        {
            GenerateCube();
        }
    }

    private void GenerateCube()
    {
        Cubes.Add(Instantiate(_cube));
        if (Cubes.Count > 1)
        {
            float positionX = GetPositionX();
            float positionY = GetPositionY();
                
            Cubes[Cubes.Count - 1].GetComponent<Transform>().position = new Vector2(positionX, positionY);
        }
    }
    
    float GetPositionX()
    {
        bool isRight;
        if (Cubes[Cubes.Count - 2].GetComponent<Transform>().position.x > 0)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
        
        if (isRight)
        {
            return minPositionX + Random.Range(-0.5f, 1f);
        }
        return maxPositionX + Random.Range(-1f, 0.5f);
    }

    private float GetPositionY()
    {
        return Cubes[Cubes.Count - 2].GetComponent<Transform>().position.y + Random.Range(2.2f, 3f);
    }

    private void FixedUpdate()
    {
        if (Cubes.Count <= _maxCount)
        {
            GenerateCube();
        }
    }
}




