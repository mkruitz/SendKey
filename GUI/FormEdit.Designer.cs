namespace GUI
{
    partial class FormEdit
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSetName = new System.Windows.Forms.TextBox();
            this.textBoxTitleStartsWith = new System.Windows.Forms.TextBox();
            this.textBoxProcessName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxKeysToSend = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Name";
            // 
            // textBoxSetName
            // 
            this.textBoxSetName.Location = new System.Drawing.Point(12, 22);
            this.textBoxSetName.Name = "textBoxSetName";
            this.textBoxSetName.Size = new System.Drawing.Size(208, 20);
            this.textBoxSetName.TabIndex = 9;
            // 
            // textBoxTitleStartsWith
            // 
            this.textBoxTitleStartsWith.Location = new System.Drawing.Point(91, 298);
            this.textBoxTitleStartsWith.Name = "textBoxTitleStartsWith";
            this.textBoxTitleStartsWith.Size = new System.Drawing.Size(128, 20);
            this.textBoxTitleStartsWith.TabIndex = 14;
            // 
            // textBoxProcessName
            // 
            this.textBoxProcessName.Location = new System.Drawing.Point(11, 298);
            this.textBoxProcessName.Name = "textBoxProcessName";
            this.textBoxProcessName.Size = new System.Drawing.Size(74, 20);
            this.textBoxProcessName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Title starts with";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Process";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(11, 323);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 39);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(119, 323);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 39);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxKeysToSend
            // 
            this.textBoxKeysToSend.AcceptsReturn = true;
            this.textBoxKeysToSend.Location = new System.Drawing.Point(12, 63);
            this.textBoxKeysToSend.Multiline = true;
            this.textBoxKeysToSend.Name = "textBoxKeysToSend";
            this.textBoxKeysToSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxKeysToSend.Size = new System.Drawing.Size(208, 137);
            this.textBoxKeysToSend.TabIndex = 18;
            this.textBoxKeysToSend.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Commands to Send";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 79);
            this.label5.TabIndex = 20;
            this.label5.Text = "Vul in bovenstaand vak het scan command in. \r\nElk nieuwe regel is een nieuw comma" +
    "ndo. \r\nVerder kunnen er keys als \r\n{ENTER} en {TAB} gebruikt worden.";
            // 
            // FormEdit
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(231, 368);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxKeysToSend);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxTitleStartsWith);
            this.Controls.Add(this.textBoxProcessName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSetName);
            this.Name = "FormEdit";
            this.Text = "FormEdit";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSetName;
        private System.Windows.Forms.TextBox textBoxTitleStartsWith;
        private System.Windows.Forms.TextBox textBoxProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxKeysToSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}