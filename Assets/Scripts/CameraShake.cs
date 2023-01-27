using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        Debug.Log("elapsed: " + elapsed);
        Debug.Log("duration: " + duration);

        while (elapsed < duration)
        {
            Debug.Log(elapsed);
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(- 1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}