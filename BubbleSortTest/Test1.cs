using AndetSemesterOPG;
using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
using System.Windows;
namespace BubbleSortTest
{
    [TestClass]
    public sealed class Test1 // Tobias & Laura
    {
        [TestMethod]
        public void RandomBubbleSortTest()
        {

            ISort sort = new Sort();
            //Opretter 20 vilkårlige Attendee objekter
            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 3);
            Attendee a4 = new Attendee("Dennis", "Nielsen", "Camp B", 4);
            Attendee a5 = new Attendee("Egon", "Olsen", "Camp A", 5);
            Attendee a6 = new Attendee("Freja", "Jensen", "Camp B", 6);
            Attendee a7 = new Attendee("Gustav", "Andersen", "Camp A", 7);
            Attendee a8 = new Attendee("Helene", "Madsen", "Camp B", 8);
            Attendee a9 = new Attendee("Ida", "Pedersen", "Camp A", 9);
            Attendee a10 = new Attendee("Jonas", "Larsen", "Camp B", 10);

            Attendee a11 = new Attendee("Karen", "Christensen", "Camp A", 11);
            Attendee a12 = new Attendee("Lars", "Hansen", "Camp B", 12);
            Attendee a13 = new Attendee("Mette", "Rasmussen", "Camp A", 13);
            Attendee a14 = new Attendee("Niels", "Sørensen", "Camp B", 14);
            Attendee a15 = new Attendee("Oliver", "Thomsen", "Camp A", 15);
            Attendee a16 = new Attendee("Pernille", "Winther", "Camp B", 16);
            Attendee a17 = new Attendee("Rasmus", "Berg", "Camp A", 17);
            Attendee a18 = new Attendee("Signe", "Dahl", "Camp B", 18);
            Attendee a19 = new Attendee("Thomas", "Frandsen", "Camp A", 19);
            Attendee a20 = new Attendee("Ulrik", "Vestergaard", "Camp B", 20);

            //Opretter listen expected og tilføjer Attendee objekter til listen som er sorteret på forhånd. Dette er hvad vi forventer sorteringen resulterer i
            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20 };
            //Opretter listen random og tilføjer Attendee objekter til listen i en tilfældig rækkefølge.
            List<Attendee> random = new List<Attendee> { a18, a4, a13, a11, a1, a6, a10, a2, a20, a3, a12, a17, a8, a5, a15, a7, a19, a14, a9, a16 };
            //Opretter listen actual der skal indholde det sorterede resultat
            List<Attendee> actual = new List<Attendee>();

            //Kalder SortByEntranceId (bubble sort) på listen random og gemmer resultatet i actual
            sort.SortByEntranceId(random);
           
            actual = random;

            // Bruger Collection.Assert.AreEqual() for at tjekke om listen expected er den samme som actual.
            CollectionAssert.AreEqual(expected, actual);
            //Viser en besked der udskriver antal sammenligninger for bubble sort algoritmen
            MessageBox.Show(sort.bubbleComparisons.ToString(), "RandomBubbleSortTest");
            //Resetter bubbleComparisons
            sort.bubbleComparisons = 0;


        }

        // Kig på notterne for den overstående randomBubbleSortTest for at forstå hvad der sker i denne test, denne gang er det bare med en liste der allerede er sorteret
        [TestMethod]
        public void SortedBubbleSortTest()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 3);
            Attendee a4 = new Attendee("Dennis", "Nielsen", "Camp B", 4);
            Attendee a5 = new Attendee("Egon", "Olsen", "Camp A", 5);
            Attendee a6 = new Attendee("Freja", "Jensen", "Camp B", 6);
            Attendee a7 = new Attendee("Gustav", "Andersen", "Camp A", 7);
            Attendee a8 = new Attendee("Helene", "Madsen", "Camp B", 8);
            Attendee a9 = new Attendee("Ida", "Pedersen", "Camp A", 9);
            Attendee a10 = new Attendee("Jonas", "Larsen", "Camp B", 10);

            Attendee a11 = new Attendee("Karen", "Christensen", "Camp A", 11);
            Attendee a12 = new Attendee("Lars", "Hansen", "Camp B", 12);
            Attendee a13 = new Attendee("Mette", "Rasmussen", "Camp A", 13);
            Attendee a14 = new Attendee("Niels", "Sørensen", "Camp B", 14);
            Attendee a15 = new Attendee("Oliver", "Thomsen", "Camp A", 15);
            Attendee a16 = new Attendee("Pernille", "Winther", "Camp B", 16);
            Attendee a17 = new Attendee("Rasmus", "Berg", "Camp A", 17);
            Attendee a18 = new Attendee("Signe", "Dahl", "Camp B", 18);
            Attendee a19 = new Attendee("Thomas", "Frandsen", "Camp A", 19);
            Attendee a20 = new Attendee("Ulrik", "Vestergaard", "Camp B", 20);


            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20 };

            List<Attendee> sorted = new List<Attendee> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20 };

            List<Attendee> actual = new List<Attendee>();

            sort.SortByEntranceId(sorted);

            actual = sorted;

            CollectionAssert.AreEqual(expected, actual);
            MessageBox.Show(sort.bubbleComparisons.ToString(), "SortedBubbleSortTest");
            sort.bubbleComparisons = 0;
        }

        //Laver en bubblesort test på en tom liste
        [TestMethod]
        public void BubbleSort0Test()
        {
            //opretter Sort instans
            ISort sort = new Sort();

            //opretter tom liste
            List<Attendee> empty = new List<Attendee>();

            //Bruger Assert.IsNull til at teste om resultatet der returneres er null
            Assert.IsNull(sort.SortByEntranceId(empty));
            //Viser en besked der udskriver antal sammenligninger for bubble sort algoritmen
            MessageBox.Show(sort.bubbleComparisons.ToString(), "BubbleSort0Test");
            //Resetter bubbleComparisons
            sort.bubbleComparisons = 0;
        }
        // kig på noterne på overstående test, det er det samme bare hvor at det er en liste med et elemt i.
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
