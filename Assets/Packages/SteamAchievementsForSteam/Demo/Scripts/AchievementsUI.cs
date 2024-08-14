using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;
using UnityEngine;

namespace LeastSquares
{
    /// <summary>
    /// Script that retrieves the achievements and loads them into the UI
    /// </summary>
    public class AchievementsUI : MonoBehaviour
    {
        public GameObject EntryPrefab;
        public SteamAchievementsAndStats AchievementsAndStats;
        private List<GameObject> _rows = new ();

        /// <summary>
        /// Called when the go updates
        /// </summary>
        void Update()
        {
            if (_rows.Count != AchievementsAndStats.Achievements.Length)
                RegenerateUI(AchievementsAndStats.Achievements);
        }
        
        
        /// <summary>
        /// Regenerate the UI
        /// </summary>
        /// <param name="achievements">The given achievements</param>
        async void RegenerateUI(Achievement[] achievements)
        {
            var oldRows = _rows;
            _rows = new List<GameObject>();
            for (var i = 0; i < achievements.Length; i++)
            {
                var go = await CreateRow(achievements[i]);
                
                _rows.Add(go);
            }

            for (var i = 0; i < oldRows.Count; i++)
            {
                Destroy(oldRows[i]);
            }
        }
        
        /// <summary>
        /// Create an achievement row element
        /// </summary>
        /// <param name="entry">The given achievement object</param>
        /// <returns>The game object created</returns>
        private async Task<GameObject> CreateRow(Achievement entry)
        {
            var go = Instantiate(EntryPrefab, transform);
            var row = go.GetComponent<AchievementUIRow>();
            await row.SetAchievement(entry);
            return go;
        }

    }
}