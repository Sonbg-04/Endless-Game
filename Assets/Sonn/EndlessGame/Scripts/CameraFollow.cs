using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonn.EndlessGame
{
    public class CameraFollow : MonoBehaviour
    {
        public static CameraFollow Ins; 

        public Transform target; // mục tiêu camera sẽ theo dõi
        public Vector3 offset; // khoảng cách giữa camera và mục tiêu

        [Range(1, 10)]
        public float smoothFactor; // hệ số làm mượt camera

        private void Awake()
        {
            Ins = this;
        }

        private void FixedUpdate()
        {
            Follow();
        }

        // phương thức theo dõi mục tiêu
        private void Follow()
        {
            if (target == null) return;

            // Tính toán vị trí mới của camera dựa trên vị trí mục tiêu và offset
            Vector3 targetPos = new Vector3(0, target.transform.position.y, 0) 
                + offset;

            // Vị trí camera sẽ được mượt theo vị trí mục tiêu
            Vector3 smoothedPos = Vector3.Lerp(transform.position, 
                targetPos, smoothFactor * Time.deltaTime);

            // Cập nhật vị trí camera, giới hạn trong phạm vi nhất định
            transform.position = new Vector3(
                Mathf.Clamp(smoothedPos.x, 0, smoothedPos.x),
                Mathf.Clamp(smoothedPos.y, 0, smoothedPos.y),
                0);
        }
    }

}

