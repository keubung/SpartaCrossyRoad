using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (플레이어)
    private Vector3 offset = new Vector3(5, 8, -5); // 카메라의 위치 오프셋 (오른쪽, 위쪽, 뒤쪽)
    private float smoothSpeed = 0.1f; // 부드러운 이동 속도

    void LateUpdate()
    {
        if (target != null)
        {
            // 목표 위치에 offset을 더하여 카메라의 목표 위치 계산
            Vector3 desiredPosition = target.position + offset;
            // 부드럽게 카메라 이동
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // 카메라 위치 업데이트
            transform.position = smoothedPosition;

            // 카메라의 회전값 고정
            transform.rotation = Quaternion.Euler(45f, -45f, 0f);
        }
    }
}
