using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fdsafdsafdsa
{
    public partial class Form1 : Form
    {
        private int[] tablica;
        public Form1()
        {
            InitializeComponent();
        }

        private void InsertSort(int[] tablica)
        {
            for (int i = 1; i < tablica.Length; i++)
            {
                int temp = tablica[i];
                int j = i - 1;
                for (j = i - 1; j >= 0 && tablica[j] > temp; j--)
                {
                    tablica[j + 1] = tablica[j];
                }
                tablica[j + 1] = temp;
            }


        }

        private void BubbleSort(int[] tablica)
        {

            for (int i = 0; i < tablica.Length - 1; i++)
            {
                for (int j = 0; j < tablica.Length - 1 - i; j++)
                {
                    if (tablica[j] > tablica[j + 1])
                    {
                        int temp = tablica[j];
                        tablica[j] = tablica[j + 1];
                        tablica[j + 1] = temp;
                    }
                }
            }

        }

        public void Merge(int[] tablica, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;


            int[] lewaTablica = new int[n1];
            int[] prawaTablica = new int[n2];


            for (int i = 0; i < n1; i++)
                lewaTablica[i] = tablica[left + i];
            for (int j = 0; j < n2; j++)
                prawaTablica[j] = tablica[mid + 1 + j];


            int iLeft = 0, iRight = 0;
            int k = left;


            while (iLeft < n1 && iRight < n2)
            {
                if (lewaTablica[iLeft] <= prawaTablica[iRight])
                {
                    tablica[k] = lewaTablica[iLeft];
                    iLeft++;
                }
                else
                {
                    tablica[k] = prawaTablica[iRight];
                    iRight++;
                }
                k++;
            }


            while (iLeft < n1)
            {
                tablica[k] = lewaTablica[iLeft];
                iLeft++;
                k++;
            }


            while (iRight < n2)
            {
                tablica[k] = prawaTablica[iRight];
                iRight++;
                k++;
            }
        }


        public void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        public int[] CountingSort(int[] tablica)
        {
            int max = tablica.Max();
            int min = tablica.Min();
            int range = max - min + 1;

            int[] count = new int[range];
            int[] wynik = new int[tablica.Length];

            for (int i = 0; i < tablica.Length; i++)
                count[tablica[i] - min]++;

            for (int i = 1; i < count.Length; i++)
                count[i] += count[i - 1];

            for (int i = tablica.Length - 1; i >= 0; i--)
            {
                wynik[count[tablica[i] - min] - 1] = tablica[i];
                count[tablica[i] - min]--;
            }

            return wynik;
        }

        public int Partycja(int[] tablica, int low, int high)
        {
            int pivot = tablica[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (tablica[j] < pivot)
                {
                    i++;
                    int temp = tablica[i];
                    tablica[i] = tablica[j];
                    tablica[j] = temp;
                }
            }
            int temp1 = tablica[i + 1];
            tablica[i + 1] = tablica[high];
            tablica[high] = temp1;
            return i + 1;
        }

        public void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partycja(array, low, high);
                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        private void WyswietlTablice()
        {
            ListBox1.Items.Clear();
            for (int i = 0; i < Math.Min(15, tablica.Length); i++)
            {
                ListBox1.Items.Add(tablica[i]);
            }
        }

        private void WyswietlPosortowanaTablice()
        {
            ListBox1.Items.Clear();
            for (int i = 0; i < Math.Min(15, tablica.Length); i++)
            {
                ListBox1.Items.Add(tablica[i]);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            BubbleSort(tablica);
            czas.Stop();
            label2.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlPosortowanaTablice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            InsertSort(tablica);
            czas.Stop();
            label2.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlPosortowanaTablice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            MergeSort(tablica, 0, tablica.Length - 1);
            czas.Stop();
            label2.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

           
            WyswietlPosortowanaTablice();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            CountingSort(tablica);
            czas.Stop();
            label2.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlPosortowanaTablice();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(tablica, 0, tablica.Length - 1);
            czas.Stop();
            label2.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

           
            WyswietlPosortowanaTablice();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int rozmiar = int.Parse(textBox2.Text);
            Random rand = new Random();
            tablica = new int[rozmiar];
            for (int i = 0; i < rozmiar; i++)
            {
                tablica[i] = rand.Next(1, 1000);
            }
            WyswietlTablice();
        }

        private void button6_Click(object sender, EventArgs e)
        {


            string[] inputNumbers = textBox1.Text.Split(',');
            tablica = Array.ConvertAll(inputNumbers, int.Parse);
            WyswietlTablice();


        }


    }
}



