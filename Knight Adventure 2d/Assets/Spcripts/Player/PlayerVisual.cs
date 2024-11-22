using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
        AdJustPlayerFacingDirection();
    }
    private void AdJustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerScreenPosition = Player.Instance.GetPlayerScreenPosition();

        if(mousePos.x < playerScreenPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }
}