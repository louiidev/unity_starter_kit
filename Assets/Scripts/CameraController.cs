using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.05f;
	public float startShakeAmount;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	new Camera camera;
	public float height;
	public float width;

	void Awake()
	{
		camera = GetComponent<Camera>();
		height = 2f * camera.orthographicSize;
		width = height * camera.aspect;

		startShakeAmount = shakeAmount;
	}

	void OnEnable()
	{
		originalPos = transform.localPosition;
	}

	public void Shake(float duration)
	{
		Shake(duration, startShakeAmount);
	}


	public void Shake(float duration, float amount)
	{
		shakeDuration = duration;
		shakeAmount = Mathf.Max(amount, shakeAmount);
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			transform.localPosition = originalPos;
		}
	}
}