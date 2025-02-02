using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class Track
    {
        private List<Section> _trackList;
        
        public Track(List<Section> trackList, bool closedTrack = false)
        {
            this._trackList = trackList;

            if (closedTrack)
            {
                _trackList.Last().AddAfterMe(_trackList.First(), closedTrack);
            }
        }

        public Section? StartSection { get => _trackList[0]; }
    }
}
