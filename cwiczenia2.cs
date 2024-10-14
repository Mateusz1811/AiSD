using System.Windows.Forms;
///sortowanie babelkowe button1
///sortowanie insertsort button2
///merge sort button3

namespace Cwiczenia2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] tablica = { 5, 2, 9, 1, 5, 6 };

        private void button1_Click(object sender, EventArgs e)
        {

            for(int i=0;i<tablica.Length-1;i++)
            {
                for(int j=0;j<tablica.Length-1-i;j++)
                {
                    if(tablica[j]>tablica[j + 1])
                    {
                        int temp=tablica[j];
                        tablica[j]=tablica[j + 1];
                        tablica[j + 1]=temp;
                    }
                }
            }

            foreach (int number in tablica)
            {
                listBox1.Items.Add(number);
            }
        }

        private void InsertSort(int[] tablica)
        {
            for(int i=1;i<tablica.Length;i++)
            {
                int temp = tablica[i];
                int j = i - 1;
                for (j=i-1;j>=0 && tablica[j]>temp;j--)
                {
                    tablica[j+1] = tablica[j];
                }
                tablica[j+1] = temp;
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            InsertSort(tablica);

            foreach(int number in tablica)
            {
                listBox2.Items.Add(number);
            }
        }

        private void MergeSort(int[] tablica, int start, int koniec)
        {
            start = tablica[0];
            koniec = 
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
