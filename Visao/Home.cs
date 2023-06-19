using Visao;

namespace Urna
{
    public partial class Home : Form
    {
        private Executivo execForm;
        private Legislativo legisForm;
        private Home previousForm; 
        private Gerenciamento gerenciamentoForm; 

        public Home()
        {
            InitializeComponent();
        }

        public Home(Home previousForm) : this()
        {
            this.previousForm = previousForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            execForm = new Executivo();
            execForm.FormClosed += ExecForm_FormClosed;
            execForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            legisForm = new Legislativo();
            legisForm.FormClosed += LegisForm_FormClosed;
            legisForm.Show();
            this.Hide();
        }

        private void ExecForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            execForm.Dispose();
            this.Show();
        }

        private void LegisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            legisForm.Dispose();
            this.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (previousForm != null)
                previousForm.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gerenciamentoForm = new Gerenciamento();
            gerenciamentoForm.FormClosed += (object? sender, FormClosedEventArgs e) => { gerenciamentoForm.Dispose(); this.Show(); };
            gerenciamentoForm.Show();
            this.Hide();
        }
    }
}
