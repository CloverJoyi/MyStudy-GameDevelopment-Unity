using UnityEngine;
using UnityEngine.InputSystem;

namespace Exaple
{
    public class InputDataTest : InputData
    {
        public Vector3 playerInput;
        public bool desiredJump;
    }


    public class AixsInputTest : PlayerInputBase
    {
        public readonly InputDataTest inputData;

        public AixsInputTest(InvokerBase invoker) : base(invoker)
        {
            inputData = GetInputData<InputDataTest>();
            //Debug.Log(inputData == null);
            //Debug.LogWarning("inputData为null");
        }

        protected override void GetInputAxis()
        {
            Vector2 input = InputDevice.GetPlayerMovement();
            inputData.playerInput.x = input.x;
            inputData.playerInput.y = input.y;

            inputData.desiredJump = InputDeviceTest.GetJump();
        }

        protected override void CallCommand()
        {
            if (inputData.playerInput.magnitude > 0.1f)//magnitude模长
            {
                Debug.Log("顺利发送移动指令");
                m_invoker.Call((int)CallID.Move);//发送call的ID，它将作为枚举类型放在InvokerBase的子类中
            }

            if (inputData.desiredJump == true)
            {
                Debug.Log("顺利发送跳跃指令");
                m_invoker.Call((int)CallID.Jump);//此处应为jump的ID
                inputData.desiredJump = false;
            }
        }
    }


}