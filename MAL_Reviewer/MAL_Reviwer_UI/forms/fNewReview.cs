﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MAL_Reviwer_UI.user_controls;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;

namespace MAL_Reviwer_UI.forms
{
    public partial class fNewReview : Form
    {
        private bool
            ready = true,
            allow = true;

        private int targetId = 0;
        private byte type = 0;
        private string lastSearch = string.Empty;
        private System.Windows.Forms.Timer inputDelay;
        private CancellationTokenSource cts;

        public fNewReview()
        {
            InitializeComponent();
            this.ActiveControl = tbSearch;

            // Wiring up eventhandlers to the radio buttons
            rbAnime.CheckedChanged += RbAnime_CheckedChanged;
            rbScaleOther.CheckedChanged += RbScaleOther_CheckedChanged;

            // Disabeling horizontal scroll on pSearchCards.
            pSearchCards.HorizontalScroll.Maximum = 0;
            pSearchCards.AutoScroll = true;

            // Populating the pSearchCards panel with ucTargetSearchCard user controls.
            foreach (int i in Enumerable.Range(1, 10))
            {
                ucTargetSearchCard searchCard = new ucTargetSearchCard();
                int searchCardCount = pSearchCards.Controls.Count;

                if (searchCardCount < 5)
                    pSearchCards.Height = searchCard.Height * searchCardCount;

                searchCard.CardMouseClickEvent += SearchCard_CardMouseClickEvent;
                searchCard.Top = searchCard.Height * searchCardCount;
                searchCard.Visible = false;
                pSearchCards.Controls.Add(searchCard);
            }

            // input delay timer setup.
            this.inputDelay = new System.Windows.Forms.Timer
            {
                Interval = 500
            };
            this.inputDelay.Tick += _inputDelay_Tick;

            cts = new CancellationTokenSource();
        }

        #region Manga/Anime labeling

        private void RbScaleOther_CheckedChanged(object sender, EventArgs e) => nupScaleOther.Enabled = rbScaleOther.Checked;

        private void RbAnime_CheckedChanged(object sender, EventArgs e)
        {
            lTitle.Text = $"{ (rbAnime.Checked ? rbAnime.Text : rbManga.Text) } title";
            lPreview.Text = $"{ (rbAnime.Checked ? rbAnime.Text : rbManga.Text) } preview";
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
            TbSearch_TextChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Target Search

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            string _currentSearch = tbSearch.Text.Trim().ToLower();

            // Check if the search request has already been sent or not.
           if (!this.ready || _currentSearch.Length < 3)
            {
                pSearchCards.Visible = false;
                return;
            }

            // Reset the input timer.
            this.inputDelay.Stop();
            this.inputDelay.Start();
        }

        private async void _inputDelay_Tick(object sender, EventArgs e)
        {
            this.inputDelay.Stop();
            tbSearch.Enabled = false;

            try
            {
                string
                    searchTitle = tbSearch.Text.Trim().ToLower(),
                    searchType = rbAnime.Checked ? rbAnime.Text.ToLower() : rbManga.Text.ToLower();

                if (this.lastSearch == searchTitle && this.type == (rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString())))
                    return;

                this.lastSearch = searchTitle;
                this.type = (byte)(rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString()));
                pbLoading.Visible = true;
                pSearchCards.Visible = false;
                rbAnime.Enabled = false;
                rbManga.Enabled = false;
                this.ready = false;

                SearchModel searchModel = await MALHelper.Search(searchType, searchTitle, cts.Token);

