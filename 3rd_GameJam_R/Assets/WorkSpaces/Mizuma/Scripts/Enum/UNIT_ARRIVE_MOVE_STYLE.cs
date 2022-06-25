/// <summary>
/// 鳥がプレイヤー付近到着後にする動き
/// </summary>
public enum UNIT_ARRIVE_MOVE_STYLE
{
    IGNORE,         // 無視して反対側に向かう
    LIVITATING,     // 滞空する
    TURN_AROUND     // 辺りを回る
}