using OOPassignment;

namespace TestBag
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsertElem()
        {
        }

        [TestMethod]
        public void TestRemoveElem()
        {
            Bag x = new Bag();
            try
            {
                x.removeElem(2);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NoElementInBag);
            }

            Element e1 = new Element(2);
            Element e2 = new Element(3);

            x.insertElem(e1);
            x.insertElem(e2);

            try
            {
                x.removeElem(1);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NotPresentInBag);
            }

            x.removeElem(2);
            Assert.IsTrue(!x.ContainsElement(2));
            x.removeElem(3);
            Assert.IsTrue(!x.ContainsElement(3));
            Assert.IsTrue(x.length == 0);
        }

        [TestMethod]
        public void TestFrequencyElem()
        {
            Bag x = new Bag();

            try
            {
                x.FrequencyOfElem(4);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NoElementInBag);
            }

            Element e1 = new Element(4);
            Element e2 = new Element(5);
            x.insertElem(e1);
            x.insertElem(e2);

            try
            {
                x.FrequencyOfElem(6);
            }
            catch (Exception ex)
            {
                Assert.IsTrue (ex is Bag.NotPresentInBag);
            }

            int y = x.FrequencyOfElem(4);
            Assert.IsTrue(y == 1);

            Element e3 = new Element(5);
            x.insertElem(e3);
            int z = x.FrequencyOfElem(5);
            Assert.IsTrue(z == 2);
        }

        [TestMethod]
        public void Testprint()
        {
            Bag x = new Bag();

            try
            {
                x.print();
                Assert.Fail("No exception was thrown");
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex is Bag.NoElementInBag);
            }
        }

        [TestMethod]
        public void onlyOneOccurence()
        {
            Bag x = new Bag();

            try
            {
                x.onlyOneOccurence();
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NoElementInBag);
            }

            Element e1 = new Element(1);
            Element e2 = new Element(2);
            Element e3 = new Element(1);
            Element e4 = new Element(2);

            x.insertElem(e1);
            x.insertElem(e2);
            x.insertElem(e3);
            x.insertElem(e4);

            try
            {
                x.onlyOneOccurence();
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Bag.NoSingleElementInBag);
            }


            Element e5 = new Element(3);
            Element e6 = new Element(4);
            x.insertElem(e5);
            x.insertElem(e6);
            int y = x.onlyOneOccurence();
            Assert.IsTrue(y == 2);
            
        }
    }
}