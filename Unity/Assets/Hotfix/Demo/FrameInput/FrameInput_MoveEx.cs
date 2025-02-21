﻿namespace ET
{
    public static class FrameInput_MoveEx
    {
        public static void Run(this FrameInput_Move self,Unit unit)
        {
            var speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
            unit.GetComponent<FrameMoveComponent>().Move(self.Path, speed).Coroutine();
            var msg = new C2M_PathfindingResult() { ClientFrame = unit.GetCurrSimulateFrame(), Target = self.Target.ToOpV3() };
            foreach (var v in self.Path)
            {
                msg.Path.Add(v.ToOpV3());
            }
            unit.CurrSession().Send(msg);
        }
        
    }
}