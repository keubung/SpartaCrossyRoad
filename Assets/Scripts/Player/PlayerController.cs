using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;

    private float moveAmount = 2f;
    public float moveSpeed = 5f; // 이동 속도
    public float rotationSpeed = 2f;
    private bool isMoving = false;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (!isMoving)
        {
            // W 키가 눌렸을 때
            if (Input.GetKeyDown(KeyCode.W))
            {
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                //transform.Translate(0, 0, moveAmount);
                StartCoroutine(MovePlayer(Vector3.forward, Quaternion.Euler(0, 0, 0)));
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //transform.rotation = Quaternion.Euler(0, -90, 0);
                //transform.Translate(0, 0, moveAmount);
                StartCoroutine(MovePlayer(Vector3.left, Quaternion.Euler(0, -90, 0)));
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //transform.rotation = Quaternion.Euler(0, 180, 0);
                //transform.Translate(0, 0, moveAmount);
                StartCoroutine(MovePlayer(Vector3.back, Quaternion.Euler(0, 180, 0)));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //transform.rotation = Quaternion.Euler(0, 90, 0);
                //transform.Translate(0, 0, moveAmount);
                StartCoroutine(MovePlayer(Vector3.right, Quaternion.Euler(0, 90, 0)));
            }
        }
    }

    private IEnumerator MovePlayer(Vector3 direction, Quaternion targetRotation)
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + direction * moveAmount;
        Quaternion startRotation = transform.rotation;

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            float lerpFactor = elapsedTime / 1f;
            transform.position = Vector3.Lerp(startPosition, endPosition, lerpFactor);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, lerpFactor);
            elapsedTime += Time.deltaTime * moveSpeed;

            yield return null;
        }

        transform.position = endPosition;
        transform.rotation = targetRotation;
        isMoving = false;
    }
}
    //public float moveSpeed = 5f; // 이동 속도
    //public float rotationSpeed = 700f; // 회전 속도

    //void Update()
    //{
    //    // 키보드 입력으로 이동 방향 계산
    //    float horizontal = Input.GetAxis("Horizontal"); // A, D 또는 왼쪽, 오른쪽 화살표
    //    float vertical = Input.GetAxis("Vertical"); // W, S 또는 위쪽, 아래쪽 화살표

    //    // 이동 방향
    //    Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

    //    if (moveDirection.magnitude >= 0.1f)
    //    {
    //        // 이동
    //        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

    //        // 회전 (이동 방향으로 회전)
    //        Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    //    }
    //}
//}
