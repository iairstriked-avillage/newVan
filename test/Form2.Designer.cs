namespace test
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            groupBox1 = new GroupBox();
            button3 = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Location = new Point(160, 176);
            button1.Name = "button1";
            button1.Size = new Size(148, 23);
            button1.TabIndex = 1;
            button1.Text = "Apply Settings";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.System;
            button2.Location = new Point(12, 176);
            button2.Name = "button2";
            button2.Size = new Size(142, 23);
            button2.TabIndex = 2;
            button2.Text = "Restart Application";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(173, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Use basic theme style flyout";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(12, 10);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(231, 19);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "Movable main flyout with close button";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Location = new Point(12, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 50);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Does not work";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.System;
            button3.Location = new Point(12, 147);
            button3.Name = "button3";
            button3.Size = new Size(296, 23);
            button3.TabIndex = 7;
            button3.Text = "Make this Network Flyout a startup application";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.System;
            button4.Location = new Point(12, 35);
            button4.Name = "button4";
            button4.Size = new Size(296, 23);
            button4.TabIndex = 8;
            button4.Text = "Reset position";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 211);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(groupBox1);
            Controls.Add(checkBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form2";
            Text = "Network Flyout Settings";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private GroupBox groupBox1;
        private Button button3;
        private Button button4;
    }
}