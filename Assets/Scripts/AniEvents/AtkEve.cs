using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEve : MonoBehaviour
{
	Transform enemy;
	public float radius;
	public float atkRange;
	public Collider2D weaponBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		Collider2D orcCollider = Physics2D.OverlapCircle(transform.position, radius, 1<<LayerMask.NameToLayer("Orc"));
		if (orcCollider != null)
		{
			enemy = orcCollider.transform;
		}
			
    }

	public void Attack()
	{
		if (enemy != null)
		{
			if (Vector3.Distance(transform.position, enemy.position) < atkRange)
			{
				enemy.GetComponent<OrcStateBase>().manager.ChangeState<OrcDmgState>();
				enemy.GetComponent<OrcStateBase>().manager.hp -= 20;
				weaponBox.enabled = true;
			}
		}
		
		
	}

	public void FixAttack()
	{
		weaponBox.enabled = false; 
	}

	
}
