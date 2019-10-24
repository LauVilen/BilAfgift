using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class UnitTest
    {
        //test v�rdi under 200000
        [TestMethod]
        public void TestBilligBil()
        {
            int pris = 25000;

            //Beregning af afgift for normal bil
            Assert.AreEqual(21250, Afgift.BilAfgift(pris));

            //Beregning for elbil
            Assert.AreEqual(4250, Afgift.ElbilAfgift(pris));
        }

        //Test v�rdi p� n�jagtig 200000
        [TestMethod]
        public void TestGr�nsev�rdi()
        {
            int pris = 200000;

            //Beregning af afgift for normal bil
            Assert.AreEqual(170000, Afgift.BilAfgift(pris));

            //Beregning af afgift for elbil
            Assert.AreEqual(34000, Afgift.ElbilAfgift(pris));
        }

        //Test v�rdi over 200000
        [TestMethod]
        public void TestDyrBil()
        {
            int pris = 350000;

            //beregning af afgift for normal bil
            Assert.AreEqual(395000, Afgift.BilAfgift(pris));

            //Beregning af afgift for elbil
            Assert.AreEqual(79000, Afgift.ElbilAfgift(pris));
        }

        //test afgift med v�rdi p� 0
        [TestMethod]
        public void TestNulV�rdi()
        {
            //Alm bil
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Afgift.BilAfgift(0));

            //elbil
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Afgift.ElbilAfgift(0));
        }

        //test afgift med negativ v�rdi
        [TestMethod]
        public void TestNegativV�rdi()
        {
            //Alm bil
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Afgift.BilAfgift(-1000));

            //elbil
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Afgift.ElbilAfgift(-1000));
        }
    }
}
