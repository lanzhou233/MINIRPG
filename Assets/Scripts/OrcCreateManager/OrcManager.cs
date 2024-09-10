using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcManager : MonoBehaviour
{
	GameObject Orc;
	public float CreatTime;
	public Transform player;
	public PlayerStateManager manager;
	private void Awake()
	{
		Orc = Resources.Load<GameObject>("Prefabs/Orc");
	}
	// Start is called before the first frame update
	void Start()
    {
		InvokeRepeating("CreatOrc",0, CreatTime);
    }


	void CreatOrc()
	{
		GameObject myOrc = Instantiate(Orc, new Vector3(Random.Range(0, 10.0f), Random.Range(-5.0f, 5.0f), 0), Quaternion.identity);
		myOrc.GetComponent<OrcAtkEve>().player = player;
		myOrc.GetComponent<OrcAtkEve>().manager = manager;
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
