using Dzhos_CSharp_01.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Dzhos_CSharp_01.Views
{
    /// <summary>
    /// Interaction logic for BirthDayView.xaml
    /// </summary>
    public partial class BirthDayView : UserControl
    {
        private readonly BirthDayViewModel _viewModel;

        public BirthDayView()
        {
            InitializeComponent();
            DataContext = _viewModel = new BirthDayViewModel();
            datePicker.SelectedDate = DateTime.Today;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = datePicker.SelectedDate;
            if (selectedDate != null)
            {
                _viewModel.UpdateDate = selectedDate.Value;
            }
        }
    }
}
