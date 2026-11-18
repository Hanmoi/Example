using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("추적 대상")]
    public Transform target;

    [Header("카메라 설정")]
    public Vector3 offset = new Vector3(0f, 4f, -6f); // 대상 기준 뒤쪽/위쪽 위치
    public float followSmoothTime = 0.15f;            // 위치 추적 부드러움
    public float lookHeight = 1.0f;                   // 바라볼 지점의 높이 보정

    private Vector3 currentVelocity;

    void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.Find("Player");
            if (player != null) target = player.transform;
        }
    }

    // 플레이어 이동(FixedUpdate) 이후 카메라를 갱신해 떨림을 방지
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, followSmoothTime);

        transform.LookAt(target.position + Vector3.up * lookHeight);
    }
}
