using AndetSemesterOPG;
using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
using System.Windows;
namespace QuickSortTest
{
    [TestClass]
    public sealed class Test1 // Ludvig & Emil
    {
        [TestMethod]
        public void RandomQuickSortTest()
        {

            ISort sort = new Sort();

            //Opretter 20 vilkårlige Attendee objekter
            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 2);
            Attendee a4 = new Attendee("Dennis", "Nielsen", "Camp B", 1);
            Attendee a5 = new Attendee("Egon", "Olsen", "Camp A", 1);
            Attendee a6 = new Attendee("Freja", "Jensen", "Camp B", 2);
            Attendee a7 = new Attendee("Gustav", "Andersen", "Camp A", 1);
            Attendee a8 = new Attendee("Helene", "Madsen", "Camp B", 2);
            Attendee a9 = new Attendee("Ida", "Pedersen", "Camp A", 1);
            Attendee a10 = new Attendee("Jonas", "Larsen", "Camp B", 2);
            Attendee a11 = new Attendee("Karen", "Christensen", "Camp A", 1);
            Attendee a12 = new Attendee("Lars", "Hansen", "Camp B", 2);
            Attendee a13 = new Attendee("Mette", "Rasmussen", "Camp A", 1);
            Attendee a14 = new Attendee("Niels", "Sørensen", "Camp B", 2);
            Attendee a15 = new Attendee("Oliver", "Thomsen", "Camp A", 1);
            Attendee a16 = new Attendee("Pernille", "Winther", "Camp B", 2);
            Attendee a17 = new Attendee("Rasmus", "Berg", "Camp A", 1);
            Attendee a18 = new Attendee("Signe", "Dahl", "Camp B", 2);
            Attendee a19 = new Attendee("Thomas", "Frandsen", "Camp A", 1);
            Attendee a20 = new Attendee("Ulrik", "Vestergaard", "Camp B", 2);

            //Opretter listen expected og tilføjer Attendee objekter til listen som er sorteret på forhånd. Dette er hvad vi forventer sorteringen resulterer i
            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20 };

            //Opretter listen random og tilføjer Attendee objekter til listen i en tilfældig rækkefølge.
            List<Attendee> random = new List<Attendee> { a18, a4, a13, a11, a1, a6, a10, a2, a20, a3, a12, a17, a8, a5, a15, a7, a19, a14, a9, a16 };

            //Opretter listen actual der skal indholde det sorterede resultat
            List<Attendee> actual = new List<Attendee>();

            //Kalder SortByFirstName (quick sort) på listen random og gemmer resultatet i actual
            sort.SortByFirstName(random, 0, random.Count - 1);
            actual = random;
            //Bruger Collection.Assert.AreEqual() for at tjekke om listen expected er den samme som actual.
            CollectionAssert.AreEqual(expected, actual);
            //Viser en besked der udskriver antal sammenligninger for quick sort algoritmen
            MessageBox.Show(sort.quickComparisons.ToString(), "RandomQuickSortTest");
            //Resetter quickComparisons
            sort.quickComparisons = 0;


        }

        // kig på notterne for den overstående quicksortTest for at forstå hvad der sker i denne test. Det er det samme som ovenfor bare med en list som allerede er sorteret
        [TestMethod]
        public void SortedQuickSortTest()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);
            Attendee a2 = new Attendee("Birthe", "Kjær", "Camp B", 2);
            Attendee a3 = new Attendee("Cecil", "Bødker", "Camp A", 2);
            Attendee a4 = new Attendee("Dennis", "Nielsen", "Camp B", 1);
            Attendee a5 = new Attendee("Egon", "Olsen", "Camp A", 1);
            Attendee a6 = new Attendee("Freja", "Jensen", "Camp B", 2);
            Attendee a7 = new Attendee("Gustav", "Andersen", "Camp A", 1);
            Attendee a8 = new Attendee("Helene", "Madsen", "Camp B", 2);
            Attendee a9 = new Attendee("Ida", "Pedersen", "Camp A", 1);
            Attendee a10 = new Attendee("Jonas", "Larsen", "Camp B", 2);

            Attendee a11 = new Attendee("Karen", "Christensen", "Camp A", 1);
            Attendee a12 = new Attendee("Lars", "Hansen", "Camp B", 2);
            Attendee a13 = new Attendee("Mette", "Rasmussen", "Camp A", 1);
            Attendee a14 = new Attendee("Niels", "Sørensen", "Camp B", 2);
            Attendee a15 = new Attendee("Oliver", "Thomsen", "Camp A", 1);
            Attendee a16 = new Attendee("Pernille", "Winther", "Camp B", 2);
            Attendee a17 = new Attendee("Rasmus", "Berg", "Camp A", 1);
            Attendee a18 = new Attendee("Signe", "Dahl", "Camp B", 2);
            Attendee a19 = new Attendee("Thomas", "Frandsen", "Camp A", 1);
            Attendee a20 = new Attendee("Ulrik", "Vestergaard", "Camp B", 2);


            List<Attendee> expected = new List<Attendee> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20 };

            List<Attendee> sorted = new List<Attendee> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20 };

            List<Attendee> actual = new List<Attendee>();

            sort.SortByFirstName(sorted, 0, sorted.Count - 1);

            actual = sorted;

            CollectionAssert.AreEqual(expected, actual);
            MessageBox.Show(sort.quickComparisons.ToString(), "SortedQuickSortTest");
            sort.quickComparisons = 0;
        }
        //Laver en quicksort test med en tom liste, hvor vi forventer at få null tilbage. Vi viser antal sammenligninger og resetter quickComparisons
        [TestMethod]
        public void QuickSort0Test()
        {
            //opretter Sort instans
            ISort sort = new Sort();
            //opretter tom liste
            List<Attendee> empty = new List<Attendee>();
            //Bruger Assert.IsNull til at teste om resultatet der returneres er null
            Assert.IsNull(sort.SortByFirstName(empty, 0, empty.Count));
            //Viser en besked der udskriver antal sammenligninger for quick sort algoritmen
            MessageBox.Show(sort.quickComparisons.ToString(), "QuickSort0Test");
            //Resetter quickComparisons
            sort.quickComparisons = 0;
        }

        //Kig på notterne for den overstående quicksortTest for at forstå hvad der sker i denne test. Denne gang er det med en liste hvor der kun er et elemt i.
        [TestMethod]
        public void QuickSort1Test()
        {

            ISort sort = new Sort();

            Attendee a1 = new Attendee("Adam", "Oehlenschläger", "Camp A", 1);

            List<Attendee> oneItemList = new List<Attendee> { a1 };

            Assert.IsNull(sort.SortByFirstName(oneItemList,0,oneItemList.Count));
            MessageBox.Show(sort.quickComparisons.ToString(), "QuickSort1Test");
            sort.quickComparisons = 0;
            

        }
    }
}
