using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField] private float maxhealth = 100f;
    [SyncVar] private float currenthealth;

    void Awake()
    {
        currenthealth = maxhealth;
    }

    public void Takedamage(float damage)
    {
        currenthealth -= damage;
        Debug.Log(transform.name + "имеет жизнь = " + currenthealth);
    }
}
