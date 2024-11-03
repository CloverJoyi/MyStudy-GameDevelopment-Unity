

public class PlayerStateTest : PlayerStateBase
{
    public class PlayerStateID
    {
        public const int idle = 1;
        public const int move = 1 << 1;
        public const int jump = 1 << 2;
        public const int hurt = 1 << 3;
    }

    enum PlayerStateEnum
    {
        idle = 1,
        move = 1 << 1,
        jump = 1 << 2,
        hurt = 1 << 3,
    }


    public int state;
    public bool onGround;
    public bool isDie;
    public void Reset()
    {
        state = PlayerStateID.idle;
        isDie = false;
        onGround = true;
    }
}
