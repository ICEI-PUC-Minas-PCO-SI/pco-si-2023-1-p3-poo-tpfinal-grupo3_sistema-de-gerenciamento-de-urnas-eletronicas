using Controller.Controllers;
using Model.DTO;
using Model.Helpers;
using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visao
{
    public partial class Gerenciamento : Form
    {
        public Gerenciamento()
        {
            InitializeComponent();

        }

        #region Generated Methods

        private void dataGridView1_EditModeChanged(object sender, EventArgs e)
        {
            Console.WriteLine();
        }

        private void dataGridCandidatos_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["IdCandidato"].Value = null;
            e.Row.Cells["NomeCandidato"].Value = null;
            e.Row.Cells["NumeroCandidato"].Value = null;
            e.Row.Cells["DataNascimentoCandidato"].Value = null;
            e.Row.Cells["CargoCandidato"].Value = null;
            e.Row.Cells["PartidoCandidato"].Value = null;
        }

        private void Gerenciamento_Load(object sender, EventArgs e)
        {
            this.CarregarDadosGridCandidatos();
            this.CarregarDadosGridPartidos();
            this.CarregarDadosGridEleicoes();
        }


        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[1].Value as string) || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[1].Value as string))
            //{
            //    dataGridView1.Rows[e.RowIndex].ErrorText = "Valor Obrigattório.";
            //    e.Cancel = true;
            //}
        }


        private void btnSalvarGridPartido_Click(object sender, EventArgs e)
        {
            try
            {
                var _partidoController = new PartidoController();

                _partidoController.InsertUpdate(((BindingList<PartidoDTO>)dataGridPartido.DataSource).ToList());
                this.CarregarDadosGridPartidos();
                this.LimparSelecoes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSalvarGridCandidatos_Click(object sender, EventArgs e)
        {
            try
            {
                var _candidadtoController = new CandidatoController();

                _candidadtoController.InsertUpdate(((BindingList<CandidatoDTO>)dataGridCandidatos.DataSource).ToList());
                this.CarregarDadosGridCandidatos();
                this.LimparSelecoes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSalvarGridEleicoes_Click(object sender, EventArgs e)
        {
            try
            {
                var _eleicaoController = new EleicaoController();

                _eleicaoController.InsertUpdate(((BindingList<EleicaoDTO>)dataGridEleicao.DataSource).ToList());
                this.CarregarDadosGridEleicoes();
                this.LimparSelecoes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnDeletePartido_Click(object sender, EventArgs e)
        {
            try
            {
                var _partidoController = new PartidoController();
                var linhaSelecionada = dataGridPartido.SelectedRows[0].DataBoundItem as PartidoDTO;
                _partidoController.Delete(linhaSelecionada!.Id!.Value);
                this.CarregarDadosGridPartidos();
                this.LimparSelecoes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnDeleteEleicao_Click(object sender, EventArgs e)
        {
            try
            {
                var _eleicaoController = new EleicaoController();
                var linhaSelecionada = dataGridEleicao.SelectedRows[0].DataBoundItem as EleicaoDTO;
                _eleicaoController.Delete(linhaSelecionada!.Id!.Value);
                this.CarregarDadosGridEleicoes();
                this.LimparSelecoes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnApagarCandidato_Click(object sender, EventArgs e)
        {
            try
            {
                var _candidatoController = new CandidatoController();
                var linhaSelecionada = dataGridPartido.SelectedRows[0].DataBoundItem as CandidatoDTO;
                _candidatoController.Delete(linhaSelecionada!.Id!.Value);
                this.CarregarDadosGridCandidatos();
                this.LimparSelecoes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void dataGridCandidatos_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteCandidato.Enabled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnDeletePartido.Enabled = true;
        }

        private void dataGridEleicao_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteEleicao.Enabled = true;
            btnEncerrar.Enabled = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CarregarDadosGridCandidatos();
            this.CarregarDadosGridPartidos();
            this.LimparSelecoes();
        }
        #endregion
        #region CustomMethods
        private void CarregarDadosGridCandidatos()
        {
            var _partidoController = new PartidoController();
            var _candidatoController = new CandidatoController();

            var columnCargo = ((DataGridViewComboBoxColumn)this.dataGridCandidatos.Columns["CargoCandidato"]);
            var columnPartido = ((DataGridViewComboBoxColumn)this.dataGridCandidatos.Columns["PartidoCandidato"]);
            columnCargo.DataSource = _partidoController.ListCargos();
            columnPartido.DataSource = _partidoController.List();
            var dados = _candidatoController.ListGrid();
            var bl = new BindingList<CandidatoDTO>(dados);

            this.dataGridCandidatos.DataSource = bl;

        }

        private void CarregarDadosGridPartidos()
        {
            var _partidoController = new PartidoController();
            var dados = _partidoController.ListGrid();
            var bs = new BindingList<PartidoDTO>(dados);
            dataGridPartido.DataSource = bs;
        }

        private void CarregarDadosGridEleicoes()
        {
            var _eleicaoController = new EleicaoController();
            var columnTipoEleicao = ((DataGridViewComboBoxColumn)this.dataGridEleicao.Columns["TipoEleicao"]);
            var columnStatusEleicao = ((DataGridViewComboBoxColumn)this.dataGridEleicao.Columns["StatusEleicao"]);
            columnTipoEleicao.DataSource = _eleicaoController.ListTiposEleicao();
            columnStatusEleicao.DataSource = _eleicaoController.ListStatusEleicao();
            var dados = _eleicaoController.ListGrid();
            var bs = new BindingList<EleicaoDTO>(dados);
            dataGridEleicao.DataSource = bs;
        }

        private void LimparSelecoes()
        {

            this.dataGridCandidatos.ClearSelection();
            this.dataGridEleicao.ClearSelection();
            this.dataGridPartido.ClearSelection();


            this.btnDeleteCandidato.Enabled = false;
            this.btnDeleteEleicao.Enabled = false;
            this.btnDeletePartido.Enabled = false;
            this.btnEncerrar.Enabled = false;
        }

        #endregion

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var _votoController = new VotoController();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                try
                {
                    String path = dialog.FileName; // get name of file
                    using (var fs = new FileStream(path, FileMode.Open))
                    {
                        _votoController.InserirVotosArquivo(fs);
                        MessageBox.Show("Votos importados!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            try
            {
                var _eleicaoController = new EleicaoController();
                var linhaSelecionada = dataGridEleicao.SelectedRows[0].DataBoundItem as EleicaoDTO;
                _eleicaoController.FinalizarEleicao(linhaSelecionada!.Id!.Value);
                MessageBox.Show("Eleição encerrada!");
                this.CarregarDadosGridEleicoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
