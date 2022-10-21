using Gma.System.MouseKeyHook;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;

// Resouces Used for this Project:
// 1) Global Mouse and Keyboard Hook/Listener: https://www.youtube.com/watch?v=mxJgGLeY2Kk
// 2) Simulating Keyboard and Mouse presses: https://ourcodeworld.com/articles/read/520/simulating-keypress-in-the-right-way-using-inputsimulator-with-csharp-in-winforms
//      - virtual key codes: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes?redirectedfrom=MSDN


namespace Mouse_and_Keyboard_Automation_1._1
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly List<Action> actionList = new();
        private readonly BindingSource bs = new();

        private IKeyboardMouseEvents? m_GlobalHook;

        private bool isPlaying = false;
        private bool isInsideForm = false;
        private bool isRecording = false;
        public bool isInfinite = false;
        public bool wasPrompted = false;

        public int repeatCount = 1;
        private int xCord, yCord;

        // keyboard and mouse events listener/hook
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetCursorPos(int X, int Y);

        public Form()
        {
            InitializeComponent();
            bs.DataSource = actionList;
            listBox.DataSource = bs; //links the listbox to the datasouce (list) where it gets the tostring to display the information
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            Unsubscribe();
            Dispose();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            Unsubscribe();
            Subscribe();

            // border is not considered in the form, so I disabled it 
            listBox.BorderStyle = BorderStyle.None;
            textBox_delayInput.BorderStyle = BorderStyle.None;

            // set the initial text state and color state of the form
            label_currentCoordinate.Text = "Current: (XXXX,YYYY)";
            label_storeCoordinate.Text = "Saved: (XXXX,YYYY)";
            button_Remove.Text = "Remove Selected Entry";
            button_DelayOne.Text = "Delay Selected";
            button_Record.Text = "START Recording";
            button_Record.BackColor = Color.Lime;
            button_Play.Text = "Begin Playback";
            button_DelayAll.Text = "Delay ALL";
            textBox_Play.Text = "1";
        }

        private void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseMove += GlobalHook_MouseMove;
            m_GlobalHook.MouseDownExt += GlobalHook_MouseDownExt;
            m_GlobalHook.KeyPress += GlobalHook_KeyPress;
        }

        private void Unsubscribe()
        {
            if (m_GlobalHook == null) return;
            m_GlobalHook.MouseMove -= GlobalHook_MouseMove;
            m_GlobalHook.MouseDownExt -= GlobalHook_MouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHook_KeyPress;
            m_GlobalHook.Dispose();
            m_GlobalHook = null;
        }

        private void GlobalHook_KeyPress(object? sender, KeyPressEventArgs e)
        {
            label_playbackState.Text = e.KeyChar.ToString();
            if (e.KeyChar.ToString().Equals(";"))
            {
                Debug.WriteLine("PLAYBACK STOPPED BY USER.");
                label_replayState.Text = "PLAYBACK STOPPED BY USER.";
                isPlaying = false;
            }

            // only save when outside the form
            if (isInsideForm) { return; }
            // only save when recroding
            if (!isRecording) { return; }

            label_storeCoordinate.Text = string.Format("Saved: {0} @ ({1},{2})", e.KeyChar, xCord, yCord);
            Action newAction = new(xCord, yCord, e.KeyChar.ToString());
            actionList.Add(newAction);
            bs.ResetBindings(false);
        }

        private void GlobalHook_MouseDownExt(object? sender, MouseEventExtArgs e)
        {
            // only save when outside the form
            if (isInsideForm) { return; }
            // only save when recroding
            if (!isRecording) { return; }
            // suppress middle mouse button click
            if (e.Button == MouseButtons.Middle) { return; }
            // suppress right mouse button click
            if (e.Button == MouseButtons.Right) { return; }

            label_storeCoordinate.Text = string.Format("Saved: Left click @ ({0},{1})", xCord, yCord);
            Action newAction = new(xCord, yCord, "left");
            actionList.Add(newAction);
            bs.ResetBindings(false);
        }

        private void GlobalHook_MouseMove(object? sender, MouseEventArgs e)
        {
            xCord = e.X;
            yCord = e.Y;
            label_currentCoordinate.Text = string.Format("Current: ({0},{1})", xCord, yCord);
        }

        private void MouseLeaveForm(object sender, EventArgs e)
        {
            label_formListener.Text = "MOUSE OUTSIDE FORM";
            isInsideForm = false;
        }

        private void MouseEnterForm(object sender, EventArgs e)
        {
            label_formListener.Text = "MOUSE INSIDE FORM";
            isInsideForm = true;
        }

        private void ToggleRecording(object sender, EventArgs e)
        {
            if (isRecording)
            {
                isRecording = false;
                button_Record.BackColor = Color.Lime;
                button_Record.Text = "START Recording";
                button_Play.Visible = true;
                textBox_Play.Visible = true;
                button_DelayAll.Visible = true;
                button_DelayOne.Visible = true;
                textBox_delayInput.Visible = true;
                button_Remove.Visible = true;
            }
            else
            {
                isRecording = true;
                button_Record.BackColor = Color.Red;
                button_Record.Text = "STOP Recording";
                button_Play.Visible = false;
                textBox_Play.Visible = false;
                button_DelayAll.Visible = false;
                button_DelayOne.Visible = false;
                textBox_delayInput.Visible = false;
                button_Remove.Visible = false;
            }
        }

        private void RemoveEntry(object sender, EventArgs e)
        {
            if (actionList.Count <= 0) { return; }
            if (listBox.SelectedIndex > actionList.Count - 1) { return; }

            actionList.RemoveAt(listBox.SelectedIndex);
            bs.ResetBindings(false);
        }

        private async void StartPlayback(object sender, EventArgs e)
        {
            isPlaying = true;

            if (!wasPrompted)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to start REPEATED playback?\nPress \";\" at any time to stop preemptively.", "Confirm", MessageBoxButtons.YesNo);
                wasPrompted = true;
                if (dialogResult == DialogResult.No) { ToggleFormSwap(true); return; }
            }

            ToggleFormSwap(false);

            try
            {
                repeatCount = (int.Parse(textBox_Play.Text));
                isInfinite = false;
            }
            catch
            {
                Debug.WriteLine("SETTING INFINITE TO TRUE");
                isInfinite = true;
                repeatCount = 2; // set to 2 for logic purposes
            }

            // loop through the actionList and preform the actions X times as specified by the text box. on exception, it will be ran indefinitely.
            for (int j = 0; j < repeatCount; j++)
            {
                if (isInfinite)
                {
                    j = 0;
                }

                for (int i = 0; i < actionList.Count; i++)
                {
                    if (!isPlaying)
                    {
                        ToggleFormSwap(true);
                        return;
                    }
                    else
                    {
                        label_replayState.Text = "REPLAYING...    " + actionList[i].ToString();
                        await Task.Delay(actionList[i].DelayBeforeAction * 1000); // doesn't block UI thread
                        SetCursorPos(actionList[i].X, actionList[i].Y);
                        /** 
                         * preform the action 
                         * https://ourcodeworld.com/articles/read/520/simulating-keypress-in-the-right-way-using-inputsimulator-with-csharp-in-winforms
                         * I will create a preformAction() function which will parse the information in the object/tostring
                         * and then preform the relevant action
                         **/
                        // preformAction(i) // will pass the index of the current object to get information from the ith object in list

                    }
                }
            }

            ToggleFormSwap(true);
            isPlaying = false;
        }

        private void ToggleFormSwap(bool isVisible)
        {
            // toggle record components
            label_currentCoordinate.Visible = isVisible;
            label_storeCoordinate.Visible = isVisible;
            textBox_delayInput.Visible = isVisible;
            button_DelayAll.Visible = isVisible;
            button_DelayOne.Visible = isVisible;
            button_Record.Visible = isVisible;
            button_Remove.Visible = isVisible;
            textBox_Play.Visible = isVisible;
            button_Play.Visible = isVisible;
            listBox.Visible = isVisible;

            // toggle playback components
            label_stopPlayback.Visible = !isVisible;
            label_replayState.Visible = !isVisible;

        }

        private void DelayEntry(object sender, EventArgs e)
        {
            if (actionList.Count <= 0) { return; }
            if (listBox.SelectedIndex > actionList.Count - 1) { return; }

            try
            {
                actionList[listBox.SelectedIndex].DelayBeforeAction = (int.Parse(textBox_delayInput.Text));
                bs.ResetBindings(false);
            }
            catch
            {
                Debug.WriteLine("CANNOT PREFORM DELAY ENRTY FUNCTION");
                return;
            }
        }

        private void DelayAllEntries(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to set the delay of ALL entries?", "Confirm", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < actionList.Count; i++)
                    {
                        actionList[i].DelayBeforeAction = (int.Parse(textBox_delayInput.Text));
                        bs.ResetBindings(false);
                    }
                }
            }
            catch //catch exception for incorrect parse type of textBox_delayInput
            {
                Debug.WriteLine("CANNOT PREFORM DELAY ALLL ENTRIES FUNCTION");
                return;
            }

            bs.ResetBindings(false);
        }

        private void PreformAction()
        {
            // keyboard and mouse event simulation
            var inputSim = new InputSimulator();
            inputSim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_E);
        }
    }

    public class Action
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int DelayBeforeAction { get; set; }
        private readonly string keyChar;

        public Action(int X, int Y, int DelayBeforeAction, string keyChar)
        {
            this.X = X;
            this.Y = Y;
            this.DelayBeforeAction = DelayBeforeAction;
            this.keyChar = keyChar;
        }

        public Action(int X, int Y, string keyChar)
        {
            this.X = X;
            this.Y = Y;
            this.DelayBeforeAction = 0;
            this.keyChar = keyChar;
        }

        public override string ToString()
        {
            string b = string.Format("({0},{1})", X, Y);
            string c = string.Format("after {0} seconds", DelayBeforeAction);
            return (string.Format("{0,-7}@{1,-13}{2,-10}", keyChar, b, c)); //spacing formatting
        }
    }
}