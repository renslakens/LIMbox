using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
  // Allows you to hold down a key for movement.
  [SerializeField] private bool isRepeatedMovement = false;
  // Time in seconds to move between one grid position and the next.
  [SerializeField] private float moveDuration = 0.1f;
  // The size of the grid
  [SerializeField] private float gridSize = 1f;

  private bool isMoving = false;

  // Update is called once per frame
private void Update() {
  if (!isMoving) {
    System.Func<KeyCode, bool> inputFunction;
    if (isRepeatedMovement) {
      inputFunction = Input.GetKey;
    } else {
      inputFunction = Input.GetKeyDown;
    }

    Vector2 direction = Vector2.zero;
    if (inputFunction(KeyCode.UpArrow)) {
      direction = Vector2.up;
    } else if (inputFunction(KeyCode.DownArrow)) {
      direction = Vector2.down;
    } else if (inputFunction(KeyCode.LeftArrow)) {
      direction = Vector2.left;
    } else if (inputFunction(KeyCode.RightArrow)) {
      direction = Vector2.right;
    }

    // Check if there's a wall in the direction the player is trying to move
    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, gridSize);
    if (hit.collider == null || hit.collider.isTrigger) {
      StartCoroutine(Move(direction));
    }
  }
}

  // Smooth movement between grid positions.
  private IEnumerator Move(Vector2 direction) {
    // Record that we're moving so we don't accept more input.
    isMoving = true;

    // Make a note of where we are and where we are going.
    Vector2 startPosition = transform.position;
    Vector2 endPosition = startPosition + (direction * gridSize);

    // Smoothly move in the desired direction taking the required time.
    float elapsedTime = 0;
    while (elapsedTime < moveDuration) {
      elapsedTime += Time.deltaTime;
      float percent = elapsedTime / moveDuration;
      transform.position = Vector2.Lerp(startPosition, endPosition, percent);
      yield return null;
    }

    // Make sure we end up exactly where we want.
    transform.position = endPosition;

    // We're no longer moving so we can accept another move input.
    isMoving = false;
  }
}
