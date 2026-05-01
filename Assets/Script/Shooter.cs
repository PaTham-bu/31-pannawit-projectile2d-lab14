using UnityEngine;
using UnityEngine.InputSystem; // ใช้ Input แบบใหม่ (ถ้าไม่ได้ใช้ไม่ต้องใส่ก็ได้)

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;   // จุดที่ยิงออก
    [SerializeField] private GameObject target;      // เป้าที่เล็ง / Crosshair
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {

    }

    void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue(); // อ่านตำแหน่งเมาส์ แล้วเก็บใน screenPos

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // ยิง Ray เมื่อคลิกเมาส์ โดยเอาตำแหน่งเมาส์ screenPos
            Ray ray = Camera.main.ScreenPointToRay(screenPos);

            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

            // ยิงหา Ray แบบ 2D
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            // ถ้า Ray ชน collider
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);

                Debug.Log("Hit: " + hit.collider.gameObject.name); // เช็คว่าโดนอะไร
            }
        }
    }
}