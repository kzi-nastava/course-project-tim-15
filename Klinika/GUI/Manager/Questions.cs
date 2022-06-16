using Klinika.Core.Dependencies;
using Klinika.Questionnaries.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Manager
{
    public partial class Questions : Form
    {
        QuestionService? questionService;
        int qID;
        int targetID;
        public Questions(int qID, int targetID)
        {
            this.qID = qID;
            this.targetID = targetID;
            questionService = StartUp.serviceProvider.GetService<QuestionService>();
            InitializeComponent();
        }

        private void Questions_Load(object sender, EventArgs e)
        {
            questionsTable.Fill(questionService.GetById(qID, targetID));
        }

        private void answersButton_Click(object sender, EventArgs e)
        {

        }
    }
}
