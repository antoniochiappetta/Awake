using System.Collections.Generic;
using UnityEngine;

public class AW2DCameraComponent: MonoBehaviour
{
    // MARK: - Properties

    public GameObject player;
    public float sideLimit;

    // MARK: - Lifecycle

    private void Update()
	{
        if (player.transform.position.x > -sideLimit && player.transform.position.x < sideLimit) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
