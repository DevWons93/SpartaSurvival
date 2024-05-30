using System;

public enum EItemType
{
    EQUIPABLE,
    CONSUMABLE,
    RESOURCE,
    BUFFABLE
}

public enum EConsumableType
{
    HEALTH,
    HUNGER
}

[Flags]
public enum EBuffType
{
    BOOST = 1 << 1,
    INVINCIBILITY = 1 << 2   
}