namespace Mouse_and_Keyboard_Automation_1._1
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_currentCoordinate = new System.Windows.Forms.Label();
            this.label_formListener = new System.Windows.Forms.Label();
            this.label_storeCoordinate = new System.Windows.Forms.Label();
            this.button_Record = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.textBox_delayInput = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.actionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_DelayOne = new System.Windows.Forms.Button();
            this.label_playbackState = new System.Windows.Forms.Label();
            this.button_DelayAll = new System.Windows.Forms.Button();
            this.label_replayState = new System.Windows.Forms.Label();
            this.label_stopPlayback = new System.Windows.Forms.Label();
            this.button_Play = new System.Windows.Forms.Button();
            this.textBox_Play = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.actionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label_currentCoordinate
            // 
            this.label_currentCoordinate.AutoSize = true;
            this.label_currentCoordinate.Location = new System.Drawing.Point(10, 8);
            this.label_currentCoordinate.Name = "label_currentCoordinate";
            this.label_currentCoordinate.Size = new System.Drawing.Size(91, 13);
            this.label_currentCoordinate.TabIndex = 0;
            this.label_currentCoordinate.Text = "currentCoordinate";
            this.label_currentCoordinate.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.label_currentCoordinate.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // label_formListener
            // 
            this.label_formListener.AutoSize = true;
            this.label_formListener.Location = new System.Drawing.Point(211, 162);
            this.label_formListener.Name = "label_formListener";
            this.label_formListener.Size = new System.Drawing.Size(61, 13);
            this.label_formListener.TabIndex = 1;
            this.label_formListener.Text = "cursorState";
            this.label_formListener.Visible = false;
            this.label_formListener.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.label_formListener.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // label_storeCoordinate
            // 
            this.label_storeCoordinate.AutoSize = true;
            this.label_storeCoordinate.Location = new System.Drawing.Point(10, 30);
            this.label_storeCoordinate.Name = "label_storeCoordinate";
            this.label_storeCoordinate.Size = new System.Drawing.Size(81, 13);
            this.label_storeCoordinate.TabIndex = 2;
            this.label_storeCoordinate.Text = "storeCoordinate";
            this.label_storeCoordinate.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.label_storeCoordinate.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // button_Record
            // 
            this.button_Record.BackColor = System.Drawing.Color.White;
            this.button_Record.Location = new System.Drawing.Point(10, 59);
            this.button_Record.Name = "button_Record";
            this.button_Record.Size = new System.Drawing.Size(155, 20);
            this.button_Record.TabIndex = 3;
            this.button_Record.Text = "Record";
            this.button_Record.UseVisualStyleBackColor = false;
            this.button_Record.Click += new System.EventHandler(this.ToggleRecording);
            this.button_Record.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.button_Record.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(10, 84);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(155, 20);
            this.button_Remove.TabIndex = 4;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.RemoveEntry);
            this.button_Remove.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.button_Remove.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // textBox_delayInput
            // 
            this.textBox_delayInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_delayInput.Location = new System.Drawing.Point(171, 112);
            this.textBox_delayInput.Name = "textBox_delayInput";
            this.textBox_delayInput.Size = new System.Drawing.Size(35, 13);
            this.textBox_delayInput.TabIndex = 6;
            this.textBox_delayInput.Text = "XXX";
            this.textBox_delayInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_delayInput.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.textBox_delayInput.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.DataSource = this.actionBindingSource;
            this.listBox.Font = new System.Drawing.Font("Courier New", 9F);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(211, 8);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(277, 139);
            this.listBox.TabIndex = 7;
            this.listBox.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.listBox.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // button_DelayOne
            // 
            this.button_DelayOne.Location = new System.Drawing.Point(75, 109);
            this.button_DelayOne.Name = "button_DelayOne";
            this.button_DelayOne.Size = new System.Drawing.Size(90, 20);
            this.button_DelayOne.TabIndex = 8;
            this.button_DelayOne.Text = "DelayOne";
            this.button_DelayOne.UseVisualStyleBackColor = true;
            this.button_DelayOne.Click += new System.EventHandler(this.DelayEntry);
            this.button_DelayOne.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.button_DelayOne.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // label_playbackState
            // 
            this.label_playbackState.AutoSize = true;
            this.label_playbackState.Location = new System.Drawing.Point(418, 162);
            this.label_playbackState.Name = "label_playbackState";
            this.label_playbackState.Size = new System.Drawing.Size(75, 13);
            this.label_playbackState.TabIndex = 9;
            this.label_playbackState.Text = "playbackState";
            this.label_playbackState.Visible = false;
            // 
            // button_DelayAll
            // 
            this.button_DelayAll.Location = new System.Drawing.Point(10, 109);
            this.button_DelayAll.Name = "button_DelayAll";
            this.button_DelayAll.Size = new System.Drawing.Size(60, 20);
            this.button_DelayAll.TabIndex = 10;
            this.button_DelayAll.Text = "DelayAll";
            this.button_DelayAll.UseVisualStyleBackColor = true;
            this.button_DelayAll.Click += new System.EventHandler(this.DelayAllEntries);
            this.button_DelayAll.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.button_DelayAll.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // label_replayState
            // 
            this.label_replayState.AutoSize = true;
            this.label_replayState.Location = new System.Drawing.Point(100, 94);
            this.label_replayState.Name = "label_replayState";
            this.label_replayState.Size = new System.Drawing.Size(60, 13);
            this.label_replayState.TabIndex = 11;
            this.label_replayState.Text = "replayState";
            this.label_replayState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_replayState.Visible = false;
            // 
            // label_stopPlayback
            // 
            this.label_stopPlayback.AutoSize = true;
            this.label_stopPlayback.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label_stopPlayback.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_stopPlayback.Location = new System.Drawing.Point(75, 73);
            this.label_stopPlayback.Name = "label_stopPlayback";
            this.label_stopPlayback.Size = new System.Drawing.Size(334, 21);
            this.label_stopPlayback.TabIndex = 12;
            this.label_stopPlayback.Text = "PRESS \";\" TO STOP THE REPLAY PREEMPTIVELY";
            this.label_stopPlayback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_stopPlayback.Visible = false;
            // 
            // button_Play
            // 
            this.button_Play.Location = new System.Drawing.Point(10, 134);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(155, 20);
            this.button_Play.TabIndex = 5;
            this.button_Play.Text = "Play";
            this.button_Play.UseVisualStyleBackColor = true;
            this.button_Play.Click += new System.EventHandler(this.StartPlayback);
            this.button_Play.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.button_Play.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            // 
            // textBox_Play
            // 
            this.textBox_Play.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Play.Location = new System.Drawing.Point(171, 138);
            this.textBox_Play.Name = "textBox_Play";
            this.textBox_Play.Size = new System.Drawing.Size(35, 13);
            this.textBox_Play.TabIndex = 13;
            this.textBox_Play.Text = "XXX";
            this.textBox_Play.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 186);
            this.Controls.Add(this.textBox_Play);
            this.Controls.Add(this.label_formListener);
            this.Controls.Add(this.button_DelayAll);
            this.Controls.Add(this.label_playbackState);
            this.Controls.Add(this.textBox_delayInput);
            this.Controls.Add(this.button_Play);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Record);
            this.Controls.Add(this.label_storeCoordinate);
            this.Controls.Add(this.label_currentCoordinate);
            this.Controls.Add(this.button_DelayOne);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label_replayState);
            this.Controls.Add(this.label_stopPlayback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form";
            this.Text = "Mouse and Keyboard Automation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseForm);
            this.Load += new System.EventHandler(this.LoadForm);
            this.MouseEnter += new System.EventHandler(this.MouseEnterForm);
            this.MouseLeave += new System.EventHandler(this.MouseLeaveForm);
            ((System.ComponentModel.ISupportInitialize)(this.actionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_currentCoordinate;
        private Label label_formListener;
        private Label label_storeCoordinate;
        private Button button_Record;
        private Button button_Remove;
        private TextBox textBox_delayInput;
        private ListBox listBox;
        private Button button_DelayOne;
        private BindingSource actionBindingSource;
        private Label label_playbackState;
        private Button button_DelayAll;
        private Label label_replayState;
        private Label label_stopPlayback;
        private Button button_Play;
        private TextBox textBox_Play;
    }
}