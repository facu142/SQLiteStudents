using SQLiteStudents.ViewModels;

namespace SQLiteStudents.Views;

public partial class StudentListPage : ContentPage
{
	public StudentListPage(StudentListPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}