using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 30.0f;    // 총알 속도
    public float lifeTime = 5.0f;  // 3초 후 자동 삭제 (메모리 관리)

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // 총알이 아래로 떨어지지 않게 중력 끄기

        // 총구(firePosition)가 바라보던 정면 방향으로 속도 부여
        rb.linearVelocity = transform.forward * speed;

        // 지정된 시간 후 오브젝트 파괴
        Destroy(gameObject, lifeTime);
    }
}
