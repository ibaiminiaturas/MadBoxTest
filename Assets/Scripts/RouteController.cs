using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Transform> m_routePoints = new List<Transform>();
    [SerializeField] IRunner m_runner;
    [SerializeField] float m_distanceThreshold = 1.0f;
    int m_currentRoutePointIndex;
    float m_runTotalDistance = 0.0f;
    Vector3 m_runnerPreviousPosition = Vector3.zero;
	public float RunTotalDistance { get => m_runTotalDistance; }


	public static event Action<Vector3> OnPointArrived;

    public static event Action OnEndRace;

    public static event Action<float> OnContinueRace;

    void Awake()
    {
        m_currentRoutePointIndex = 0;
        CalculateTotalDistance();
    }

	private void CalculateTotalDistance()
	{
        for (int i = 0; i < m_routePoints.Count; ++i)
		{
            if (i != m_routePoints.Count - 1)
			{
                m_runTotalDistance += Vector3.Magnitude(m_routePoints[i+1].position - m_routePoints[i].position);
			}
		}
	}

    public void SetRunnerAtStart()
    {
        m_runner.SetPosition(GetStart());
        m_runnerPreviousPosition = m_runner.GetPosition();
    }


    public void SetRunner(IRunner runner)
	{
        m_runner = runner;
    }

    public Vector3 GetStart()
	{
        return m_routePoints[m_currentRoutePointIndex].position;
    }

    public Vector3 GetLastCheckPoint()
	{
        if (m_currentRoutePointIndex == 0)
            return GetStart();
        return m_routePoints[m_currentRoutePointIndex - 1].position;
	}


    // Update is called once per frame
    void Update()
    {
        Vector3 position = m_runner.GetPosition();

        if ((position - m_routePoints[m_currentRoutePointIndex].position).sqrMagnitude <= m_distanceThreshold*m_distanceThreshold)
		{
            if (m_routePoints.Count - 1 == m_currentRoutePointIndex)
			{
                //End of the race
                OnEndRace?.Invoke();
            }
            else
			{
                OnPointArrived?.Invoke(m_routePoints[m_currentRoutePointIndex + 1].position - m_routePoints[m_currentRoutePointIndex].position);
                m_currentRoutePointIndex++;
            }
        }

        OnContinueRace?.Invoke((position - m_runnerPreviousPosition).magnitude);

        m_runnerPreviousPosition = position;
    }
}
