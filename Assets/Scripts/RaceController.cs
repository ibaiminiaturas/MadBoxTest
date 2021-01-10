using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    [SerializeField] RouteController m_routeController = null;
    [SerializeField] PlayerController m_playerController = null;
	[SerializeField] UIController m_UIController = null;
    void Start()
    {
        //inject the runner to the routte controller
        m_routeController.SetRunner(m_playerController);
		//place the runner in the starting point
		m_routeController.SetRunnerAtStart();
		//register to the end race event
		m_playerController.OnPlayerKilled += HandleOnPlayerKilled;
		RouteController.OnEndRace += HandleOnEndRace;
		m_UIController.SetTotalValue(m_routeController.RunTotalDistance);
    }

	//the race begins
	public void HandleOnBeginRace()
	{
		m_playerController.SetState(true);
	}

	//the race ends
	private void HandleOnEndRace()
	{
		m_playerController.SetState(false);
	}

	private void HandleOnPlayerKilled()
	{
		StartCoroutine(RevivePlayer());
	}

	private IEnumerator RevivePlayer()
	{
		yield return new WaitForSeconds(1.3f);
		m_playerController.transform.position = m_routeController.GetLastCheckPoint();
		m_playerController.Revive();
	}

	private void OnDestroy()
	{
		RouteController.OnEndRace -= HandleOnEndRace;
		m_playerController.OnPlayerKilled -= HandleOnPlayerKilled;
	}
}
