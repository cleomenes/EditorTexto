using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        StreamReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }
        
        private void btn_Novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Salvar()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter _streamWriter = new StreamWriter(arquivo);
                    _streamWriter.Flush();
                    _streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    _streamWriter.Write(this.richTextBox1.Text);
                    _streamWriter.Flush();
                    _streamWriter.Close();
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show("Erro na Gravação do Arquivo" + ex.Message, "Erro ao Gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                      
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\Cleomenes\Documents\Programação\Portifolio\EditorTexto\EditorTexto\Testes";
            openFileDialog1.Filter = "(*.txt)|*.txt|Todos Arquivos(*.*)|*.*)";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader leitor = new StreamReader(arquivo);
                    leitor.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = leitor.ReadLine();

                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = leitor.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de leitura: " + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Copiar()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negrito()
        {
            string nomeFonte = richTextBox1.Font.Name;
            float tamanhoFonte = richTextBox1.Font.Size;
            bool isNegrito = richTextBox1.SelectionFont.Bold;
            var estilo = richTextBox1.SelectionFont.Style;

            if(isNegrito == false)
            {
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo | FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo & (~FontStyle.Bold));
            }
        }

        private void Italico()
        {
            string nomeFonte = richTextBox1.Font.Name;
            float tamanhoFonte = richTextBox1.Font.Size;
            bool isItalico = richTextBox1.SelectionFont.Italic;
            var estilo = richTextBox1.SelectionFont.Style;

            if (isItalico == false)
            {
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo | FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo & (~FontStyle.Italic));
            }
        }

        private void Sublinhado()
        {
            string nomeFonte = richTextBox1.Font.Name;
            float tamanhoFonte = richTextBox1.Font.Size;
            bool isSublinhado = richTextBox1.SelectionFont.Underline;
            var estilo = richTextBox1.SelectionFont.Style;

            if (isSublinhado == false)
            {
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo | FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nomeFonte, tamanhoFonte, estilo & (~FontStyle.Underline));
            }
        }

        private void btn_Negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btn_Italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sumbliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void btn_Sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }
    }
}
