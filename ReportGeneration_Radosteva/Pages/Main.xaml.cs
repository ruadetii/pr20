using ReportGeneration_Radosteva.Classes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReportGeneration_Radosteva.Pages
{
    public partial class Main : Page
    {
        public List<GroupContext> AllGroups = GroupContext.AllGroups();
        public List<StudentContext> AllStudents = StudentContext.AllStudents();
        public List<WorkContext> AllWorks = WorkContext.AllWorks();
        public List<EvaluationContext> AllEvaluations = EvaluationContext.AllEvaluations();
        public List<DisciplineContext> AllDisciplines = DisciplineContext.AllDisciplines();
        public Main()
        {
            InitializeComponent();
            CreateGroupUI();
            CreateStudents(AllStudents);
        }

        public void CreateGroupUI() 
        {
            foreach (GroupContext Group in AllGroups) 
            {
                cbGroups.Items.Add(Group.Name);
            }
            cbGroups.Items.Add("Выберите...");
            cbGroups.SelectedIndex = cbGroups.Items.Count - 1;
        }

        public void CreateStudents(List<StudentContext> AllStudents) 
        {
            parent.Children.Clear();
            foreach (StudentContext Student in AllStudents) 
            {
                parent.Children.Add(new Items.Student(Student, this));
            }
        }

        private void SelectGroup(object sender, SelectionChangedEventArgs e)
        {
            if (cbGroups.SelectedIndex != cbGroups.Items.Count - 1) 
            {
                int idGroup = AllGroups.Find(x => x.Name == cbGroups.SelectedItem).Id;
                CreateStudents(AllStudents.FindAll(x => x.IdGroup == idGroup));
            }
        }

        private void SelectStudents(object sender, KeyEventArgs e)
        {
            List<StudentContext> SearchStudent = AllStudents;
            if (cbGroups.SelectedIndex != cbGroups.Items.Count - 1)
            {
                int idGroup = AllGroups.Find(x => x.Name == cbGroups.SelectedItem).Id;
                SearchStudent = AllStudents.FindAll(x => x.IdGroup == idGroup);       
            }
            CreateStudents(SearchStudent.FindAll(x => $"{x.Lastname} {x.Firstname}".Contains(tbFIO.Text)));
        }

        private void ReportGeneration(object sender, RoutedEventArgs e)
        {
            if (cbGroups.SelectedIndex != cbGroups.Items.Count - 1) 
            {
                int idGroup = AllGroups.Find(x => x.Name == cbGroups.SelectedItem).Id;
                Classes.Common.Report.Group(idGroup, this);
            }
        }
    }
}
