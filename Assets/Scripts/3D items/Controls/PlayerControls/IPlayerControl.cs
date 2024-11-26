
using Mono.Cecil.Cil;
using static UnityEngine.Rendering.DebugUI;
using System;
public interface IPlayerControl
{
public enum eControlDirection : byte
    {
        none = 0,
        up = 0x1,
        down = 0x2,
        left = 0x4,
        right = 0x8,
        rotateCW = 0x10,  
        rotateCCW = 0x20, 
        rotateUp = 0x40,  
        rotateDown = 0x80,
        
        // translation
        HasTranslation = up | down | left | right,
        // rotation
        HasRotation = rotateCW | rotateCCW | rotateUp | rotateDown,
    }
    public enum eControllerType { none = 0, keyboard, inGameMouse, xbox}

    public string RetrieveDirectionString();
    public eControllerType GetControllerType();

    public void SetPlayerControlActivity(bool isActive);

}
