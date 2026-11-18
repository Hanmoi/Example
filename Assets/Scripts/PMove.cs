using UnityEngine;

public class PMove : MonoBehaviour
{
    [Header("이동 설정")]
    public float moveSpeed = 6.0f;

    [Header("점프 설정")]
    public float jumpForce = 7.0f;
    public LayerMask groundLayer;      // 바닥으로 인식할 레이어
    public float groundCheckDistance = 1.1f; // 바닥 감지 레이저 길이 (캡슐 높이 절반 + 여유분 0.1)

    private Rigidbody rb;
    private Vector3 moveInput;
    private bool isGrounded;
    private bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 캐릭터 넘어짐 방지
    }

    void Update()
    {
        // 1. 이동 입력 받기
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(h, 0f, v).normalized;

        // 2. 바닥에 닿아 있는지 확인 (중심에서 아래로 Raycast 발사)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // 3. 바닥에 있을 때 스페이스바를 누르면 점프 예약
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        // 1. 수평 이동 적용 (기존 y축 속도 유지)
        Vector3 targetVelocity = moveInput * moveSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);

        // 2. 점프 실행
        if (jumpRequested)
        {
            // 경사면이나 낙하 중 점프 시 점프력이 일정하도록 y축 속도 초기화
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            // 위쪽 방향으로 순간적인 충격(Impulse) 가하기
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jumpRequested = false; // 점프 처리 완료
        }
    }

    // 에디터 Scene 뷰에서 바닥 감지 선을 눈으로 확인하기 위한 디버그용 함수
    void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
