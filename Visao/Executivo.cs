using Controller.Controllers;
using Model.DTO;
using Model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Model.Helpers.Enums;

namespace Urna
{
    public partial class Executivo : Form
    {
        private static CandidatoDTO? candidatoSelecionado;

        public Executivo()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DesenharRetanguloPreto(e.Graphics);
            DesenharRetanguloBranco(e.Graphics);
            DesenharRetanguloBrancos(e.Graphics);
        }

        private void DesenharRetanguloPreto(Graphics g)
        {
            int squareSize = 350;
            int squareX = (ClientSize.Width - squareSize) - 20;
            int squareY = (ClientSize.Height - squareSize) * 2 / 3;

            g.FillRectangle(Brushes.Black, squareX, squareY, squareSize, squareSize);
        }

        private void DesenharRetanguloBranco(Graphics g)
        {
            int rectangleWidth = 350;
            int rectangleHeight = 50;

            int rectangleX = ClientSize.Width - rectangleWidth - 20;
            int rectangleY = 20;

            g.FillRectangle(Brushes.White, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
        }

        private void DesenharRetanguloBrancos(Graphics g)
        {
            int rectangleWidth = ClientSize.Width / 2;
            int rectangleHeight = ClientSize.Height - 120;

            int rectangleX = (ClientSize.Width - rectangleWidth) / 8;
            int rectangleY = (ClientSize.Height - rectangleHeight) / 2;

            g.FillRectangle(Brushes.White, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
        }


        private void btn_Click(object sender, EventArgs e)
        {
            if (numeroUrna.Text.Length < 2)
                numeroUrna.Text += ((Button)sender).Name.Replace("btn", "");

            if (numeroUrna.Text.Length == 2)
            {
                var _candidatoController = new CandidatoController();

                var candidato = _candidatoController.GetByNumeroEmEleicao(numeroUrna.Text, Model.Helpers.Enums.ETipoEleicao.EXECUTIVO);
                var msg = "";

                if (candidato != null)
                {
                    msg = $"Candidato {candidato.Nome} do partido {candidato.PartidoNome} \r\n Concorrendo ao cargo de {((ECargo)candidato.Cargo!.Value).GetDescription()}.";
                    candidatoSelecionado = candidato;
                }
                else if (numeroUrna.Text == "00")
                    msg = "Voto nulo!";
                else
                    msg = "Candidato não encontrado!";


                this.txtCandidato.Text = msg;
            }
        }

        private void buttonBranco_Click_1(object sender, EventArgs e)
        {
            numeroUrna.Text = "";
            var _votoController = new VotoController();
            try
            {
                _votoController.InsertBranco(ETipoEleicao.EXECUTIVO);
                this.numeroUrna.Text = "";
                this.txtCandidato.Text = "";
                MessageBox.Show("Voto Computado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonConfirma_Click_1(object sender, EventArgs e)
        {
            var _votoController = new VotoController();
            try
            {
                if (this.numeroUrna.Text == "00")
                {
                    _votoController.InsertNulo(ETipoEleicao.EXECUTIVO);
                    MessageBox.Show("Voto Computado!");
                }
                else if (candidatoSelecionado != null)
                {
                    _votoController.InsertCandidato(candidatoSelecionado.Id!.Value, ETipoEleicao.EXECUTIVO);
                    MessageBox.Show("Voto Computado!");
                }

                this.numeroUrna.Text = "";
                this.txtCandidato.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonCorrige_Click_1(object sender, EventArgs e)
        {
            numeroUrna.Text = "";
            this.txtCandidato.Text = "";
        }
    }
}
