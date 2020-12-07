
namespace PureCheat.Forms
{
    partial class TPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TPForm));
            this.AllObjectSelectionBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TeleportToAllObjButton = new System.Windows.Forms.Button();
            this.ObjectSelectionBox = new System.Windows.Forms.ComboBox();
            this.PlayerSelectionBox = new System.Windows.Forms.ComboBox();
            this.TeleportToObjButton = new System.Windows.Forms.Button();
            this.TeleportToPlayerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllObjectSelectionBox
            // 
            this.AllObjectSelectionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.AllObjectSelectionBox.ForeColor = System.Drawing.Color.White;
            this.AllObjectSelectionBox.FormattingEnabled = true;
            this.AllObjectSelectionBox.Location = new System.Drawing.Point(12, 55);
            this.AllObjectSelectionBox.Name = "AllObjectSelectionBox";
            this.AllObjectSelectionBox.Size = new System.Drawing.Size(376, 21);
            this.AllObjectSelectionBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "PureCheat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "TeleportMenu";
            // 
            // TeleportToAllObjButton
            // 
            this.TeleportToAllObjButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.TeleportToAllObjButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeleportToAllObjButton.Location = new System.Drawing.Point(12, 82);
            this.TeleportToAllObjButton.Name = "TeleportToAllObjButton";
            this.TeleportToAllObjButton.Size = new System.Drawing.Size(376, 23);
            this.TeleportToAllObjButton.TabIndex = 3;
            this.TeleportToAllObjButton.Text = "Teleport From List 1";
            this.TeleportToAllObjButton.UseVisualStyleBackColor = false;
            this.TeleportToAllObjButton.Click += new System.EventHandler(this.TeleportButton_Click);
            // 
            // ObjectSelectionBox
            // 
            this.ObjectSelectionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ObjectSelectionBox.ForeColor = System.Drawing.Color.White;
            this.ObjectSelectionBox.FormattingEnabled = true;
            this.ObjectSelectionBox.Location = new System.Drawing.Point(12, 111);
            this.ObjectSelectionBox.Name = "ObjectSelectionBox";
            this.ObjectSelectionBox.Size = new System.Drawing.Size(376, 21);
            this.ObjectSelectionBox.TabIndex = 4;
            // 
            // PlayerSelectionBox
            // 
            this.PlayerSelectionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.PlayerSelectionBox.ForeColor = System.Drawing.Color.White;
            this.PlayerSelectionBox.FormattingEnabled = true;
            this.PlayerSelectionBox.Location = new System.Drawing.Point(12, 167);
            this.PlayerSelectionBox.Name = "PlayerSelectionBox";
            this.PlayerSelectionBox.Size = new System.Drawing.Size(376, 21);
            this.PlayerSelectionBox.TabIndex = 5;
            // 
            // TeleportToObjButton
            // 
            this.TeleportToObjButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.TeleportToObjButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeleportToObjButton.Location = new System.Drawing.Point(12, 138);
            this.TeleportToObjButton.Name = "TeleportToObjButton";
            this.TeleportToObjButton.Size = new System.Drawing.Size(376, 23);
            this.TeleportToObjButton.TabIndex = 6;
            this.TeleportToObjButton.Text = "Teleport From List 2";
            this.TeleportToObjButton.UseVisualStyleBackColor = false;
            this.TeleportToObjButton.Click += new System.EventHandler(this.TeleportToObjButton_Click);
            // 
            // TeleportToPlayerButton
            // 
            this.TeleportToPlayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.TeleportToPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeleportToPlayerButton.Location = new System.Drawing.Point(12, 194);
            this.TeleportToPlayerButton.Name = "TeleportToPlayerButton";
            this.TeleportToPlayerButton.Size = new System.Drawing.Size(376, 23);
            this.TeleportToPlayerButton.TabIndex = 7;
            this.TeleportToPlayerButton.Text = "Teleport From List 3";
            this.TeleportToPlayerButton.UseVisualStyleBackColor = false;
            this.TeleportToPlayerButton.Click += new System.EventHandler(this.TeleportToPlayerButton_Click);
            // 
            // TPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(400, 240);
            this.Controls.Add(this.TeleportToPlayerButton);
            this.Controls.Add(this.TeleportToObjButton);
            this.Controls.Add(this.PlayerSelectionBox);
            this.Controls.Add(this.ObjectSelectionBox);
            this.Controls.Add(this.TeleportToAllObjButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AllObjectSelectionBox);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPToObjectForm";
            this.Load += new System.EventHandler(this.TPToObjectForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TPToObjectForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TPToObjectForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AllObjectSelectionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TeleportToAllObjButton;
        private System.Windows.Forms.ComboBox ObjectSelectionBox;
        private System.Windows.Forms.ComboBox PlayerSelectionBox;
        private System.Windows.Forms.Button TeleportToObjButton;
        private System.Windows.Forms.Button TeleportToPlayerButton;
    }
}