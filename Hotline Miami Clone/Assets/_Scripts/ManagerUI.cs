using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public TextMeshProUGUI velocityShower;
    public GameObject player;
    void Update()
    {
        velocityShower.text = player.GetComponent<Rigidbody2D>().linearVelocity.ToString("0.0");
    }
}
