using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace LeastSquares
{
    /// <summary>
    /// Class that represents a UI row for an achievement
    /// </summary>
    public class AchievementUIRow : MonoBehaviour
    {
        public Image Avatar;
        public TMP_Text Name;
        private Achievement _achievement;

        /// <summary>
        /// Trigger the achievement this row represents
        /// </summary>
        public async void Trigger()
        {
            _achievement.Trigger();
            // Refresh the icon
            await SetAchievement(_achievement);
        }
        
        /// <summary>
        /// Set the achievement to this row and load the associated information
        /// </summary>
        /// <param name="ach">The given achievement</param>
        public async Task SetAchievement(Achievement ach)
        {
            _achievement = ach;
            Name.text = ach.Name;
            var maybeImage = await ach.GetIconAsync();
            if (maybeImage.HasValue)
            {
                var tex2D = maybeImage.Value.Convert();
                Avatar.sprite = Sprite.Create(tex2D, new Rect(0, 0, tex2D.width, tex2D.height), Vector2.zero);
            }
        }
    }
}