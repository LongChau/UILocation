// others game enum

public enum OtherType
{
    None = -1
}

public enum EScene
{
    None = -1,
    Scene_1 = 0,
    Scene_2 = 1,
}

public enum EMoveDirection
{
    None = 0,
    Left = -1,
    Right = 1,
}

public enum EObstacleType
{
    None = 0,
    /// <summary>
    /// Static will increase time with level
    /// </summary>
    Static,
    /// <summary>
    /// Runner is not increase time with level
    /// </summary>
    Runner,
}

public enum EGameLayer
{
    Default = 0,
    TransparenFX = 1,
    IgnoreRaycast = 2,
    Water = 4,
    UI = 5,
    Obstacle = 8,
    Player = 9,
}

public enum EErrorCode
{
    UserNameNotFound = 404,
    InvalidUserNameSupplied = 405,
    Ok = 200,
}

public enum ESoundEffect
{
    None = -1,
    BtnClicked = 0,
    Explosive,
    GunShot,
    Item_Taken,
    Lose,
    TingTing,
    Win,
    BusHorn,
}

public enum REWARD_ICON
{
    NONE,
    SMALL_CASH,
    MEDIUM_CASH,
    LARGE_CASH,
    GOLD,
}

public enum REWARD_TYPE
{
    NONE,
    CASH,
    GOLD
}

public enum UJI_REGION
{
    None = -1,
    Mampukuji_Temple = 0,
    Minuroto_Temple = 1,
    UjiBashi_Bridge = 2,
    Byodoin_Temple = 3,
    Uji_RiverSite = 4,
}

public enum EDeviceType
{
    None = -1,
    iPhone8 = 0,
    iPhoneX = 1,
}

public enum ERectTransformType
{
    Normal,
    Stretch,
}