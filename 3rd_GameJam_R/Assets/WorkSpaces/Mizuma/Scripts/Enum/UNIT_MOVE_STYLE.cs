/// <summary>
/// 鳥がプレイヤーに到着するまでの移動軌道
/// </summary>
public enum UNIT_MOVE_STYLE
{
    STRAIGHT,               // 直線軌道
    MOUNTAIN,               // 山なり
    VERTICAL_MEANDELING,    // 縦にジグザグ移動
    HORIZONTAL_MEANDELING   // 横にジグザグ移動
}