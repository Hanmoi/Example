using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 키보드 입력 받기 (-1.0f ~ 1.0f)
        float h = Input.GetAxis("Horizontal"); // 좌우 (A, D / 왼쪽, 오른쪽 화살표)
        float v = Input.GetAxis("Vertical");   // 앞뒤 (W, S / 위, 아래 화살표)

        // 2. 이동 방향 벡터 생성
        Vector3 moveDir = new Vector3(h, 0, v);

        // 대각선 이동 시 속도가 빨라지는 것 방지 (정규화)
        if (moveDir.magnitude > 1f)
        {
            moveDir.Normalize();
        }

        // 3. 실제 이동 적용 (로컬 좌표 기준)
        transform.Translate(moveDir * 5f * Time.deltaTime);
    }
}
