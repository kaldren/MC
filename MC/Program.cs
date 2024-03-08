using System.Runtime.InteropServices;

class Program
{
    // Import the necessary Windows API functions to simulate mouse events
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

    [StructLayout(LayoutKind.Sequential)]
    struct INPUT
    {
        public uint type;
        public MOUSEINPUT mi;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    // Mouse event constants
    const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    const uint MOUSEEVENTF_LEFTUP = 0x0004;

    static void Main(string[] args)
    {
        while (true)
        {
            // Simulate mouse left button down
            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = 0; // INPUT_MOUSE
            mouseDownInput.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            SendInput(1, ref mouseDownInput, Marshal.SizeOf(mouseDownInput));

            // Simulate mouse left button up
            INPUT mouseUpInput = new INPUT();
            mouseUpInput.type = 0; // INPUT_MOUSE
            mouseUpInput.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref mouseUpInput, Marshal.SizeOf(mouseUpInput));

            Console.WriteLine("Mouse click simulated");

            // Wait for 10 seconds
            Thread.Sleep(10000);
        }
    }
}
