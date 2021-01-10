using UnityEngine;

public interface IRunner
{
	Vector3 GetPosition(); 
	Vector3 GetForward();
	void SetPosition(Vector3 position);
}