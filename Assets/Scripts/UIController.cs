using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] RectTransform m_playerPos = null;
    [SerializeField] RectTransform m_miniMap = null;
    [SerializeField] GameObject m_endRaceMessage = null;

    float m_totalValue = 0.0f;
    float m_currentValue = 0.0f;
    float m_width = 0.0f;

    void Start()
    {
        RouteController.OnContinueRace += HandleOnValueChanged;
        RouteController.OnEndRace += HandleOnEndRace;
        m_endRaceMessage.SetActive(false);
        m_width = m_miniMap.rect.width;
    }

	private void HandleOnEndRace()
	{
        m_endRaceMessage.gameObject.SetActive(true);
    }

    public void SetTotalValue(float total)
	{
        m_totalValue = total;
	}

	private void HandleOnValueChanged(float value)
	{
        if(value != 0.0f)
		{
            m_currentValue += value;
            float pos = (m_width * m_currentValue) / m_totalValue;
            m_playerPos.position.Set(m_playerPos.position.x + pos, m_miniMap.position.y, 0);
        }
	}
}
