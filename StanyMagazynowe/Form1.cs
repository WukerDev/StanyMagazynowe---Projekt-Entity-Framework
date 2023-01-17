using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanyMagazynowe
{
    public partial class Form1 : Form
    {
        int IDSzukane;  //tworzymy zmienną do szukania 
        public Form1()
        {
            InitializeComponent();
            
        }

        public void ListBoxLoad()  //ładujemy listBoxa
        {
            {
                listBox1.Items.Clear();  //czyścimy obydwa
                listBox2.Items.Clear();
                using (var db = new ObslugaBazy())  //baza danych db o wartości nowej bazy danych stworzonej w pliku OblsugaBazy
                {
                    var towary = db.Towar.ToList();  //zamieniamy tabelę towar na listę i przypisujemy do zmiennej towary
                    foreach (var towar in towary)  //za każdy towar na liście powtarzamy pętlę
                    {
                        string powlaczone = towar.Nazwa + " " + towar.Jednostka;  //string powlaczone (literówka)  ma wartość nazwy towaru, dodajemy spację i wypisujemy jednostkę
                        listBox1.Items.Add(powlaczone); //dodajemy do listboxa wartość stringa powlaczone
                    }
                    ;

                }
                using (var db = new ObslugaBazy())
                {
                        var ilosci = db.StanMagazynowy.ToList(); //tutaj jak wyżej, robimy zmienną ilosci do której jest przypisana lista stworzona z bazy danych zawierające zmienne z tabeli StanMagazynowy
                        foreach (var Ilosc in ilosci) // za każdą ilość w tabeli zmiennej ilosci pętla powtarza się
                        {

                            listBox2.Items.Add(Ilosc.Ilosc); //do listboxa dodajemy kolejne przedmioty 

                        }

                }


            }
        }
        private void button1_Click(object sender, EventArgs e)  //dodajemy dane do bazy
        {
            ListBoxLoad();  //ładujemy listboxa
            string[] wartosci = { textBox1.Text, textBox2.Text, textBox3.Text }; //tworzymy tabelę o nazwie wartośći która będzie posiadała wartości z 3 textboxów
            ObslugaBazy baza = new ObslugaBazy(); //tworzymy obiekt baza by korzystać z metod w klasie ObslugaBazy
            baza.Towar.Add(new Towar { Nazwa = wartosci[0], Jednostka = wartosci[1] }); //używając obiektu baza wywołujemy funkcję dodawania do tabeli Towar, którego wartoscią będzie pierwsza wartosc w tabeli Wartosci i ustalamy ze zmienna Jednostki jest równa drugiej pozycji w tabeli wartosci 
            baza.SaveChanges();  //zapisujemy zmiany
            IDSzukane = baza.Towar.Count(); //ustalamy że zmienna IDSzukane ma wartość ilości zmiennych w tabeli Towar
            baza.StanMagazynowy.Add(new StanMagazynowy { Ilosc = Convert.ToInt32(wartosci[2]), FKID_Towar = IDSzukane }); //dodajemy nowy stan magazynowy, jak wyżej z towarem
            baza.SaveChanges(); // zapisujemy zmiany
            ListBoxLoad(); //ładujemy listBoxa
        }

        private void button2_Click(object sender, EventArgs e)  //drugi przycisk ładuje nam tylko dane
        {
            ListBoxLoad();  //wywołujemy metodę
        }
    }
}
