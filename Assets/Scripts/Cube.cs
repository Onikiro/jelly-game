using UnityEngine;

/*TODO:
Colours maybe;
*/

public class Cube : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private CubeManager _manager;

    private void Update()
    {
        if (_cam.GetComponent<Transform>().position.y - GetComponent<Transform>().position.y > 6)
        {
            _manager.Cubes.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _cam = Camera.main;
        _manager = GameObject.FindWithTag("Manager").GetComponent<CubeManager>();
    }

    private void TryDestroy()
    {
        _manager.Cubes.Remove(gameObject);
        Destroy(gameObject);
    }
}
