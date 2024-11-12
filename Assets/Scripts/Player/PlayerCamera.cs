using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (�÷��̾�)
    private Vector3 offset = new Vector3(5, 8, -5); // ī�޶��� ��ġ ������ (������, ����, ����)
    private float smoothSpeed = 0.1f; // �ε巯�� �̵� �ӵ�

    void LateUpdate()
    {
        if (target != null)
        {
            // ��ǥ ��ġ�� offset�� ���Ͽ� ī�޶��� ��ǥ ��ġ ���
            Vector3 desiredPosition = target.position + offset;
            // �ε巴�� ī�޶� �̵�
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // ī�޶� ��ġ ������Ʈ
            transform.position = smoothedPosition;

            // ī�޶��� ȸ���� ����
            transform.rotation = Quaternion.Euler(45f, -45f, 0f);
        }
    }
}
