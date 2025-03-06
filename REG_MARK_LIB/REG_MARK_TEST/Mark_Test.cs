using Microsoft.VisualStudio.TestPlatform.TestHost;
using REG_MARK_LIB;

namespace REG_MARK_TEST
{
    [TestClass]
    public class Testing_Up
    {
        [TestMethod]
        public void Cheking_for_currect_work_ChekMark()
        {
            string mark = "a999aa01";
            bool real = Mark_Lib.CheckMark(mark);
            Assert.IsTrue(real);
        }

        [TestMethod]
        public void Cheking_for_currect_work_GetNextMarkAfter()
        {
            string mark = "a999aa01";
            string real = Mark_Lib.GetNextMarkAfter(mark);
            string fact = "a999ab01";
            Assert.AreEqual(fact, real);
        }

        [TestMethod]
        public void Cheking_for_currect_work_GetNextMarkAfterInRange_IsNotNull()
        {
            string prevMark = "A999AA001";
            string rangeStart = "A001AA001";
            string rangeEnd = "B999AA995";

            string res = Mark_Lib.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void Cheking_for_currect_work_GetCombinationsCountInRange()
        {
            string mark1 = "A999AA995";
            string mark2 = "B002GB995";

            int res = Mark_Lib.GetCombinationsCountInRange(mark1, mark2);
            int fact = 28;
            Assert.AreEqual((int)fact, res);
        }
        [TestMethod]
        public void Test_GetNextMarkAfterInRange()
        {
            string prevMark = "A001AA01";
            string rangeStart = "A999AA01";
            string rangeEnd = "B999AA01";

            string res = Mark_Lib.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            string fact = "A002AA01";
            Assert.AreEqual(res, fact);

        }

        [TestMethod]
        public void Cheking_for_currect_work_GetCombinationsCountInRange_res0()
        {
            string mark1 = "A001AA777";
            string mark2 = "A001AA777";

            int res = Mark_Lib.GetCombinationsCountInRange(mark1, mark2);

            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void Cheking_for_currect_work_GetNextMarkAfterInRange()
        {
            string prevMark = "A001AA01";
            string rangeStart = "A999AA01";
            string rangeEnd = "B999AA01";

            string res = Mark_Lib.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            string fact = "A002AA01";
            Assert.AreEqual(res, fact);

        }

        public void Cheking_for_currect_work_GetNextMarkAfterInRange_overstock()
        {
            string prevMark = "B999AA777";
            string rangeStart = "A001AA777";
            string rangeEnd = "B999AA777";

            string res = Mark_Lib.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            string fact = "out of stock";
            Assert.AreEqual(res, fact);

        }

        [TestMethod]
        public void Cheking_for_currect_work_ChekMark_for_Invalid_Region()
        {
            string mark = "a999aa999";
            bool real = Mark_Lib.CheckMark(mark);
            Assert.IsFalse(real);
        }

        [TestMethod]
        public void Cheking_for_currect_work_GetNextMarkAfter_for_Invalid_Region()
        {
            string mark = "a999aa1000";
            string real = Mark_Lib.GetNextMarkAfter(mark);
            string fact = "uncorrect input";
            Assert.AreEqual(fact, real);
        }

        [TestMethod]
        public void Cheking_for_currect_work_GetNextMarkAfter_for_Invalid_symbol()
        {
            string mark = "א999קצ1000";
            string real = Mark_Lib.GetNextMarkAfter(mark);
            string fact = "uncorrect input";
            Assert.AreEqual(fact, real);
        }
    }
    [TestClass]
    public class Testing_Down
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Cheking_for_currect_work_ChekMark_with_Uncorrect_Data()
        {
            string mark = "a9!9'a0$";
            bool real = Mark_Lib.CheckMark(mark);
        }

        [TestMethod]
        public void Cheking_for_currect_work_GetNextMarkAfter_with_Space()
        {
            string mark = "a 999 aa 01";
            string real = Mark_Lib.GetNextMarkAfter(mark);
            string fact = "uncorrect input";
            Assert.AreEqual(fact, real);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Cheking_for_currect_work_GetNextMarkAfterInRange_with_Negative_Mark()
        {
            string prevMark = "-A001AA01";
            string rangeStart = "-A999AA01";
            string rangeEnd = "-B999AA01";

            string res = Mark_Lib.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            string fact = "A002AA01";
            Assert.AreEqual(res, fact);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Check_InvalidFormat_ThrowsException()
        {
            string prevMark = "-INVALID";
            string rangeStart = "-A001AA777";
            string rangeEnd = "-B999AA777";
            Mark_Lib.GetNextMarkAfterInRange("INVALID", "A001AA777", "B999AA777");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Check_EmptyString_ThrowsException()
        {
            string mark1 = "";
            string mark2 = "A002AA995";

            Mark_Lib.GetCombinationsCountInRange(mark1,mark2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Check_NonAlphanumericCharacters_ThrowsException()
        {
            Mark_Lib.GetNextMarkAfterInRange("A!99AA995", "A001AA995", "B999AA995");
        }
    }
}