using UnityEngine;

/*TODO:
*/

public class Controller : MonoBehaviour
{
	[SerializeField] private float _speed;
	
	private Camera _cam;
	
	private Vector2 _startPosition;
	private Vector2 _currentPosition;
	
	private bool _isGlue;
	private bool _isFly;
	
	private void OnEnable()
	{
		_cam = Camera.main;
	}

	private void Update () {
		if (!_isFly)
		{
			if (Input.GetMouseButtonDown(0))
			{
				_startPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
			}
			if (Input.GetMouseButtonUp(0))
			{
				_currentPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
				Move(_currentPosition - _startPosition);
			}
		}
	}

	void Move(Vector2 position)
	{
		if (position.y > 4f)
		{
			position.y = 4f;
		}
		if (position.x < -1.5f)
		{
			position.x = -1.5f;
		}
		if (position.x > 1.5f)
		{
			position.x = 1.5f;
		}
		
		GetComponent<Rigidbody2D>().AddForce(position * _speed, ForceMode2D.Impulse);
		Invoke("LetsMove", 0.1f);
		_isGlue = false;
	}

	private void LetsMove()
	{
		_isGlue = true;
	}
	
	private void OnCollisionStay2D(Collision2D other)
	{
	if (!_isGlue) return;
		
		_isFly = false;

		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().inertia = 0;
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		_isFly = true;
	}
}
