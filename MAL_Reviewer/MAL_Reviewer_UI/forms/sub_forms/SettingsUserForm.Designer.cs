﻿namespace MAL_Reviewer_UI.forms.sub_forms
{
    partial class SettingsUserForm
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.linePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.UserSettingsResetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.AutoScroll = true;
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Location = new System.Drawing.Point(12, 94);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(512, 366);
            this.contentPanel.TabIndex = 26;
            // 
            // linePanel
            // 
            this.linePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linePanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.linePanel.Location = new System.Drawing.Point(12, 51);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(512, 5);
            this.linePanel.TabIndex = 25;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new System.Drawing.Point(12, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(136, 25);
            this.titleLabel.TabIndex = 24;
            this.titleLabel.Text = "User settings";
            // 
            // UserSettingsResetButton
            // 
            this.UserSettingsResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserSettingsResetButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.UserSettingsResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserSettingsResetButton.FlatAppearance.BorderSize = 0;
            this.UserSettingsResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserSettingsResetButton.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserSettingsResetButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UserSettingsResetButton.Location = new System.Drawing.Point(432, 12);
            this.UserSettingsResetButton.Name = "UserSettingsResetButton";
            this.UserSettingsResetButton.Size = new System.Drawing.Size(92, 33);
            this.UserSettingsResetButton.TabIndex = 28;
            this.UserSettingsResetButton.Text = "Reset settings";
            this.UserSettingsResetButton.UseVisualStyleBackColor = false;
            // 
            // SettingsUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(536, 473);
            this.Controls.Add(this.UserSettingsResetButton);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.titleLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button UserSettingsResetButton;
    }
}