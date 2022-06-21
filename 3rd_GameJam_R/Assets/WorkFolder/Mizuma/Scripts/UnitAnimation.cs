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
    }

    private void ArriveMoveStart()
    {
        animator.SetInteger("playAnimIndex", (int)unitArriveMoveStyle);
        animator.SetInteger("rndNum", Random.Range(0, 2));
        animator.SetTrigger("triArriveAnim");
    }

    private void OnArriveMove()
    {
        Debug.Log("Destroy");
        Destroy(gameObject);
    }
}
