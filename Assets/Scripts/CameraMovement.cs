using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 m_offSet = Vector3.zero;
    [SerializeField] PlayerController m_target = null;

    // Update is called once per frame
    void Update()
    {
        transform.position = m_target.GetPosition() + m_offSet;
    }
}
