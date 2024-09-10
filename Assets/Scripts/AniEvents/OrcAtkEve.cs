using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAtkEve : MonoBehaviour
{
	public float radius;
	public Transform player;
	public float atkRange = 1.5f;
	public PlayerStateManager manager;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
	}

	public void Attack()
	{
		if (player != null)
		{
			
			if (Vector3.Distance(transform.position, player.position) < atkRange)
			{
				manager.ChangeState<PlayerDamageState>();
			}
				
		}
	
	}
}
