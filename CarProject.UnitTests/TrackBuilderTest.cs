using CarProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackBuilderTest
    {
        [TestMethod]
        public void ItShouldBuildAConnectedTrack_GivenSectionInformation()
        {
            (int,int)[] sectionInfo = {(10,10),(20,20),(30,30)};
            TrackBuilder builder = new TrackBuilder(sectionInfo);
            
            Section firstSection = new Section(sectionInfo[0].Item1, sectionInfo[0].Item2);
            Section secondSection = new Section(sectionInfo[1].Item1, sectionInfo[1].Item2);
            Section thirdSection = new Section(sectionInfo[2].Item1, sectionInfo[2].Item2);
            
            firstSection.AddAfterMe(secondSection);
            secondSection.AddAfterMe(thirdSection);

            Track manualTrack = new([firstSection, secondSection, thirdSection]);
            
            Assert.AreEqual(10, manualTrack.StartSection.Length);
            Assert.AreEqual(10, manualTrack.StartSection.MaxSpeed);
            Assert.AreEqual(firstSection, manualTrack.StartSection);
            Assert.AreEqual(secondSection, manualTrack.StartSection.NextSection);
            Assert.AreEqual(thirdSection, manualTrack.StartSection.NextSection.NextSection);
            
            Assert.AreEqual(10, builder.RaceTrack.StartSection.Length);
            Assert.AreEqual(10, builder.RaceTrack.StartSection.MaxSpeed);
            
            Assert.AreEqual(manualTrack.StartSection.Length, builder.RaceTrack.StartSection.Length);
            Assert.AreEqual(manualTrack.StartSection.MaxSpeed, builder.RaceTrack.StartSection.MaxSpeed);
            Assert.AreEqual(manualTrack.StartSection.NextSection.Length, builder.RaceTrack.StartSection.NextSection.Length);
            Assert.AreEqual(manualTrack.StartSection.NextSection.MaxSpeed, builder.RaceTrack.StartSection.NextSection.MaxSpeed);
            Assert.AreEqual(manualTrack.StartSection.NextSection.NextSection.Length, builder.RaceTrack.StartSection.NextSection.NextSection.Length);
            Assert.AreEqual(manualTrack.StartSection.NextSection.NextSection.MaxSpeed, builder.RaceTrack.StartSection.NextSection.NextSection.MaxSpeed);
        }

        [TestMethod]
        public void ItShouldConnectTheFirstAndLastSection_GivenTrackIsALoop()
        {
            (int, int)[] sectionInfo = {(10,10),(20,20),(30,30)};
            bool closeTrack = true;
            
            TrackBuilder builder = new TrackBuilder(sectionInfo, closeTrack);
            TrackBuilder builder2 = new TrackBuilder(sectionInfo);
            
            Assert.AreEqual(builder.RaceTrack.StartSection.PreviousSection, builder.RaceTrack.StartSection.NextSection.NextSection);
        }
    }
}
