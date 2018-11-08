﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;
using MAL_Reviewer_API.models.ListEntryModel;

namespace MAL_Reviwer_UI.forms
{
    public partial class fLoadUser : Form
    {
        private bool
            ready = true,
            allow = true;

        private CancellationTokenSource cts;
        public event EventHandler<MALUserModel> UserLoadedEvent;

        public fLoadUser()
        {
            InitializeComponent();
            this.ActiveControl = tbMALUsername;

            cts = new CancellationTokenSource();
        }

        private async void BLoad_Click(object sender, EventArgs e)
        {
            string username = tbMALUsername.Text.Trim();

            bLoad.Enabled = false;
            pbLoading.Visible = true;
            this.ready = false;

            try
            {
                if (username.Length < 3) throw new Exception("Please input a valid username!");

                // Get the data of the user.
                MALUserModel userModel = await MALHelper.GetUser(username, cts.Token);
                List<AnimelistEntryModel> animeList = await MALHelper.GetAnimeList(username, (int)userModel.anime_stats.total_entries, cts.Token);
                List<MangalistEntryModel> mangaList = await MALHelper.GetMangaList(username, (int)userModel.manga_stats.total_entries, cts.Token);

                if (userModel == null) throw new Exception($"No user under the username “{ username }” was found!");
                else
                {
                    if (this.allow)
                    {
                        this.ready = true;
                        this.Close();

                        userModel.animeList = animeList;
                        userModel.mangaList = mangaList;
                        UserLoadedEvent?.Invoke(this, userModel);
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.allow)
                    MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (this.allow)
                {
                    pbLoading.Visible = false;
                    bLoad.Enabled = true;
                    this.ready = true;
                    this.ActiveControl = tbMALUsername;
                }
            }
        }

        private void LlNoAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("https://myanimelist.net/register.php");

        private void FLoadUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ready)
            {
                cts.Cancel();
                this.allow = false;
            }
        }
    }
}
