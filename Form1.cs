using System;
using System.Windows.Forms;

namespace JogoDaVelhaCSharp
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turnos = true, jogoFinal = false;
        string[] texto = new string[9];

        

        public Form1()
        {
            InitializeComponent();
        }

        #region Metodo botão
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (string.IsNullOrEmpty(btn.Text) && jogoFinal == false)
            {


                if (turnos)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turnos = !turnos;//Passando o turno(vez) para o outro jogador
                    checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turnos = !turnos;
                    checagem(2);
                }
            }
        }
        #endregion

        #region metodo checagem horizontal, vertical e diagonal
        void checagem(int checagemPlayer)
        {
            string suporte = string.Empty;

            if (checagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }// final do suporte

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(checagemPlayer);
                        return;//Para quebra o metodo e ir para proxima checagem.

                    }//Final checagem da horizontal
                }
            }//Final do Looping Horizontal

            //Checar Vertical

            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(checagemPlayer);
                        return;//Para quebra o metodo e ir para proxima checagem.

                    }//Final checagem da vertical
                }
            }//Final do Looping Vertical

            //Checar na diagonal
            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(checagemPlayer);
                    return;
                }//Diagonal Principal
            }

            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(checagemPlayer);
                    return;
                }//Diagonal Segundario
            }

            if(rodadas == 9 && jogoFinal == false)
            {
                empatesPontos++;
                empate.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("Deu Velha!!!");
                jogoFinal = true;
                return;
            }
        }
        #endregion

        #region metodo que verifica o vencedor
        void Vencedor(int PlayerVencedor)
        {
            jogoFinal = true;
            if(PlayerVencedor == 1)
            {
                Xplayer++;
                XPontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("O jogador X é o vencedor!!!", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                turnos = true;
            }
            else
            {
                Oplayer++;
                OPontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("O jogador O é o vencedor!!!", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                turnos = false;
            }
        }
        #endregion

        #region Ação do botão Reset que limpa campo.
        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                btn.Text = string.Empty;
                button2.Text = string.Empty;
                button3.Text = string.Empty;
                button4.Text = string.Empty;
                button5.Text = string.Empty;
                button6.Text = string.Empty;
                button7.Text = string.Empty;
                button8.Text = string.Empty;
                button9.Text = string.Empty;
                rodadas = 0;
                jogoFinal = false;
                texto[i] = string.Empty;

            }
        }
        #endregion

    }
}
