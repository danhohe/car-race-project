using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class TrackBuilder
    {
        private (int, int)[] _sectionInfo;
        private Track _track;
        
        public Track RaceTrack => _track;

        public TrackBuilder((int, int)[] sectionInfo, bool isLoop = false)
        {
            this._sectionInfo = sectionInfo;
            
            List<Section> sections = new List<Section>();
            Section? lastSection = null;

            foreach (var section in sectionInfo)
            {
                Section newSection = new(section.Item1, section.Item2);

                if (sections.Count > 0)
                {
                    lastSection.AddAfterMe(newSection);
                }
                lastSection = newSection;
                sections.Add(newSection);
            }
        }
    }
}
