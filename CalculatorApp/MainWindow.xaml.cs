using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        
        double lastNumber, result;
        SelectedOperator selectedOperator;

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentButton.Click += PercentButton_Click;
            equalButton.Click += EqualButton_Click;

        }

        #region Event Handlers
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        {
                            result = SimpleMath.Add(lastNumber, newNumber);
                        }
                        break;
                    case SelectedOperator.Subtraction:
                        {
                            result = SimpleMath.Subtract(lastNumber, newNumber);
                        }
                        break;
                    case SelectedOperator.Multiplication:
                        {
                            result = SimpleMath.Multiply(lastNumber, newNumber);
                        }
                        break;
                    case SelectedOperator.Division:
                        {
                            result = SimpleMath.Divide(lastNumber, newNumber);
                        }
                        break;
                    default:
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber /= 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = -lastNumber;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == plusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (sender == minusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            if (sender == multiplyButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            if (sender == divisionButton)
            {
                selectedOperator = SelectedOperator.Division;
            }

        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content }.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue;
            int.TryParse(((Button)(sender)).Content.ToString(), out selectedValue);

            if (resultLabel.Content.ToString() ==  "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content }{selectedValue}";
            }
        }

        #endregion
    }

    public class SimpleMath
    {
        public static double Add(double a,double b)
        {
            return a + b;
        }
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            return a / b;
        }
    }



    #region Enumerators
    public enum SelectedOperator
    { 
        Addition,
        Subtraction, 
        Multiplication,
        Division
    }
    #endregion
}
