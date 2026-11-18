using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("발사 설정")]
    public GameObject bulletPrefab;  // 발사할 총알 프리팹
    public Transform firePosition;   // 총알이 생성될 발사 위치 (총구)

    void Update()
    {
        // 마우스 왼쪽 버튼(0)을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 프리팹이나 발사 위치가 비어있지 않은지 안전 검사
        if (bulletPrefab != null && firePosition != null)
        {
            // firePosition의 위치와 회전값(바라보는 방향) 그대로 총알 생성
            Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        }
    }
}
