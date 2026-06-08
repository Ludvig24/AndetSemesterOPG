using AndetSemesterOPG;
using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
namespace QuickSortTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void RandomQuickSortTest()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 2);
            Attendee a4 = new Attendee("Egon", "Olsen", "Camp A", 1);
            Attendee a5 = new Attendee("Holger", "Danske", "Camp B", 1);


            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5 };

            List<Attendee> random = new List<Attendee> { a3, a5, a1, a2, a4 };

            List<Attendee> actual = new List<Attendee>();

            sort.SortByFirstName(random, 0, random.Count - 1);

            actual = random;

            CollectionAssert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void SortedQuickSortTest()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 2);
            Attendee a4 = new Attendee("Egon", "Olsen", "Camp A", 1);
            Attendee a5 = new Attendee("Holger", "Danske", "Camp B", 1);


            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5 };

            List<Attendee> sorted = new List<Attendee> { a1, a2, a3, a4, a5 };

            List<Attendee> actual = new List<Attendee>();

            sort.SortByFirstName(sorted, 0, sorted.Count - 1);

            actual = sorted;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort0Test()
        {

            ISort sort = new Sort();


            List<Attendee> empty = new List<Attendee>();


            Assert.IsNull(sort.SortByFirstName(empty, 0, empty.Count));
        }

        [TestMethod]
        public void QuickSort1Test()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);

            List<Attendee> oneItemList = new List<Attendee> { a1 };

            Assert.IsNull(sort.SortByFirstName(oneItemList,0,oneItemList.Count));
            

        }
    }
}
