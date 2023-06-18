namespace Notifications;

partial class Form1
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
            this.SelectionButton = new System.Windows.Forms.Button();
            this.StopScheduledNotificationButton = new System.Windows.Forms.Button();
            this.DownLoadButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.TextInputButton = new System.Windows.Forms.Button();
            this.AlarmButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.HeroButton = new System.Windows.Forms.Button();
            this.InterceptButton = new System.Windows.Forms.Button();
            this.TaxpayerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectionButton
            // 
            this.SelectionButton.Location = new System.Drawing.Point(25, 329);
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new System.Drawing.Size(295, 29);
            this.SelectionButton.TabIndex = 17;
            this.SelectionButton.Text = "Select time interval";
            this.SelectionButton.UseVisualStyleBackColor = true;
            this.SelectionButton.Click += new System.EventHandler(this.SelectionButton_Click);
            // 
            // StopScheduledNotificationButton
            // 
            this.StopScheduledNotificationButton.Location = new System.Drawing.Point(25, 294);
            this.StopScheduledNotificationButton.Name = "StopScheduledNotificationButton";
            this.StopScheduledNotificationButton.Size = new System.Drawing.Size(295, 29);
            this.StopScheduledNotificationButton.TabIndex = 16;
            this.StopScheduledNotificationButton.Text = "Stop annoying notification";
            this.StopScheduledNotificationButton.UseVisualStyleBackColor = true;
            this.StopScheduledNotificationButton.Click += new System.EventHandler(this.StopScheduledNotificationButton_Click);
            // 
            // DownLoadButton
            // 
            this.DownLoadButton.Location = new System.Drawing.Point(25, 224);
            this.DownLoadButton.Name = "DownLoadButton";
            this.DownLoadButton.Size = new System.Drawing.Size(295, 29);
            this.DownLoadButton.TabIndex = 14;
            this.DownLoadButton.Text = "Download";
            this.DownLoadButton.UseVisualStyleBackColor = true;
            this.DownLoadButton.Click += new System.EventHandler(this.DownLoadButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(25, 189);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(295, 29);
            this.SelectButton.TabIndex = 13;
            this.SelectButton.Text = "ComboBox";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // TextInputButton
            // 
            this.TextInputButton.Location = new System.Drawing.Point(25, 154);
            this.TextInputButton.Name = "TextInputButton";
            this.TextInputButton.Size = new System.Drawing.Size(295, 29);
            this.TextInputButton.TabIndex = 12;
            this.TextInputButton.Text = "Text input";
            this.TextInputButton.UseVisualStyleBackColor = true;
            this.TextInputButton.Click += new System.EventHandler(this.TextInputButton_Click);
            // 
            // AlarmButton
            // 
            this.AlarmButton.Location = new System.Drawing.Point(25, 119);
            this.AlarmButton.Name = "AlarmButton";
            this.AlarmButton.Size = new System.Drawing.Size(295, 29);
            this.AlarmButton.TabIndex = 11;
            this.AlarmButton.Text = "Alarm";
            this.AlarmButton.UseVisualStyleBackColor = true;
            this.AlarmButton.Click += new System.EventHandler(this.AlarmButton_Click);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(25, 84);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(295, 29);
            this.ScheduleButton.TabIndex = 10;
            this.ScheduleButton.Text = "Schedule - in five seconds";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);
            // 
            // HeroButton
            // 
            this.HeroButton.Location = new System.Drawing.Point(25, 49);
            this.HeroButton.Name = "HeroButton";
            this.HeroButton.Size = new System.Drawing.Size(295, 29);
            this.HeroButton.TabIndex = 9;
            this.HeroButton.Text = "Hero";
            this.HeroButton.UseVisualStyleBackColor = true;
            this.HeroButton.Click += new System.EventHandler(this.HeroButton_Click);
            // 
            // InterceptButton
            // 
            this.InterceptButton.Location = new System.Drawing.Point(25, 259);
            this.InterceptButton.Name = "InterceptButton";
            this.InterceptButton.Size = new System.Drawing.Size(295, 29);
            this.InterceptButton.TabIndex = 15;
            this.InterceptButton.Text = "Intercept";
            this.InterceptButton.UseVisualStyleBackColor = true;
            this.InterceptButton.Click += new System.EventHandler(this.InterceptButton_Click);
            // 
            // TaxpayerButton
            // 
            this.TaxpayerButton.Location = new System.Drawing.Point(25, 366);
            this.TaxpayerButton.Name = "TaxpayerButton";
            this.TaxpayerButton.Size = new System.Drawing.Size(295, 29);
            this.TaxpayerButton.TabIndex = 18;
            this.TaxpayerButton.Text = "Add taxpayers";
            this.TaxpayerButton.UseVisualStyleBackColor = true;
            this.TaxpayerButton.Click += new System.EventHandler(this.TaxpayerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 426);
            this.Controls.Add(this.TaxpayerButton);
            this.Controls.Add(this.SelectionButton);
            this.Controls.Add(this.StopScheduledNotificationButton);
            this.Controls.Add(this.DownLoadButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.TextInputButton);
            this.Controls.Add(this.AlarmButton);
            this.Controls.Add(this.ScheduleButton);
            this.Controls.Add(this.HeroButton);
            this.Controls.Add(this.InterceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toast";
            this.ResumeLayout(false);

    }

    #endregion

    private Button SelectionButton;
    private Button StopScheduledNotificationButton;
    private Button DownLoadButton;
    private Button SelectButton;
    private Button TextInputButton;
    private Button AlarmButton;
    private Button ScheduleButton;
    private Button HeroButton;
    private Button InterceptButton;
    private Button TaxpayerButton;
}
