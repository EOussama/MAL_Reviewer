﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MAL_Reviwer_UI.user_controls
{
    public partial class Card : UserControl
    {
        public string Title
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        public Image Icon
        {
            get => IconPictureBox.Image;
            set => IconPictureBox.Image = value;
        }

        public Color BackgroundColor
        {
            get => this.BackColor;
            set {
                this.BackColor = value;
                IconPictureBox.BackColor = value;
            }
        }

        public Color ShadowColor
        {
            get => BottomShadowPanel.BackColor;
            set => BottomShadowPanel.BackColor = value;
        }

        public Panel Content
        {
            get => ContentPanel;
        }

        public bool LabelVisibility
        {
            get => LabelLabel.Visible;
            set => LabelLabel.Visible = value;
        }

        public string LabelText
        {
            get => LabelLabel.Text;
            set => LabelLabel.Text = value;
        }

        public Card()
        {
            InitializeComponent();
        }

        public void UpdateTooltip(string username)
        {
            LabelInfoToolTip.ToolTipTitle = $"{Title}";
            LabelInfoToolTip.SetToolTip(LabelLabel, $"{username}'s {Title.Split(' ')[0].ToLower()} list is {LabelLabel.Text.ToLower()}.");
        }
    }
}
