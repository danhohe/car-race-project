using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class Section
    {
        #region properties
        public int MaxSpeed { get; set; }
        public int Length { get; set; }
        public Section? NextSection { get; private set; }
        public Section? PreviousSection { get; private set; }
        #endregion properties

        #region constructors

        public Section(int speed, int length)
        {
            MaxSpeed = speed;
            Length = length;
        }
        #endregion constructors

        public void AddAfterMe(Section section, bool closedTrack = false)
        {
            Section? tmp = NextSection;

            NextSection = section;
            if (!closedTrack)
            {
                section.NextSection = tmp;
                section.PreviousSection = this;
            }
            else
            {
                section.PreviousSection = this;
            }
        }

        public void AddBeforeMe(Section section)
        {
            Section? tmp = PreviousSection;
            PreviousSection = section;
            section.PreviousSection = tmp;
            if (tmp != null)
            {
                tmp.NextSection = section;
            }
            section.NextSection = this;
        }
    }
}
