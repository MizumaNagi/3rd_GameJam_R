using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private UNIT_ARRIVE_MOVE_STYLE unitArriveMoveStyle;

    public void Init(UNIT_MOVE_STYLE moveStyle, UNIT_ARRIVE_MOVE_STYLE arriveMoveStyle, float unitMoveSpeed)
    {
        unitArriveMoveStyle = arriveMoveStyle;

        animator.speed = unitMoveSpeed;

        SpawnMoveStart(moveStyle);
    }

    private void SpawnMoveStart(UNIT_MOVE_STYLE moveStyle)
    {
        animator.SetInteger("playAnimIndex", (int)moveStyle);
        animator.SetTrigger("triSpawnAnim");
        Debug.Log("SpawnMoveStart");
    }

    private void StartSpawnMove()
    {
        animator.SetBool("isFinishSpawnAnim", false);
    }

    private void StartArriveMove()
    {
        animator.SetBool("isFinishSpawnAnim", true);
    }


    private void EndSpawnMove()
    {
        Debug.Log("MoveStart");
        animator.SetInteger("playAnimIndex", (int)unitArriveMoveStyle);
        animator.SetInteger("rndNum", Random.Range(0, 2));
        animator.SetTrigger("triArriveAnim");
    }

    private void OnArriveMove()
    {
        gameObject.SetActive(false);
    }
}
