using System.Collections.Generic;
using UnityEngine;

public class AW2DCameraComponent: MonoBehaviour
{
    // MARK: - Properties

    public GameObject player;

    // MARK: - Lifecycle

    private void Update()
	{
        if (player.transform.position.x > -6.5 && player.transform.position.x < 6.5) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
