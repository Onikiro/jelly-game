using UnityEngine;

/*TODO:
*/

public class GameProcessHandler : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    private void OnEnable()
    {
        Bourds.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        Instantiate(_player);
    }
}
