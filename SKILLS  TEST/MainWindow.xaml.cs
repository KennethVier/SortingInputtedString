using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SKILLS__TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public interface ISortingStrategy
    {
        void Sort(List<char> list);
    }

    public partial class MainWindow : Window
    {
        private ISortingStrategy? _sortingStrategy;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SortButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)SortingMethod.SelectedItem;
            string selected = (string)comboBoxItem.Content;

            if (string.IsNullOrEmpty(SortTextBox.Text))
            {
                MessageBox.Show("Please enter a string to sort.");
                return;
            }

            if (selected == "Bubble Sort")
            {
                _sortingStrategy = new BubbleSortStrategy();
            }
            else if (selected == "Merge Sort")
            {
                _sortingStrategy = new MergeSortStrategy();
            }
            else
            {
                MessageBox.Show("Please select a valid sorting method.");
                return;
            }

            string sortedResult = SortString(SortTextBox.Text);
            ShowOutput.Text = sortedResult;

            ResetUI();
        }

        private string SortString(string input)
        {
            List<char> characters = input.ToList();
            if (_sortingStrategy != null)
            {
                _sortingStrategy.Sort(characters);
            }
            return new string(characters.ToArray());
        }

        private void ResetUI()
        {
            SortTextBox.Clear();
            SortingMethod.SelectedIndex = -1;
        }
    }

    public class BubbleSortStrategy : ISortingStrategy
    {
        public void Sort(List<char> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        char temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    }

    public class MergeSortStrategy : ISortingStrategy
    {
        public void Sort(List<char> list)
        {
            if (list.Count <= 1)
                return;

            int middle = list.Count / 2;
            var left = new List<char>(list.GetRange(0, middle));
            var right = new List<char>(list.GetRange(middle, list.Count - middle));

            Sort(left);
            Sort(right);

            Merge(list, left, right);
        }

        private void Merge(List<char> list, List<char> left, List<char> right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    list[k++] = left[i++];
                }
                else
                {
                    list[k++] = right[j++];
                }
            }

            while (i < left.Count)
            {
                list[k++] = left[i++];
            }

            while (j < right.Count)
            {
                list[k++] = right[j++];
            }
        }
    }
}