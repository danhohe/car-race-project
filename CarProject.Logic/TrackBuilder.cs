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
        }
    }
}
