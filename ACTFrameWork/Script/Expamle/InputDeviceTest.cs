

public class InputDeviceTest : InputDevice
{
    public static bool GetJump()
    {
        bool jump = keyboard.spaceKey.wasPressedThisFrame;
        return jump;
    }
}
