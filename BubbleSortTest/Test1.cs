using AndetSemesterOPG;
using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
using System.Windows;
namespace BubbleSortTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void RandomBubbleSortTest()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 3);
            Attendee a4 = new Attendee("Egon", "Olsen", "Camp A", 4);
            Attendee a5 = new Attendee("Holger", "Danske", "Camp B", 5);


            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5 };

            List<Attendee> random = new List<Attendee> { a3, a5, a1, a2, a4 };

            List<Attendee> actual = new List<Attendee>();

            sort.SortByEntranceId(random);

            actual = random;

            CollectionAssert.AreEqual(expected, actual);
            MessageBox.Show(sort.bubbleComparisons.ToString(), "RandomBubbleSortTest");
            sort.bubbleComparisons = 0;


        }

        [TestMethod]
        public void SortedBubbleSortTest()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 3);
            Attendee a4 = new Attendee("Egon", "Olsen", "Camp A", 4);
            Attendee a5 = new Attendee("Holger", "Danske", "Camp B", 5);


            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5 };

            List<Attendee> sorted = new List<Attendee> { a1, a2, a3, a4, a5 };

            List<Attendee> actual = new List<Attendee>();

            sort.SortByEntranceId(sorted);

            actual = sorted;

            CollectionAssert.AreEqual(expected, actual);
            MessageBox.Show(sort.bubbleComparisons.ToString(), "SortedBubbleSortTest");
            sort.bubbleComparisons = 0;
        }

        [TestMethod]
        public void BubbleSort0Test()
        {

            ISort sort = new Sort();


            List<Attendee> empty = new List<Attendee>();


            Assert.IsNull(sort.SortByEntranceId(empty));
            MessageBox.Show(sort.bubbleComparisons.ToString(), "BubbleSort0Test");
            sort.bubbleComparisons = 0;
        }

        [TestMethod]
        public void BubbleSort1Test()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);

            List<Attendee> oneItemList = new List<Attendee> { a1 };

            Assert.IsNull(sort.SortByEntranceId(oneItemList));
            MessageBox.Show(sort.bubbleComparisons.ToString(), "BubbleSort1Test");
            sort.bubbleComparisons = 0;


        }
    }

}
