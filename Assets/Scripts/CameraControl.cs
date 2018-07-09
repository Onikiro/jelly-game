using UnityEngine;

/*TODO:
*/

public class CameraControl : MonoBehaviour
{
	[SerializeField] private float _speed;
	private float _time;
	private bool _isStarted = false;
	
	private void Awake()
	{
		Application.targetFrameRate = 60;
		Screen.orientation = ScreenOrientation.Portrait;
	}

	private void Start()
	{
		_isStarted = true;
		_time = Time.time;
	}

	void Update ()
	{
		if (_isStarted)
		{
			if (Time.time - _time > 1)
			{
				_time = Time.time;
				_speed += 0.1f;
			}
			GetComponent<Transform>().position += Vector3.up * Time.deltaTime * _speed;
		}
	}

	private void OnEnable()
	{
		Bourds.OnGameOver += () =>
		{
			GetComponent<Transform>().position = new Vector3(0,0,-20);
			_speed = 1;
			_time = 0;
			//_isStarted = false;
		};
	}
}
