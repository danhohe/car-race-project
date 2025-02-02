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

        public Track RaceTrack { get; }

        public TrackBuilder((int, int)[] sectionInfo)
        {
            _sectionInfo = sectionInfo;
            
            List<Section> sections = new List<Section>();
            Section? helperSection = null;

            foreach (var section in sectionInfo)
            {
                Section newSection = new(section.Item1, section.Item2);

                if (sections.Count > 0)
                {
                    helperSection.AddAfterMe(newSection);
                }
                helperSection = newSection;
                sections.Add(newSection);
            }
            RaceTrack = new Track(sections);
        }
    }
}
