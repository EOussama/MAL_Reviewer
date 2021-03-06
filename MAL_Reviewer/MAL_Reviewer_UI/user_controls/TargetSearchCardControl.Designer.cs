﻿namespace MAL_Reviewer_UI.user_controls
{
    partial class TargetSearchCardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbTargetImage = new System.Windows.Forms.PictureBox();
            this.lTargetTitle = new System.Windows.Forms.Label();
            this.lTargetType = new System.Windows.Forms.Label();
            this.ttTitle = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbTargetImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTargetImage
            // 
            this.pbTargetImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTargetImage.Image = global::MAL_Reviewer_UI.Properties.Resources.loading_gif_control_light;
            this.pbTargetImage.Location = new System.Drawing.Point(3, 3);
            this.pbTargetImage.Name = "pbTargetImage";
            this.pbTargetImage.Size = new System.Drawing.Size(48, 48);
            this.pbTargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTargetImage.TabIndex = 0;
            this.pbTargetImage.TabStop = false;
            // 
            // lTargetTitle
            // 
            this.lTargetTitle.AutoSize = true;
            this.lTargetTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lTargetTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetTitle.Location = new System.Drawing.Point(57, 3);
            this.lTargetTitle.Name = "lTargetTitle";
            this.lTargetTitle.Size = new System.Drawing.Size(65, 19);
            this.lTargetTitle.TabIndex = 1;
            this.lTargetTitle.Text = "Paprika";
            // 
            // lTargetType
            // 
            this.lTargetType.AutoSize = true;
            this.lTargetType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lTargetType.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetType.Location = new System.Drawing.Point(58, 22);
            this.lTargetType.Name = "lTargetType";
            this.lTargetType.Size = new System.Drawing.Size(46, 13);
            this.lTargetType.TabIndex = 2;
            this.lTargetType.Text = "Paprika";
            // 
            // ttTitle
            // 
            this.ttTitle.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // TargetSearchCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lTargetType);
            this.Controls.Add(this.lTargetTitle);
            this.Controls.Add(this.pbTargetImage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "TargetSearchCardControl";
            this.Size = new System.Drawing.Size(230, 54);
            ((System.ComponentModel.ISupportInitialize)(this.pbTargetImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTargetImage;
        private System.Windows.Forms.Label lTargetTitle;
        private System.Windows.Forms.Label lTargetType;
        private System.Windows.Forms.ToolTip ttTitle;
    }
}
