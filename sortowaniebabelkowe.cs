namespace SortowanieBabelkowe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] tablica = { 5, 2, 9, 1, 5, 6 };

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

            foreach (int number in tablica)
            {
                listBox1.Items.Add(number);
            }
        }
    }
}
