using System;

[Serializable]
public struct LogRotationInfo
{
    public int speed;
    public int duration;
    public bool isSlowDown;
}
