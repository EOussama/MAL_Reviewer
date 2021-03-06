﻿namespace MAL_Reviewer_Core.interfaces
{
    /// <summary>
    /// What every other sub-setting should map to.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Generates default setting values for when the application first runs,
        /// also when a global reset is needed.
        /// </summary>
       void SeedSettings();

        /// <summary>
        /// Resets the settings' configurations.
        /// </summary>
        void ResetSettings();
    }
}
