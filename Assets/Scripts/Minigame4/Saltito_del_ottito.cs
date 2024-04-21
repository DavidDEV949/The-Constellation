using UnityEngine;
using System.Collections;

public class Saltito_del_ottito : MonoBehaviour
{
    public float upY = 3f;
    public float downY = -2f;
    public float moveDuration = 1f;
    private bool isMoving = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartCoroutine(MoveOtto());
        }
    }

    private IEnumerator MoveOtto()
    {
        isMoving = true;

        yield return StartCoroutine(MoveToPosition(new Vector3(initialPosition.x, upY, initialPosition.z), moveDuration));

        yield return new WaitForSeconds(0.05f);

        yield return StartCoroutine(MoveToPosition(new Vector3(initialPosition.x, downY, initialPosition.z), moveDuration));

        isMoving = false;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
