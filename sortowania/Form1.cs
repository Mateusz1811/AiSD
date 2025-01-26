namespace naukaSortowania3
{
    public partial class Form1 : Form
    {
        private int[] tablica;
        public Form1()
        {
            InitializeComponent();
        }

        private void BubbleSort(int[] tablica)
        {
            for (int i = 0; i < tablica.Length - 1; i++)
            {
                for (int j = 0; j < tablica.Length - i - 1; j++)
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

        private void InsertSort(int[] tablica)
        {
            for (int i = 0; i < tablica.Length - 1; i++)
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

        private void Merge(int[] tablica, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] lewaTablica = new int[n1];
            int[] prawaTablica = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                lewaTablica[i] = tablica[left + 1];
            }

            for (int j = 0; j < n2; j++)
            {
                prawaTablica[j] = tablica[mid + 1 + j];
            }

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

        private void CountingSort(int[] array)
        {
            var MaxElement = array[0];
            var MinElement = array[0];

            foreach (var num in array)
            {
                if (num < MinElement)
                {
                    MinElement = num;
                }
                if (num > MaxElement)
                {
                    MaxElement = num;
                }
            }

            int range = MaxElement - MinElement + 1;

            int[] count = new int[range];

            foreach (var num in array)
            {
                count[num - MinElement]++;
            }

            int index = 0;
            for (int i = 0; i < range; i++)
            {
                while (count[i] > 0)
                {
                    array[index] = i + MinElement;
                    index++;
                    count[i]--;
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }

        private void WyswietlTablice()
        {
            listBox1.Items.Clear();
            foreach (var num in tablica)
            {
                listBox1.Items.Add(num);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            BubbleSort(tablica);
            czas.Stop();
            label1.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlTablice();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            InsertSort(tablica);
            czas.Stop();
            label1.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlTablice();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            MergeSort(tablica, 0, tablica.Length - 1);
            czas.Stop();
            label1.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlTablice();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            CountingSort(tablica);
            czas.Stop();
            label1.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlTablice();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var czas = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(tablica, 0, tablica.Length - 1);
            czas.Stop();
            label1.Text = $"Czas sortowania: {czas.ElapsedMilliseconds} ms";

            WyswietlTablice();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] inputNumbers = textBox1.Text.Split(',');
            tablica = Array.ConvertAll(inputNumbers, int.Parse);
            WyswietlTablice();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int rozmiar = int.Parse(textBox2.Text);
            Random rand = new Random();
            tablica = new int[rozmiar];
            for (int i = 0; i < rozmiar; i++)
            {
                tablica[i] = rand.Next(-1000, 1000);
            }
            WyswietlTablice();
        }
    }
}
