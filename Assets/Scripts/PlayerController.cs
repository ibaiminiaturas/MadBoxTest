using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IRunner
{
    [SerializeField] private float m_maxSpeed = 2.0f;
    private float m_currentSpeed = 0.0f;
    private bool m_active = true;
    [SerializeField] Animator m_playerAnimator = null;
    [SerializeField] Rigidbody m_rigidbody = null;
    public event Action OnPlayerKilled;
    Vector3 m_previousDireciton = Vector3.zero;
    void Awake()
    {
        m_active = true;
        m_rigidbody.useGravity = false;
        RouteController.OnPointArrived += HandleOnPointArrived;
    }

	private void HandleOnPointArrived(Vector3 newDirection)
	{
        transform.forward = newDirection;
        m_previousDireciton = newDirection;
    }

	public void SetState(bool active)
	{
        m_active = active;
        if (!active)
		{
            Stop(); 
        }
	}

	private void Stop()
	{
        m_currentSpeed = 0.0f;
        m_playerAnimator.SetFloat("MoveSpeed", m_currentSpeed);
    }

	public void SetDirection(Vector3 direction)
	{
        transform.forward = direction;
	}

    void Update()
    {
        if (!m_active)
            return;

        //process movement
        transform.position += transform.forward * (m_currentSpeed * Time.deltaTime);
        m_playerAnimator.SetFloat("MoveSpeed", m_currentSpeed);
    }


    private void LateUpdate()
	{
        //process input
        if (Input.GetButton("Fire1"))
        {
            m_currentSpeed = m_maxSpeed;
        }
        else
        {
            m_currentSpeed = 0.0f;
        }
    }

	public Vector3 GetPosition()
	{
        return transform.position;
	}

    public Vector3 GetForward()
    {
        return transform.forward;
    }

	public void OnDestroy()
	{
        RouteController.OnPointArrived -= HandleOnPointArrived;
    }

    private void OnCollisionEnter(Collision collision)
    { 
        OnPlayerKilled?.Invoke();
        Kill();
    }

    public void Kill()
	{
        m_rigidbody.useGravity = true;
        SetState(false);
    }

    public void Revive()
	{
        m_rigidbody.useGravity = false;
        SetState(true);
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = Vector3.zero;

        transform.forward = m_previousDireciton;
    }

	public void SetPosition(Vector3 position)
	{
        transform.position = position;
	}
}
