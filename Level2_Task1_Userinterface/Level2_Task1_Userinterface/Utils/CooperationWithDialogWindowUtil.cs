using WindowsInput;
using WindowsInput.Native;

namespace Level2_Task1_Userinterface.Utils
{
    public static class CooperationWithDialogWindowUtil
    {
        private static InputSimulator inputSimulator = new InputSimulator();
        
        public static void LoadFileToDialogWindow(string imagePath) 
        {
            inputSimulator.Keyboard
                .Sleep(700)
                .TextEntry(imagePath)
                .Sleep(500)
                .KeyPress(VirtualKeyCode.RETURN);
        }

    }
}
