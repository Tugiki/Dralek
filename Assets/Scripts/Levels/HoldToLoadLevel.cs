using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldToLoadLevel : MonoBehaviour
{
    [SerializeField] private float holdDuration = 1f;   // Duration to hold before loading the level
    [SerializeField] private Image fillCircle;          // UI Image to show fill progress

    private float holdTimer = 0;
    private bool isHolding = false;

    public static event Action OnHoldComplete;

    void FixedUpdate()
    {
        if (isHolding)
        {
            holdTimer += Time.fixedDeltaTime;
            fillCircle.fillAmount = holdTimer / holdDuration;

            if (holdTimer >= holdDuration) // HOLDER FINISHED Take action
            {
                OnHoldComplete.Invoke();
                ResetHold();
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
        }
        else if (context.canceled)
        {
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        fillCircle.fillAmount = 0;
    }
}