                if (searchModel != null && searchModel.results != null)
                {
                    // Updating the ucTargetSearchCard usercontrolls in a separate thread.
                    int resultCount = searchModel.results.Length;
                    List<Task> tasks = new List<Task>();

                    for (int i = 0; i < pSearchCards.Controls.Count; i++)
                    {
                        ucTargetSearchCard searchCard = (ucTargetSearchCard)pSearchCards.Controls[i];

                        if (i < resultCount)
                        {
                            SearchResultsModel resultsModel = searchModel.results[i];
                            tasks.Add(
                                Task.Run(() =>
                                {
                                    searchCard.Invoke((MethodInvoker)delegate
                                    {
                                        searchCard.UpdateUI(resultsModel.mal_id, resultsModel.title, resultsModel.type, resultsModel.image_url, rbAnime.Checked ? rbAnime.Text : rbManga.Text);
                                        searchCard.Visible = true;
                                    });
                                })
                            );
                        }
                        else
                        {
                            searchCard.Invoke((MethodInvoker)delegate
                            {
                                searchCard.Visible = false;
                            });
                        }
                    }

                    await Task.WhenAll(tasks);
                    pSearchCards.Visible = true;
                }
            }
            catch (Exception ex)
            {
                if (this.allow)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (this.allow)
                {
                    tbSearch.Enabled = true;
                    pbLoading.Visible = false;
                    rbAnime.Enabled = true;
                    rbManga.Enabled = true;
                    this.ready = true;
                }
            }
        }

        private void SearchCard_CardMouseClickEvent(object sender, int targetId)
        {
            // Checking if the targetId isn't equal to the current previewed Anime/Manga's mal_id.
            if (this.targetId == targetId && this.type  == (rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString())))
                return;

            pPreview.Visible = false;
            pbLoadingPreview.Visible = true;

            if (rbAnime.Checked)
                PreviewAnime(targetId);
            else
                PreviewManga(targetId);
        }

        private void TbSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && tbSearch.Focused && tbSearch.Text.Trim().Length > 2 && pSearchCards.Controls.Count > 0 && pSearchCards.Visible == false)
                pSearchCards.Visible = true;
        }

        private void PbShow_MouseClick(object sender, MouseEventArgs e)
        {
            pSearchCards.Visible = false;
            pbShow.Cursor = Cursors.Default;
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
        }

        private void PbShow_MouseEnter(object sender, EventArgs e)
        {
            if (tbSearch.Text.Trim().Length > 2 && pSearchCards.Controls.Count > 0 && pSearchCards.Controls[0]?.Visible == true && pSearchCards.Visible == true)
            {
                pbShow.Cursor = Cursors.Hand;
                pbShow.Image = Properties.Resources.icon_close;
            }
            else
            {
                pbShow.Cursor = Cursors.Default;
            }
        }

        private void PbShow_MouseLeave(object sender, EventArgs e) => pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);

        #endregion

        #region Preview section update

        private async void PreviewAnime(int animeId)
        {
            try
            {
                AnimeModel animeModel = await MALHelper.GetAnime(animeId);

                // Updating the preview UI in a separate thread.
                await Task.Run(() =>
                {
                    cts.Token.ThrowIfCancellationRequested();

                    if (pPreview.IsDisposed)
                    {
                        pPreview.Invoke((MethodInvoker)delegate
                        {
                            lChapters.Visible = false;
                            lTargetChapters.Visible = false;
                            lVolumesEpisodes.Text = "Episodes";

                            lTargetScore.Text = animeModel.score?.ToString("0.00");
                            lTargetRank.Text = animeModel.rank.ToString();
                            lTargetType.Text = animeModel.type;
                            lTargetStatus.Text = animeModel.airing ? "Airing" : "Finished";
                            lTargetVolumesEpisodes.Text = animeModel.episodes != null ? animeModel.episodes.ToString() : "?";
                            lTargetTitle.Text = animeModel.title.Length > 55 ? animeModel.title.Substring(0, 55) + "..." : animeModel.title;
                            lTargetSynopsis.Text = animeModel.synopsis?.Length > 215 ? animeModel.synopsis?.Substring(0, 215) + "..." : animeModel.synopsis;
                            pbTargetImage.Load(animeModel.image_url);
                            bMAL.Tag = animeModel.url;

                            this.targetId = animeModel.mal_id;
                            this.type = 0;
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                if (this.allow)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (this.allow)
                {
                    pSearchCards.Visible = false;
                    pbLoadingPreview.Visible = false;
                    pPreview.Visible = true;
                }
            }
        }

        private async void PreviewManga(int mangaId)
        {
            try
            {
                MangaModel mangaModel = await MALHelper.GetManga(mangaId);

                // Updating the preview UI in a separate thread.
                await Task.Run(() =>
                {
                    pPreview.Invoke((MethodInvoker)delegate
                    {
                        lChapters.Visible = true;
                        lTargetChapters.Visible = true;
                        lVolumesEpisodes.Text = "Volumes";

                        lTargetScore.Text = mangaModel.score?.ToString("0.00");
                        lTargetRank.Text = mangaModel.rank.ToString();
                        lTargetType.Text = mangaModel.type;
                        lTargetStatus.Text = mangaModel.publishing ? "Publishing" : "Finished";
                        lTargetVolumesEpisodes.Text = mangaModel.volumes != null ? mangaModel.volumes.ToString() : "?";
                        lTargetChapters.Text = mangaModel.chapters != null ? mangaModel.chapters.ToString() : "?";
                        lTargetTitle.Text = mangaModel.title.Length > 55 ? mangaModel.title.Substring(0, 55) + "..." : mangaModel.title;
                        lTargetSynopsis.Text = mangaModel.synopsis?.Length > 215 ? mangaModel.synopsis?.Substring(0, 215) + "..." : mangaModel.synopsis;
                        pbTargetImage.Load(mangaModel.image_url);
                        bMAL.Tag = mangaModel.url;

                        this.targetId = mangaModel.mal_id;
                        this.type = 1;
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                pSearchCards.Visible = false;
                pbLoadingPreview.Visible = false;
                pPreview.Visible = true;
            }
        }

        private void BMAL_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        #endregion

        private void FNewReview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ready)
            {
                cts.Cancel();
                this.allow = false;
            }
        }
    }
}